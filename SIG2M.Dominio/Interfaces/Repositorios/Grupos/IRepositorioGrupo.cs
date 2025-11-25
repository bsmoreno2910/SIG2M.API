using SIG2M.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace SIG2M.Dominio.Interfaces.Repositorios.Almoxarifado
{
    public interface IRepositorioGrupo
    {
        // CRUD Básico
        Task<IEnumerable<Grupo>> ObterTodosAsync(IDbConnection conn, IDbTransaction transaction = null);
        Task<Grupo> ObterPorIdAsync(short codGrupo, IDbConnection conn, IDbTransaction transaction = null);
        Task<Grupo> ObterPorNomeAsync(string nome, IDbConnection conn, IDbTransaction transaction = null);
        Task<short> ObterProximoIdAsync(IDbConnection conn, IDbTransaction transaction = null);
        Task<short> InserirAsync(Grupo grupo, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> AtualizarAsync(Grupo grupo, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> ExcluirAsync(short codGrupo, IDbConnection conn, IDbTransaction transaction = null);
    }
}
