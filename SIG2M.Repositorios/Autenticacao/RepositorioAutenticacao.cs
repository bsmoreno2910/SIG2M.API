using Dapper;
using SIG2M.Dominio.Entidades;
using SIG2M.Dominio.Interfaces.Repositorios.Autenticacao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Repositorios.Autenticacao
{
    public class RepositorioAutenticacao : IRepositorioAutenticacao
    {

        public async Task<AutenticacaoApi> ObterPorIdAsync(int id, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.GetAsync<AutenticacaoApi>(id, transaction);
        }
        public async Task<AutenticacaoApi> ObterPorLoginSenhaAsync(string login, string password, IDbConnection conn, IDbTransaction transaction = null)
        {
            string commandText = "SELECT * FROM autenticacao_api WHERE login = @login and password = @password";
            return await conn.QueryFirstOrDefaultAsync<AutenticacaoApi>(commandText, new { login, password }, transaction);
        }
        public async Task<AutenticacaoApi> InserirAsync(AutenticacaoApi auth, IDbConnection conn, IDbTransaction transaction = null)
        {
            var id = await conn.InsertAsync<int, AutenticacaoApi>(auth, transaction);
            return await ObterPorIdAsync(id, conn, transaction);
        }
        public async Task<bool> AtualizarAsync(AutenticacaoApi auth, IDbConnection conn, IDbTransaction transaction = null)
        { 
            return await conn.UpdateAsync<AutenticacaoApi>(auth, transaction) > 0;
        }
        public async Task<bool> ExcluirAsync(int id, IDbConnection conn, IDbTransaction transaction = null)
        {
            return await conn.DeleteAsync<AutenticacaoApi>(id, transaction) > 0;
        }
    }
}
