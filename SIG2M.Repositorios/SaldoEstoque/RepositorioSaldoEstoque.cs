using Dapper;
using SIG2M.Dominio.Entidades;
using SIG2M.Dominio.Interfaces.Repositorios.SaldoEstoque;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Repositorios.SaldoEstoque
{
    public class RepositorioSaldoEstoque : IRepositorioSaldoEstoque
    {
        public async Task<IEnumerable<VwSaldoEstoque>> ObterTodos(IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<VwSaldoEstoque>(null, transaction: transaction);
        }
        public async Task<IEnumerable<VwSaldoEstoque>> ObterPorAlmoxarifadoAsync(string sigla, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<VwSaldoEstoque>(new { sigla }, transaction: transaction);
        }
        public async Task<IEnumerable<VwSaldoEstoque>> ObterPorItemAsync(string cod_material, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<VwSaldoEstoque>(new { cod_material }, transaction: transaction);
        }

        public async Task<IEnumerable<VwSaldoEstoque>> ObterPorAlmoxarifadoEItemAsync(string sigla, string cod_material, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetListAsync<VwSaldoEstoque>(new { sigla, cod_material }, transaction: transaction);
        }
    }
}
