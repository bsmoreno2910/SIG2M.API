using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Interfaces.Servicos.Material
{
    public interface IServicoMateriais
    {
        Task<IEnumerable<Dominio.Entidades.Material>> ObterTodos(IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Material> ObterPorId(int codMaterial, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Material> ObterPorNome(string nome, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Material>> ObterPorGrupo(short codGrupo, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Material>> ObterPorSubGrupo(short codSubGrupo, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Material>> ObterPorFamilia(short codFamilia, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Material> Inserir(Dominio.Entidades.Material material, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Material> Atualizar(Dominio.Entidades.Material material, IDbConnection conn = null, IDbTransaction transaction = null);
    }
}
