using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Interfaces.Servicos.Grupos
{
    public interface IServicoFamilias
    {
        Task<IEnumerable<Dominio.Entidades.Familia>> ObterTodos(IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Familia> ObterPorId(short codFamilia, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Familia> ObterPorNome(string nome, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Familia>> ObterPorSubGrupo(short codSubGrupo, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Familia> Inserir(Dominio.Entidades.Familia familia, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Familia> Atualizar(Dominio.Entidades.Familia familia, IDbConnection conn = null, IDbTransaction transaction = null);
    }
}
