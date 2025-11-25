using Microsoft.Extensions.Logging;
using SIG2M.Dominio.Entidades;
using SIG2M.Dominio.Interfaces.Repositorios.Grupos;
using SIG2M.Dominio.Interfaces.Servicos.Conexao;
using SIG2M.Dominio.Interfaces.Servicos.Grupos;
using System.Data;

namespace SIG2M.Servicos.Grupos
{
    public class ServicoSubGrupos : IServicoSubGrupos
    {
        private readonly ILogger<ServicoSubGrupos> _logger;
        private readonly IServicoDeConexao _conn;
        private readonly IRepositorioSubgrupo _rSubgrupo;
        public ServicoSubGrupos(ILogger<ServicoSubGrupos> logger, IServicoDeConexao conn, IRepositorioSubgrupo rSubgrupo)
        {
            _logger = logger;
            _conn = conn;
            _rSubgrupo = rSubgrupo;
        }

        public async Task<IEnumerable<Subgrupo>> ObterTodos(IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rSubgrupo.ObterTodosAsync(gConn.conn, transaction);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os subgrupos.");
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


        public async Task<Subgrupo> ObterPorId(short codSubGrupo, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rSubgrupo.ObterPorIdAsync(codSubGrupo, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter subgrupo por ID.");
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

        public async Task<Subgrupo> ObterPorNome(string nome, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rSubgrupo.ObterPorNomeAsync(nome, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter subgrupo por nome.");
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

        public async Task<IEnumerable<Subgrupo>> ObterPorGrupo(short codGrupo, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rSubgrupo.ObterPorGrupoAsync(codGrupo, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter subgrupos por grupo.");
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

        public async Task<Subgrupo> Inserir(Subgrupo subGrupo, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            var gTrans = GerenciaTransacao(gConn.conn, transaction);
            try
            {
                subGrupo.CodSubgrupo = await _rSubgrupo.ObterProximoIdAsync(gConn.conn, transaction);
                var codSubGrupo = await _rSubgrupo.InserirAsync(subGrupo, gConn.conn, gTrans.transaction);

                if (codSubGrupo != subGrupo.CodSubgrupo)
                    throw new Exception("Erro ao inserir o subgrupo.");
                if (gTrans.interna)
                    gTrans.transaction?.Commit();

                return await ObterPorId(codSubGrupo, gConn.conn);
            }
            catch (Exception ex)
            {
                if (gTrans.interna)
                {
                    gTrans.transaction?.Rollback();
                }

                _logger.LogError(ex, "Erro ao inserir subgrupo.");
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

        public async Task<Subgrupo> Atualizar(Subgrupo subGrupo, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            var gTrans = GerenciaTransacao(gConn.conn, transaction);
            try
            {
                if (!(await _rSubgrupo.AtualizarAsync(subGrupo, gConn.conn, gTrans.transaction)))
                    throw new Exception("Erro ao atualizar o subgrupo.");
                if (gTrans.interna)
                    gTrans.transaction?.Commit();

                return await ObterPorId(subGrupo.CodSubgrupo, gConn.conn);
            }
            catch (Exception ex)
            {
                if (gTrans.interna)
                {
                    gTrans.transaction?.Rollback();
                }

                _logger.LogError(ex, "Erro ao atualizar subgrupo.");
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
