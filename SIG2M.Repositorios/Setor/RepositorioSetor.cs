using Dapper;
using SIG2M.Dominio.Interfaces.Repositorios.Setor;
using System.Data;

namespace SIG2M.Repositorios.Setor
{
    public class RepositorioSetor : IRepositorioSetor
    {

        public async Task<IEnumerable<Dominio.Entidades.Setor>> ObterTodosAsync(IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<Dominio.Entidades.Setor>(transaction);
        }

        public async Task<Dominio.Entidades.Setor> ObterPorIdAsync(string sigla, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetAsync<Dominio.Entidades.Setor>(sigla, transaction);
        }

        public async Task<Dominio.Entidades.Setor> ObterPorNomeAsync(string nome, IDbConnection conn, IDbTransaction transaction = null)
        {
            string commandText = "SELECT * FROM setor WHERE nome = @nome";
            return await conn.QueryFirstOrDefaultAsync<Dominio.Entidades.Setor>(commandText, new { nome }, transaction);
        }

        public async Task<IEnumerable<Dominio.Entidades.Setor>> ObterPorDistritoAsync(string distrito, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<Dominio.Entidades.Setor>(new { Distrito = distrito }, transaction);
        }

        public Task<string> InserirAsync(Dominio.Entidades.Setor setor, IDbConnection conn, IDbTransaction transaction = null)
        {
            return conn.InsertAsync<string, Dominio.Entidades.Setor>(setor, transaction);
        }

        public async Task<bool> AtualizarAsync(Dominio.Entidades.Setor setor, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.UpdateAsync<Dominio.Entidades.Setor>(setor, transaction) > 0;
        }

        public async Task<bool> ExcluirAsync(string sigla, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.DeleteAsync<Dominio.Entidades.Setor>(sigla, transaction) > 0;
        }

    }
}
