using Dapper;
using SIG2M.Dominio.Entidades;
using SIG2M.Dominio.Interfaces.Repositorios.Movimento;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SIG2M.Repositorios.Movimento
{
    public class RepositorioMovimento : IRepositorioMovimento
    {

        public async Task<IEnumerable<Dominio.Entidades.Movimento>> ObterTodosAsync(IDbConnection conn, IDbTransaction transaction = null)
        {
            var materiais = await conn.GetListAsync<Dominio.Entidades.Movimento>(transaction); 
            return materiais;
        }
        public async Task<Dominio.Entidades.Movimento> ObterPorIdAsync(int ano, int codMovimento, IDbConnection conn, IDbTransaction transaction = null)
        {
            return (await conn.GetListAsync<Dominio.Entidades.Movimento>("WHERE ano = @ano AND cod_movimento = @codMovimento", new { ano, codMovimento }, transaction)).FirstOrDefault(); 
        }
        public async Task<IEnumerable<Dominio.Entidades.Movimento>> ObterPorDocumentoAsync(long lista, int contador, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<Dominio.Entidades.Movimento>("WHERE documento = @documento ", new { documento = $"{lista}/{contador}" }, transaction);

        }
        public async Task<int> ObterProximoIdAsync(int ano, IDbConnection conn, IDbTransaction transaction = null)
        {
            string commandText = "SELECT COALESCE(MAX(cod_movimento), 0) + 1 as id FROM movimento WHERE ano = @ano";
            return await conn.ExecuteScalarAsync<int>(commandText, new { ano }, transaction: transaction);
        }
        public async Task<int> InserirAsync(Dominio.Entidades.Movimento movimento, IDbConnection conn, IDbTransaction transaction = null)
        {
            var codMovimento = await conn.InsertAsync<int, Dominio.Entidades.Movimento>(movimento, transaction); 
            if (codMovimento > 0)
                return codMovimento;
            throw new Exception("Falha ao Inserir");
        }
        public async Task<bool> AtualizarAsync(Dominio.Entidades.Movimento movimento, IDbConnection conn, IDbTransaction transaction = null)
        {
            var resultMovimento = await conn.UpdateAsync<Dominio.Entidades.Movimento>(movimento, transaction) > 0;  
            if (resultMovimento)
                return true;
            else
                return false;
        }
        public async Task<bool> ExcluirAsync(int codMovimento, IDbConnection conn, IDbTransaction transaction = null)
        {
            var resultMovimento = await conn.DeleteAsync<Dominio.Entidades.Movimento>(codMovimento, transaction) > 0; 
            if (resultMovimento)
                return true;
            else
                return false;
        }
         
    }
}
