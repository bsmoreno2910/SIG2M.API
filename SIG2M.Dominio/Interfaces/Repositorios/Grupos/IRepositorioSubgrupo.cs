using SIG2M.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Interfaces.Repositorios.Grupos
{
    public interface IRepositorioSubgrupo
    {
        // CRUD Básico
        Task<IEnumerable<Subgrupo>> ObterTodosAsync(IDbConnection conn, IDbTransaction transaction = null);
        Task<IEnumerable<Subgrupo>> ObterPorGrupoAsync(short codGrupo, IDbConnection conn, IDbTransaction transaction = null);
        Task<Subgrupo> ObterPorIdAsync(short codSubgrupo, IDbConnection conn, IDbTransaction transaction = null);
        Task<Subgrupo> ObterPorNomeAsync(string nome, IDbConnection conn, IDbTransaction transaction = null);
        Task<short> ObterProximoIdAsync(IDbConnection conn, IDbTransaction transaction = null);
        Task<short> InserirAsync(Subgrupo subgrupo, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> AtualizarAsync(Subgrupo subgrupo, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> ExcluirAsync(short codSubgrupo, IDbConnection conn, IDbTransaction transaction = null);
    }
}
