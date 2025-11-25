using Microsoft.Extensions.Logging;
using SIG2M.Dominio.Entidades;
using SIG2M.Dominio.Interfaces.Repositorios.Grupos;
using SIG2M.Dominio.Interfaces.Servicos.Conexao;
using SIG2M.Dominio.Interfaces.Servicos.Grupos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Servicos.Grupos
{
    public class ServicoFamilias : IServicoFamilias
    {
        private readonly ILogger<ServicoFamilias> _logger;
        private readonly IServicoDeConexao _conn;
        private readonly IRepositorioFamilia _rFamilia;
        public ServicoFamilias(ILogger<ServicoFamilias> logger, IServicoDeConexao conn, IRepositorioFamilia rFamilia)
        {
            _logger = logger;
            _conn = conn;
            _rFamilia = rFamilia;
        }

        public async Task<IEnumerable<Familia>> ObterTodos(IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rFamilia.ObterTodosAsync(gConn.conn, transaction);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todas as famílias.");
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


        public async Task<Familia> ObterPorId(short codFamilia, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rFamilia.ObterPorIdAsync(codFamilia, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter família por ID.");
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

        public async Task<Familia> ObterPorNome(string nome, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rFamilia.ObterPorNomeAsync(nome, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter família por nome.");
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

        public async Task<IEnumerable<Familia>> ObterPorSubGrupo(short codSubGrupo, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rFamilia.ObterPorSubGrupoAsync(codSubGrupo, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter famílias por subgrupo.");
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

        public async Task<Familia> Inserir(Familia familia, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            var gTrans = GerenciaTransacao(gConn.conn, transaction);
            try
            {
                familia.CodFamilia = await _rFamilia.ObterProximoIdAsync(gConn.conn, transaction);
                var codFamilia = await _rFamilia.InserirAsync(familia, gConn.conn, gTrans.transaction);

                if (codFamilia != familia.CodFamilia)
                    throw new Exception("Erro ao inserir a família.");
                if (gTrans.interna)
                    gTrans.transaction?.Commit();

                return await ObterPorId(codFamilia, gConn.conn);
            }
            catch (Exception ex)
            {
                if (gTrans.interna)
                {
                    gTrans.transaction?.Rollback();
                }

                _logger.LogError(ex, "Erro ao inserir família.");
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

        public async Task<Familia> Atualizar(Familia familia, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            var gTrans = GerenciaTransacao(gConn.conn, transaction);
            try
            {
                if (!(await _rFamilia.AtualizarAsync(familia, gConn.conn, gTrans.transaction)))
                    throw new Exception("Erro ao atualizar a família.");
                if (gTrans.interna)
                    gTrans.transaction?.Commit();

                return await ObterPorId(familia.CodFamilia, gConn.conn);
            }
            catch (Exception ex)
            {
                if (gTrans.interna)
                {
                    gTrans.transaction?.Rollback();
                }

                _logger.LogError(ex, "Erro ao atualizar família.");
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
            transaction = conn.BeginTransaction();
            if (transaction == null)
                return (true, transaction);
            else
                return (false, transaction);
        }
    }
}
