using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using SIG2M.API.Utils;
using SIG2M.IOCS;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ============================================
// CONFIGURAÇÃO DE AMBIENTE E LOGGING
// ============================================
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

builder.Services.ConfigurarLogger(builder.Configuration, "SIG2M - API");

//Log.Logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Configuration)
//    .Enrich.FromLogContext()
//    .WriteTo.Console()
//    .WriteTo.File("/data/logs/sig2m-api-.txt",
//        rollingInterval: RollingInterval.Day,
//        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
//    .CreateLogger();

//builder.Host.UseSerilog();

// ============================================
// VALIDAÇÃO DE CONFIGURAÇÕES OBRIGATÓRIAS
// ============================================
var jwtKey = builder.Configuration["Jwt:Key"];
var dbConnectionString = builder.Configuration["ConnectionStrings:Suprimentos"];

if (string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(dbConnectionString))
{
    throw new InvalidOperationException("Variáveis de ambiente obrigatórias não configuradas: Jwt:Key, ConnectionStrings:Suprimentos");
}

// ============================================
// CONFIGURAÇÃO DO DATA PROTECTION
// ============================================
var keysPath = Path.Combine("/data", "dataprotection-keys");
Directory.CreateDirectory(keysPath);

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(keysPath))
    .SetApplicationName("SIG2M.API");

// ============================================
// CONFIGURAÇÃO DE AUTENTICAÇÃO JWT
// ============================================
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            ClockSkew = TimeSpan.Zero
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Append("Token-Expired", "true");
                }
                return Task.CompletedTask;
            },
            OnChallenge = context =>
            {
                context.HandleResponse();
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                var result = System.Text.Json.JsonSerializer.Serialize(
                    new { error = "Você não está autorizado a acessar este recurso" });
                return context.Response.WriteAsync(result);
            }
        };
    });

// ============================================
// CONFIGURAÇÃO DE CONTROLLERS
// ============================================
builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
}).AddNewtonsoftJson();

// ============================================
// CONFIGURAÇÃO DO SWAGGER COM JWT
// ============================================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SIG2M API - Documentação",
        Version = "v1",
        Description = "API para Integração ao Sistema SIG2M",
        License = new OpenApiLicense
        {
            Name = "Prefeitura Municipal de Campinas",
            Url = new Uri("https://campinas.sp.gov.br/")
        }
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = @"Autenticação JWT usando o esquema Bearer.

Entre com 'Bearer' [espaço] e então seu token na caixa de texto abaixo.

Exemplo: 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...'"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// ============================================
// CONFIGURAÇÃO DE CORS
// ============================================
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        policyBuilder =>
        {
            if (allowedOrigins.Contains("*"))
            {
                policyBuilder.AllowAnyOrigin()
                             .AllowAnyMethod()
                             .AllowAnyHeader();
            }
            else
            {
                policyBuilder.WithOrigins(allowedOrigins)
                             .AllowAnyMethod()
                             .AllowAnyHeader();
            }
        });
});

builder.Services.ConfigurarServicos(builder.Configuration);

var app = builder.Build();

// ============================================
// CONFIGURAÇÃO DO PIPELINE HTTP
// ============================================
// Habilitar Swagger em todos os ambientes
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SIG2M API - Documentação");
    c.RoutePrefix = string.Empty;
    c.DocumentTitle = "SIG2M API - Documentação";
});

// O redirecionamento HTTPS é tratado pelo proxy reverso (Easypanel)
// app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseCors("AllowSpecificOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
