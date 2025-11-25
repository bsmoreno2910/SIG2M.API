using Microsoft.Extensions.Logging;
using SIG2M.Dominio.Entidades;
using SIG2M.Dominio.Interfaces.Repositorios.Almoxarifado;
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
    public class ServicoGrupos : IServicoGrupos
    {
        private readonly ILogger<ServicoGrupos> _logger;
        private readonly IServicoDeConexao _conn;
        private readonly IRepositorioGrupo _rGrupo;
        public ServicoGrupos(ILogger<ServicoGrupos> logger, IServicoDeConexao conn, IRepositorioGrupo rGrupo)
        {
            _logger = logger;
            _conn = conn;
            _rGrupo = rGrupo;
        }

        public async Task<IEnumerable<Grupo>> ObterTodos(IDbConnection conn = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rGrupo.ObterTodosAsync(gConn.conn);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os grupos.");
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


        public async Task<Grupo> ObterPorId(short codGrupo, IDbConnection conn = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rGrupo.ObterPorIdAsync(codGrupo, gConn.conn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os grupos.");
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

        public async Task<Grupo> ObterPorNome(string nome, IDbConnection conn = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rGrupo.ObterPorNomeAsync(nome, gConn.conn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os grupos.");
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
        public async Task<Grupo> Inserir(Grupo grupo, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            var gTrans = GerenciaTransacao(gConn.conn, transaction);
            try
            {
                grupo.CodGrupo = await _rGrupo.ObterProximoIdAsync(gConn.conn, transaction);
                var codGrupo = await _rGrupo.InserirAsync(grupo, gConn.conn, gTrans.transaction);

                if(codGrupo != grupo.CodGrupo) 
                    throw new Exception("Erro ao inserir o grupo."); 
                if (gTrans.interna) 
                    gTrans.transaction?.Commit(); 

                return await ObterPorId(codGrupo, gConn.conn);
            }
            catch (Exception ex)
            {
                if(gTrans.interna)
                {
                    gTrans.transaction?.Rollback();
                }

                _logger.LogError(ex, "Erro ao obter todos os grupos.");
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
        public async Task<Grupo> Atualizar(Grupo grupo, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            var gTrans = GerenciaTransacao(gConn.conn, transaction);
            try
            { 
                if (!(await _rGrupo.AtualizarAsync(grupo, gConn.conn, gTrans.transaction)))
                    throw new Exception("Erro ao inserir o grupo.");
                if (gTrans.interna)
                    gTrans.transaction?.Commit();

                return await ObterPorId(grupo.CodGrupo, gConn.conn);
            }
            catch (Exception ex)
            {
                if (gTrans.interna)
                {
                    gTrans.transaction?.Rollback();
                }

                _logger.LogError(ex, "Erro ao obter todos os grupos.");
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
