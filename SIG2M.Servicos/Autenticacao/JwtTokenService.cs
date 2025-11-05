using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SIG2M.Dominio.Entidades;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static SIG2M.Dominio.Models.Autenticacao.AutenticacaoModels;
namespace SIG2M.Servicos.Autenticacao
{ 
    public class JwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Gera um token JWT para o usuário especificado
        /// </summary>
        /// <param name="idUsuario">Id do usuário</param>
        /// <param name="username">Nome do usuário</param>
        /// <param name="roles">Roles/Papéis do usuário</param>
        /// <param name="additionalClaims">Claims adicionais opcionais</param>
        /// <returns>Token JWT como string</returns>
        public LoginResponse GenerateToken(AutenticacaoApi auth)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Claims básicas
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, auth.Name),
                new Claim(JwtRegisteredClaimNames.Sub, auth.Login),
                new Claim(JwtRegisteredClaimNames.Jti, auth.Login), 
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            int.TryParse(_configuration["Jwt:ExpiryInMinutes"]?.ToString(), out int expiryInMinutes);

            // Obter tempo de expiração da configuração ou usar padrão de 60 minutos
            expiryInMinutes = expiryInMinutes <= 0 ?  60 : expiryInMinutes;
            var expires = DateTime.UtcNow.AddMinutes(expiryInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new LoginResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Username = auth.Name,
                ExpiresIn = expires
            };
        }

        /// <summary>
        /// Valida um token JWT
        /// </summary>
        /// <param name="token">Token JWT a ser validado</param>
        /// <returns>ClaimsPrincipal se válido, null se inválido</returns>
        public ClaimsPrincipal? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["Jwt:Audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return principal;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Extrai o username de um token JWT
        /// </summary>
        /// <param name="token">Token JWT</param>
        /// <returns>Username ou null se inválido</returns>
        public string? GetUsernameFromToken(string token)
        {
            var principal = ValidateToken(token);
            return principal?.Identity?.Name;
        }

        /// <summary>
        /// Verifica se um token está expirado
        /// </summary>
        /// <param name="token">Token JWT</param>
        /// <returns>True se expirado, False caso contrário</returns>
        public bool IsTokenExpired(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var jwtToken = tokenHandler.ReadJwtToken(token);
                return jwtToken.ValidTo < DateTime.UtcNow;
            }
            catch
            {
                return true;
            }
        }
    }

}
