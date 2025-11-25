using Microsoft.Extensions.Logging;
using SIG2M.Dominio.Interfaces.Repositorios.Setor;
using SIG2M.Dominio.Interfaces.Servicos.Conexao;
using SIG2M.Dominio.Interfaces.Servicos.Setor;
using System.Data;

namespace SIG2M.Servicos.Setor
{
    public class ServicoSetor : IServicoSetor
    {
        private readonly ILogger<ServicoSetor> _logger;
        private readonly IServicoDeConexao _conn;
        private readonly IRepositorioSetor _rSetor;
        public ServicoSetor(ILogger<ServicoSetor> logger, IServicoDeConexao conn, IRepositorioSetor rSetor)
        {
            _logger = logger;
            _conn = conn;
            _rSetor = rSetor;
        }

        public async Task<IEnumerable<Dominio.Entidades.Setor>> ObterTodos(IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rSetor.ObterTodosAsync(gConn.conn, transaction);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os Dominio.Entidades.Setor.");
                throw;
            }
            finally
            {
                if (gConn.interna)
                {
                    gConn.conn?.Close();
                    gConn.conn?.Dispose();
                }
            }
        }


        public async Task<Dominio.Entidades.Setor> ObterPorId(string sigla, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rSetor.ObterPorIdAsync(sigla, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter setor por ID.");
                throw;
            }
            finally
            {
                if (gConn.interna)
                {
                    gConn.conn?.Close();
                    gConn.conn?.Dispose();
                }

            }
        }

        public async Task<Dominio.Entidades.Setor> ObterPorNome(string nome, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rSetor.ObterPorNomeAsync(nome, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter setor por nome.");
                throw;
            }
            finally
            {
                if (gConn.interna)
                {
                    gConn.conn?.Close();
                    gConn.conn?.Dispose();
                }

            }
        }

        public async Task<IEnumerable<Dominio.Entidades.Setor>> ObterPorDistrito(string distrito, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rSetor.ObterPorDistritoAsync(distrito, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter Dominio.Entidades.Setor por distrito.");
                throw;
            }
            finally
            {
                if (gConn.interna)
                {
                    gConn.conn?.Close();
                    gConn.conn?.Dispose();
                }

            }
        }

        public async Task<Dominio.Entidades.Setor> Inserir(Dominio.Entidades.Setor setor, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            var gTrans = GerenciaTransacao(gConn.conn, transaction);
            try
            {
                var sigla = await _rSetor.InserirAsync(setor, gConn.conn, gTrans.transaction);

                if (sigla != setor.Sigla)
                    throw new Exception("Erro ao inserir o setor.");
                if (gTrans.interna)
                    gTrans.transaction?.Commit();

                return await ObterPorId(sigla, gConn.conn);
            }
            catch (Exception ex)
            {
                if (gTrans.interna)
                {
                    gTrans.transaction?.Rollback();
                }

                _logger.LogError(ex, "Erro ao inserir setor.");
                throw;
            }
            finally
            {
                if (gConn.interna)
                {
                    gConn.conn?.Close();
                    gConn.conn?.Dispose();
                }
            }
        }

        public async Task<Dominio.Entidades.Setor> Atualizar(Dominio.Entidades.Setor setor, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            var gTrans = GerenciaTransacao(gConn.conn, transaction);
            try
            {
                if (!(await _rSetor.AtualizarAsync(setor, gConn.conn, gTrans.transaction)))
                    throw new Exception("Erro ao atualizar o setor.");
                if (gTrans.interna)
                    gTrans.transaction?.Commit();

                return await ObterPorId(setor.Sigla, gConn.conn);
            }
            catch (Exception ex)
            {
                if (gTrans.interna)
                {
                    gTrans.transaction?.Rollback();
                }

                _logger.LogError(ex, "Erro ao atualizar setor.");
                throw;
            }
            finally
            {
                if (gConn.interna)
                {
                    gConn.conn?.Close();
                    gConn.conn?.Dispose();
                }
            }
        }

        private async Task<(bool interna, IDbConnection conn)> GerenciaConexao(IDbConnection conn = null)
        {
            if (conn == null)
            {
                var novaConn = await _conn.ConectarAsync();
                return (true, novaConn);
            }
            return (false, conn);
        }


        private (bool interna, IDbTransaction transaction) GerenciaTransacao(IDbConnection conn, IDbTransaction transaction = null)
        {
            if (transaction == null)
            {

                transaction = conn.BeginTransaction();
                return (true, transaction);
            }
            else
            {

                transaction = conn.BeginTransaction();
                return (false, transaction);
            }
        }
    }
}
