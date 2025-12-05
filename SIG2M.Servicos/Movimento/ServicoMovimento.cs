using Microsoft.Extensions.Logging;
using SIG2M.Dominio.Interfaces.Repositorios.Movimento;
using SIG2M.Dominio.Interfaces.Servicos.Conexao;
using SIG2M.Dominio.Interfaces.Servicos.Movimento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Servicos.Movimento
{
    public class ServicoMovimento : IServicoMovimento
    {
        private readonly ILogger<ServicoMovimento> _logger;
        private readonly IServicoDeConexao _conn;
        private readonly IRepositorioMovimento _rMovimento;
        public ServicoMovimento(ILogger<ServicoMovimento> logger, IServicoDeConexao conn, IRepositorioMovimento rMovimento)
        {
            _logger = logger;
            _conn = conn;
            _rMovimento = rMovimento;
        }

        public async Task<IEnumerable<Dominio.Entidades.Movimento>> ObterTodos(IDbConnection conn, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rMovimento.ObterTodosAsync(gConn.conn, transaction);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os materiais.");
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


        public async Task<Dominio.Entidades.Movimento> ObterPorId(int ano, int codMovimento, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rMovimento.ObterPorIdAsync(ano, codMovimento, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter movimento por ID.");
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

        public async Task<IEnumerable<Dominio.Entidades.Movimento>> ObterPorDocumento(long lista, int contador, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rMovimento.ObterPorDocumentoAsync(lista, contador, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter movimento por nome.");
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

        public async Task<Dominio.Entidades.Movimento> Inserir(Dominio.Entidades.Movimento movimento, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            var gTrans = GerenciaTransacao(gConn.conn, transaction);
            try
            {
                movimento.CodMovimento = await _rMovimento.ObterProximoIdAsync(movimento.Ano, gConn.conn, gTrans.transaction);


                var codMovimento = await _rMovimento.InserirAsync(movimento, gConn.conn, gTrans.transaction);

                if (codMovimento != movimento.CodMovimento)
                    throw new Exception("Erro ao inserir o movimento.");
                if (gTrans.interna)
                    gTrans.transaction?.Commit();

                return await ObterPorId(movimento.Ano, codMovimento, gConn.conn);
            }
            catch (Exception ex)
            {
                if (gTrans.interna)
                {
                    gTrans.transaction?.Rollback();
                }

                _logger.LogError(ex, "Erro ao inserir movimento.");
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

        public async Task<Dominio.Entidades.Movimento> Atualizar(Dominio.Entidades.Movimento movimento, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            var gTrans = GerenciaTransacao(gConn.conn, transaction);
            try
            {
                if (!(await _rMovimento.AtualizarAsync(movimento, gConn.conn, gTrans.transaction)))
                    throw new Exception("Erro ao atualizar o movimento.");
                if (gTrans.interna)
                    gTrans.transaction?.Commit();

                return await ObterPorId(movimento.Ano, movimento.CodMovimento, gConn.conn);
            }
            catch (Exception ex)
            {
                if (gTrans.interna)
                {
                    gTrans.transaction?.Rollback();
                }

                _logger.LogError(ex, "Erro ao atualizar movimento.");
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
