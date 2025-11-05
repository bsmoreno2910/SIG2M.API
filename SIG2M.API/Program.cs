using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SIG2M.IOCS; 
using System.Text;

var builder = WebApplication.CreateBuilder(args);


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
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ClockSkew = TimeSpan.Zero // Remove tolerância padrão de 5 minutos
        };

        // Tratamento de eventos de autenticação
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Add("Token-Expired", "true");
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
builder.Services.AddControllers();



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
        License = new OpenApiLicense { 
            Name = "Prefeitura Munincipal de Campinas", 
            Url = new Uri("https://campinas.sp.gov.br/")
        }
    });

    // Definir esquema de segurança JWT Bearer
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

    // Adicionar requisito de segurança global
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
            new string[] {}
        }
    });
});

// ============================================
// CONFIGURAÇÃO DE CORS
// ============================================

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.ConfigurarServicos(builder.Configuration);
var app = builder.Build();

// ============================================
// CONFIGURAÇÃO DO PIPELINE HTTP
// ============================================
if (app.Environment.IsDevelopment())
{
    // Habilitar middleware do Swagger
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SIG2M API - Documentação");
        c.RoutePrefix = string.Empty;
        c.DocumentTitle = "SIG2M API - Documentação";
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
