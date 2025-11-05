using Dapper;
using SIG2M.Dominio.Entidades;
using SIG2M.Dominio.Interfaces.Repositorios.Almoxarifado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Repositorios
{
    public class RepositorioAlmoxarifado : IRepositorioAlmoxarifado
    {
        public async Task<Almoxarifado> ObterPorIdAsync(string codAlmox, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetAsync<Almoxarifado>(codAlmox, transaction);
        } 
        public async Task<Almoxarifado> ObterPorNomeAsync(string nome, IDbConnection conn, IDbTransaction transaction = null)
        {
            string commandText = "SELECT * FROM almoxarifado WHERE nome = @nome";
            return await conn.QueryFirstOrDefaultAsync<Almoxarifado>(commandText, new { nome }, transaction);
        }
        public Task<string> InserirAsync(Almoxarifado almoxarifado, IDbConnection conn, IDbTransaction transaction = null)
        {
            return conn.InsertAsync<string, Almoxarifado>(almoxarifado, transaction);
        }
        public async Task<bool> AtualizarAsync(Almoxarifado almoxarifado, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.UpdateAsync<Almoxarifado>(almoxarifado, transaction) > 0;
        }
        public async Task<bool> ExcluirAsync(string codAlmox, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.DeleteAsync<Almoxarifado>(codAlmox, transaction) > 0;
        } 
    }
}
