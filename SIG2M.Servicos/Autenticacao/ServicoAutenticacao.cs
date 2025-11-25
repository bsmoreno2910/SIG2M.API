using Microsoft.Extensions.Logging;
using SIG2M.Dominio.Interfaces.Repositorios.Autenticacao;
using SIG2M.Dominio.Interfaces.Servicos.Autenticacao;
using SIG2M.Dominio.Interfaces.Servicos.Conexao;
using SIG2M.Servicos.Criptografia;
using static SIG2M.Dominio.Models.Autenticacao.AutenticacaoModels;

namespace SIG2M.Servicos.Autenticacao
{
    public class ServicoAutenticacao : IServicoAutenticacao
    {
        private readonly ILogger<ServicoAutenticacao> _logger;
        private readonly IServicoDeConexao _conn;
        private readonly IRepositorioAutenticacao _rAuth;
        private readonly JwtTokenService _tokenService;
        public ServicoAutenticacao(ILogger<ServicoAutenticacao> logger, IServicoDeConexao conn, IRepositorioAutenticacao rAuth, JwtTokenService tokenService)
        {
            _logger = logger;
            _conn = conn;
            _rAuth = rAuth;
            _tokenService = tokenService;
        }
        public async Task<LoginResponse> Logar(LoginRequest @param)
        {
            var conn = await _conn.ConectarAsync();
            var transaction = conn.BeginTransaction();
            try
            {
                var auth = await _rAuth.ObterPorLoginSenhaAsync(@param.Login, @param.Password.Criptografar(),conn,transaction);
                var loginResponse = _tokenService.GenerateToken(auth);

                auth.Token = loginResponse.Token;
                auth.ExpiresAt = loginResponse.ExpiresIn;
                if (!(await _rAuth.AtualizarAsync(auth, conn, transaction)))
                    throw new Exception("Falha ao Gravar Token");
                transaction.Commit();
                return loginResponse; 
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }


        }
    }
}
