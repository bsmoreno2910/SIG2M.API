using SIG2M.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace SIG2M.Dominio.Interfaces.Repositorios.Setor
{
    public interface IRepositorioSetor
    {
        // CRUD Básico
        Task<IEnumerable<Dominio.Entidades.Setor>> ObterTodosAsync(IDbConnection conn, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Setor> ObterPorIdAsync(string sigla, IDbConnection conn, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Setor> ObterPorNomeAsync(string nome, IDbConnection conn, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Setor>> ObterPorDistritoAsync(string distrito, IDbConnection conn, IDbTransaction transaction = null);
        Task<string> InserirAsync(Dominio.Entidades.Setor setor, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> AtualizarAsync(Dominio.Entidades.Setor setor, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> ExcluirAsync(string sigla, IDbConnection conn, IDbTransaction transaction = null);
    }
}
