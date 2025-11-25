using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Interfaces.Servicos.Expedicao
{
    public interface IServicoExpedicoes
    {
        Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterTodos(IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Expedicao> ObterPorId(long lista, int contador, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterPorLista(long lista, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterPorMaterial(int codMaterial, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Expedicao>> ObterPorSetor(string sigla, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Expedicao> Inserir(Dominio.Entidades.Expedicao expedicao, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Expedicao> Atualizar(Dominio.Entidades.Expedicao expedicao, IDbConnection conn = null, IDbTransaction transaction = null);
    }
}
