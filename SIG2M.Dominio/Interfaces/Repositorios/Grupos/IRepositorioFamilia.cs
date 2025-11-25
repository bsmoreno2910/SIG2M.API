using SIG2M.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace SIG2M.Dominio.Interfaces.Repositorios.Grupos
{
    public interface IRepositorioFamilia
    {
        // CRUD Básico
        Task<IEnumerable<Familia>> ObterTodosAsync(IDbConnection conn, IDbTransaction transaction = null);
        Task<IEnumerable<Familia>> ObterPorSubGrupoAsync(short codSubgrupo, IDbConnection conn, IDbTransaction transaction = null);
        Task<Familia> ObterPorIdAsync(short codFamilia, IDbConnection conn, IDbTransaction transaction = null);
        Task<Familia> ObterPorNomeAsync(string nome, IDbConnection conn, IDbTransaction transaction = null);
        Task<short> ObterProximoIdAsync(IDbConnection conn, IDbTransaction transaction = null);
        Task<short> InserirAsync(Familia familia, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> AtualizarAsync(Familia familia, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> ExcluirAsync(short codFamilia, IDbConnection conn, IDbTransaction transaction = null);
    }
}
