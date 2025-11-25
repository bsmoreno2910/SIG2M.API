using Microsoft.Extensions.Logging;
using SIG2M.Dominio.Interfaces.Repositorios.Material;
using SIG2M.Dominio.Interfaces.Servicos.Conexao;
using SIG2M.Dominio.Interfaces.Servicos.Material;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Servicos.Material
{
    public class ServicoMateriais : IServicoMateriais
    {
        private readonly ILogger<ServicoMateriais> _logger;
        private readonly IServicoDeConexao _conn;
        private readonly IRepositorioMaterial _rMaterial;
        public ServicoMateriais(ILogger<ServicoMateriais> logger, IServicoDeConexao conn, IRepositorioMaterial rMaterial)
        {
            _logger = logger;
            _conn = conn;
            _rMaterial = rMaterial;
        }

        public async Task<IEnumerable<Dominio.Entidades.Material>> ObterTodos(IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rMaterial.ObterTodosAsync(gConn.conn, transaction);

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


        public async Task<Dominio.Entidades.Material> ObterPorId(int codMaterial, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rMaterial.ObterPorIdAsync(codMaterial, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter material por ID.");
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

        public async Task<Dominio.Entidades.Material> ObterPorNome(string nome, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rMaterial.ObterPorNomeAsync(nome, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter material por nome.");
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

        public async Task<IEnumerable<Dominio.Entidades.Material>> ObterPorGrupo(short codGrupo, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rMaterial.ObterPorGrupoAsync(codGrupo, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter materiais por grupo.");
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

        public async Task<IEnumerable<Dominio.Entidades.Material>> ObterPorSubGrupo(short codSubGrupo, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rMaterial.ObterPorSubGrupoAsync(codSubGrupo, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter materiais por subgrupo.");
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

        public async Task<IEnumerable<Dominio.Entidades.Material>> ObterPorFamilia(short codFamilia, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            try
            {
                return await _rMaterial.ObterPorFamiliaAsync(codFamilia, gConn.conn, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter materiais por família.");
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

        public async Task<Dominio.Entidades.Material> Inserir(Dominio.Entidades.Material material, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            var gTrans = GerenciaTransacao(gConn.conn, transaction);
            try
            {
                var codMaterial = await _rMaterial.InserirAsync(material, gConn.conn, gTrans.transaction);

                if (codMaterial != material.CodMaterial)
                    throw new Exception("Erro ao inserir o material.");
                if (gTrans.interna)
                    gTrans.transaction?.Commit();

                return await ObterPorId(codMaterial, gConn.conn);
            }
            catch (Exception ex)
            {
                if (gTrans.interna)
                {
                    gTrans.transaction?.Rollback();
                }

                _logger.LogError(ex, "Erro ao inserir material.");
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

        public async Task<Dominio.Entidades.Material> Atualizar(Dominio.Entidades.Material material, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var gConn = await GerenciaConexao(conn);
            var gTrans = GerenciaTransacao(gConn.conn, transaction);
            try
            {
                if (!(await _rMaterial.AtualizarAsync(material, gConn.conn, gTrans.transaction)))
                    throw new Exception("Erro ao atualizar o material.");
                if (gTrans.interna)
                    gTrans.transaction?.Commit();

                return await ObterPorId(material.CodMaterial, gConn.conn);
            }
            catch (Exception ex)
            {
                if (gTrans.interna)
                {
                    gTrans.transaction?.Rollback();
                }

                _logger.LogError(ex, "Erro ao atualizar material.");
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
