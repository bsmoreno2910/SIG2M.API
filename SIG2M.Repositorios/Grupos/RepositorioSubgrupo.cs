using Dapper;
using SIG2M.Dominio.Entidades; 
using SIG2M.Dominio.Interfaces.Repositorios.Grupos; 
using System.Data; 

namespace SIG2M.Repositorios.Grupos
{
    public class RepositorioSubgrupo : IRepositorioSubgrupo
    {
        public async Task<IEnumerable<Subgrupo>> ObterTodosAsync(IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<Subgrupo>(transaction);
        }

        public async Task<IEnumerable<Subgrupo>> ObterPorGrupoAsync(short codGrupo, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<Subgrupo>(new { CodGrupo = codGrupo }, transaction);
        }
        public async Task<Subgrupo> ObterPorIdAsync(short codSubgrupo, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetAsync<Subgrupo>(codSubgrupo, transaction);
        } 
        public async Task<Subgrupo> ObterPorNomeAsync(string nome, IDbConnection conn, IDbTransaction transaction = null)
        {
            string commandText = "SELECT * FROM subgrupo WHERE nome = @nome";
            return await conn.QueryFirstOrDefaultAsync<Subgrupo>(commandText, new { nome }, transaction);
        }
        public async Task<short> ObterProximoIdAsync(IDbConnection conn, IDbTransaction transaction = null)
        {
            string commandText = "SELECT COALESCE(MAX(cod_subgrupo), 0) + 1 as id FROM subgrupo";
            return await conn.ExecuteScalarAsync<short>(commandText, transaction: transaction);
        }
        public Task<short> InserirAsync(Subgrupo subgrupo, IDbConnection conn, IDbTransaction transaction = null)
        {
            return conn.InsertAsync<short, Subgrupo>(subgrupo, transaction);
        }
        public async Task<bool> AtualizarAsync(Subgrupo subgrupo, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.UpdateAsync<Subgrupo>(subgrupo, transaction) > 0;
        }
        public async Task<bool> ExcluirAsync(short codSubgrupo, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.DeleteAsync<Subgrupo>(codSubgrupo, transaction) > 0;
        } 
    }
}
