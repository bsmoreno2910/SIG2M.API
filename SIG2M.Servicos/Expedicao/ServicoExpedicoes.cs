using Microsoft.Extensions.Logging;
using SIG2M.Dominio.Interfaces.Repositorios.Expedicao;
using SIG2M.Dominio.Interfaces.Servicos.Conexao;
using SIG2M.Dominio.Interfaces.Servicos.Expedicao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Servicos.Expedicao
{
    public class ServicoExpedicoes : IServicoExpedicoes
    {
        private readonly ILogger<ServicoExpedicoes> _logger;
        private readonly IServicoDeConexao _conn;
        private readonly IRepositorioExpedicao _rExpedicao;
        public ServicoExpedicoes(ILogger<ServicoExpedicoes> logger, IServicoDeConexao conn, IRepositorioExpedicao rExpedicao)
        {
            _logger = logger;
            _conn = conn;
            _rExpedicao = rExpedicao;
        }

        public async Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterTodos(IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rExpedicao.ObterTodosAsync(gConn.conn, transaction);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todas as expedições.");
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

        public async Task<Dominio.Entidades.Expedicao> ObterPorId(long lista, int contador, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rExpedicao.ObterPorIdAsync(lista, contador, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter expedição por ID.");
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

        public async Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterPorLista(long lista, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rExpedicao.ObterPorListaAsync(lista, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter expedições por lista.");
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

        public async Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterPorMaterial(int codMaterial, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rExpedicao.ObterPorMaterialAsync(codMaterial, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter expedições por material.");
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

        public async Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterPorSetor(string sigla, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rExpedicao.ObterPorSetorAsync(sigla, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter expedições por setor.");
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

        public async Task<Dominio.Entidades.Expedicao> Inserir(Dominio.Entidades.Expedicao expedicao, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            var gTrans = GerenciaTransacao(gConn.conn, transaction);
            try
            {
                if (!(await _rExpedicao.InserirAsync(expedicao, gConn.conn, gTrans.transaction)))
                    throw new Exception("Erro ao inserir a expedição.");
                if (gTrans.interna)
                    gTrans.transaction?.Commit();

                return await ObterPorId(expedicao.Lista, expedicao.Contador, gConn.conn);
            }
            catch (Exception ex)
            {
                if (gTrans.interna)
                {
                    gTrans.transaction?.Rollback();
                }

                _logger.LogError(ex, "Erro ao inserir expedição.");
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

        public async Task<Dominio.Entidades.Expedicao> Atualizar(Dominio.Entidades.Expedicao expedicao, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            var gTrans = GerenciaTransacao(gConn.conn, transaction);
            try
            {
                if (!(await _rExpedicao.AtualizarAsync(expedicao, gConn.conn, gTrans.transaction)))
                    throw new Exception("Erro ao atualizar a expedição.");
                if (gTrans.interna)
                    gTrans.transaction?.Commit();

                return await ObterPorId(expedicao.Lista, expedicao.Contador, gConn.conn);
            }
            catch (Exception ex)
            {
                if (gTrans.interna)
                {
                    gTrans.transaction?.Rollback();
                }

                _logger.LogError(ex, "Erro ao atualizar expedição.");
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
