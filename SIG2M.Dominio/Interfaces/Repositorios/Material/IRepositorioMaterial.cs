using SIG2M.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Interfaces.Repositorios.Material
{

    public interface IRepositorioMaterial
    {
        // CRUD Básico
        Task<IEnumerable<Dominio.Entidades.Material>> ObterTodosAsync(IDbConnection conn, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Material> ObterPorIdAsync(int codMaterial, IDbConnection conn, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Material> ObterPorNomeAsync(string nome, IDbConnection conn, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Material>> ObterPorGrupoAsync(short codGrupo, IDbConnection conn, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Material>> ObterPorSubGrupoAsync(short codSubGrupo, IDbConnection conn, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Material>> ObterPorFamiliaAsync(short codFamilia, IDbConnection conn, IDbTransaction transaction = null);
        Task<int> InserirAsync(Dominio.Entidades.Material material, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> AtualizarAsync(Dominio.Entidades.Material material, IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> ExcluirAsync(int codMaterial, IDbConnection conn, IDbTransaction transaction = null);
    }
}
