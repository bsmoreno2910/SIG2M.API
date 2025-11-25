using Dapper;
using SIG2M.Dominio.Interfaces.Repositorios.Expedicao;
using System.Data;

namespace SIG2M.Repositorios.Expedicao
{
    public class RepositorioExpedicao : IRepositorioExpedicao
    {

        public async Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterTodosAsync(IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<Dominio.Entidades.Expedicao>(transaction);
        }

        public async Task<Dominio.Entidades.Expedicao> ObterPorIdAsync(long lista, int contador, IDbConnection conn, IDbTransaction transaction = null)
        { 
            return (await conn.GetListAsync<Dominio.Entidades.Expedicao>("WHERE lista = @lista AND contador = @contador", new { lista, contador }, transaction)).FirstOrDefault();
        }

        public async Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterPorListaAsync(long lista, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<Dominio.Entidades.Expedicao>(new { Lista = lista }, transaction);
        }

        public async Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterPorMaterialAsync(int codMaterial, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<Dominio.Entidades.Expedicao>(new { CodMaterial = codMaterial }, transaction);
        }

        public async Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterPorSetorAsync(string sigla, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<Dominio.Entidades.Expedicao>(new { Sigla = sigla }, transaction);
        }

        public async Task<bool> InserirAsync(Dominio.Entidades.Expedicao expedicao, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.InsertAsync<long, Dominio.Entidades.Expedicao>(expedicao, transaction) > 0;
        }

        public async Task<bool> AtualizarAsync(Dominio.Entidades.Expedicao expedicao, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.UpdateAsync<Dominio.Entidades.Expedicao>(expedicao, transaction) > 0;
        }

        public async Task<bool> ExcluirAsync(long lista, int contador, IDbConnection conn, IDbTransaction transaction = null)
        {
            string commandText = "DELETE FROM expedicao WHERE lista = @lista AND contador = @contador";
            return await conn.ExecuteAsync(commandText, new { lista, contador }, transaction) > 0;
        }

    }
}
