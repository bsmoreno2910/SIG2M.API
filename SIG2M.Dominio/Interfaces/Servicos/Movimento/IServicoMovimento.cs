using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Interfaces.Servicos.Movimento
{ 
    public interface IServicoMovimento
    {
        Task<IEnumerable<Dominio.Entidades.Movimento>> ObterTodos(IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Movimento> ObterPorId(int ano, int codMovimento, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<IEnumerable<Dominio.Entidades.Movimento>> ObterPorDocumento(long lista, int contador, IDbConnection conn = null, IDbTransaction transaction = null); 
        Task<Dominio.Entidades.Movimento> Inserir(Dominio.Entidades.Movimento material, IDbConnection conn = null, IDbTransaction transaction = null);
        Task<Dominio.Entidades.Movimento> Atualizar(Dominio.Entidades.Movimento material, IDbConnection conn = null, IDbTransaction transaction = null);
    }
}
