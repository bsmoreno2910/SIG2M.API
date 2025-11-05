using SIG2M.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Interfaces.Repositorios.Autenticacao
{
    public interface IRepositorioAutenticacao
    {
        Task<AutenticacaoApi> ObterPorIdAsync(int id, IDbConnection conn, IDbTransaction transaction = null);
        Task<AutenticacaoApi> ObterPorLoginSenhaAsync(string login, string password, IDbConnection conn, IDbTransaction transaction = null);
        Task<AutenticacaoApi> InserirAsync(AutenticacaoApi auth, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> AtualizarAsync(AutenticacaoApi auth, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> ExcluirAsync(int id, IDbConnection conn, IDbTransaction transaction = null);

    }
}
