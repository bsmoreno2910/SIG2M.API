using Dapper;
using SIG2M.Dominio.Entidades;
using SIG2M.Dominio.Interfaces.Repositorios.Almoxarifado;
using SIG2M.Dominio.Interfaces.Repositorios.Grupos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Repositorios.Grupos
{
    public class RepositorioFamilia : IRepositorioFamilia
    {

        public async Task<IEnumerable<Familia>> ObterTodosAsync(IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<Familia>(transaction);
        }

        public async Task<IEnumerable<Familia>> ObterPorSubGrupoAsync(short codSubgrupo, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<Familia>(new { CodSubgrupo = codSubgrupo }, transaction);
        }
        public async Task<Familia> ObterPorIdAsync(short codFamilia, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetAsync<Familia>(codFamilia, transaction);
        } 
        public async Task<Familia> ObterPorNomeAsync(string nome, IDbConnection conn, IDbTransaction transaction = null)
        {
            string commandText = "SELECT * FROM familia WHERE nome = @nome";
            return await conn.QueryFirstOrDefaultAsync<Familia>(commandText, new { nome }, transaction);
        }
        public async Task<short> ObterProximoIdAsync(IDbConnection conn, IDbTransaction transaction = null)
        {
            string commandText = "SELECT COALESCE(MAX(cod_familia), 0) + 1 as id FROM familia";
            return await conn.ExecuteScalarAsync<short>(commandText, transaction: transaction);
        }
        public Task<short> InserirAsync(Familia familia, IDbConnection conn, IDbTransaction transaction = null)
        {
            return conn.InsertAsync<short, Familia>(familia, transaction);
        }
        public async Task<bool> AtualizarAsync(Familia familia, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.UpdateAsync<Familia>(familia, transaction) > 0;
        }
        public async Task<bool> ExcluirAsync(short codFamilia, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.DeleteAsync<Familia>(codFamilia, transaction) > 0;
        }
         
    }
}
