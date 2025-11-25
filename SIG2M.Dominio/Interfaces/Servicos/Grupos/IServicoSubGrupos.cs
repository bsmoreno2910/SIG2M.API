using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Interfaces.Servicos.Grupos
{
    public interface IServicoSubGrupos
    {
        Task<IEnumerable<Dominio.Entidades.Subgrupo>> ObterTodos(IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Subgrupo> ObterPorId(short codSubGrupo, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Subgrupo> ObterPorNome(string nome, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Subgrupo>> ObterPorGrupo(short codGrupo, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Subgrupo> Inserir(Dominio.Entidades.Subgrupo subGrupo, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Subgrupo> Atualizar(Dominio.Entidades.Subgrupo subGrupo, IDbConnection conn = null, IDbTransaction transaction = null);

    }
}
