using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Interfaces.Servicos.Setor
{
    public interface IServicoSetor
    {
        Task<IEnumerable<Dominio.Entidades.Setor>> ObterTodos(IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Setor> ObterPorId(string sigla, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Setor> ObterPorNome(string nome, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Setor>> ObterPorDistrito(string distrito, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Setor> Inserir(Dominio.Entidades.Setor setor, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Setor> Atualizar(Dominio.Entidades.Setor setor, IDbConnection conn = null, IDbTransaction transaction = null);

    }
}
