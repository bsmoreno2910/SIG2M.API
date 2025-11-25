using Dapper;
using SIG2M.Dominio.Entidades;
using SIG2M.Dominio.Interfaces.Repositorios.Almoxarifado; 
using System.Data; 

namespace SIG2M.Repositorios.Grupos
{
    public class RepositorioGrupo : IRepositorioGrupo
    {
        public async Task<IEnumerable<Grupo>> ObterTodosAsync(IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<Grupo>(null, transaction: transaction);
        }
        public async Task<Grupo> ObterPorIdAsync(short codGrupo, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetAsync<Grupo>(codGrupo, transaction);
        } 
        public async Task<Grupo> ObterPorNomeAsync(string nome, IDbConnection conn, IDbTransaction transaction = null)
        {
            string commandText = "SELECT * FROM grupo WHERE nome = @nome";
            return await conn.QueryFirstOrDefaultAsync<Grupo>(commandText, new { nome }, transaction);
        }
        public async Task<short> ObterProximoIdAsync(IDbConnection conn, IDbTransaction transaction = null)
        {
            string commandText = "SELECT COALESCE(MAX(cod_grupo), 0) + 1 as id FROM grupo";
            return await conn.ExecuteScalarAsync<short>(commandText, transaction: transaction);
        }
        public Task<short> InserirAsync(Grupo grupo, IDbConnection conn, IDbTransaction transaction = null)
        {
            return conn.InsertAsync<short, Grupo>(grupo, transaction);
        }
        public async Task<bool> AtualizarAsync(Grupo grupo, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.UpdateAsync<Grupo>(grupo, transaction) > 0;
        }
        public async Task<bool> ExcluirAsync(short codGrupo, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.DeleteAsync<Grupo>(codGrupo, transaction) > 0;
        } 
    }
}
