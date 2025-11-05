using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIG2M.Dominio.Interfaces.Servicos.Autenticacao;
using static SIG2M.Dominio.Models.Autenticacao.AutenticacaoModels;

namespace SIG2M.API.Controllers.Autenticacao
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    { 
        private readonly ILogger<AuthController> _logger;
        private readonly IServicoAutenticacao _sAuth;

        public AuthController(IServicoAutenticacao sAuth, ILogger<AuthController> logger)
        {
            _sAuth = sAuth;
            _logger = logger;
        }

        /// <summary>
        /// Endpoint de login - gera token JWT
        /// </summary>
        /// <param name="request">Credenciais de login</param>
        /// <returns>Token JWT se credenciais válidas</returns>
        [AllowAnonymous]
        [HttpPost("v1/Login")]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] Dominio.Models.Autenticacao.AutenticacaoModels.LoginRequest request)
        {
            try
            {
                return Ok(await _sAuth.Logar(request));

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Falha no login para usuário: {Username}", request.Login);
                return Unauthorized(new ErrorResponse
                {
                    Error = "Erro no Login",
                    Message = ex.Message
                });
            }
        }

    }
}
