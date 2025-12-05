using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Interfaces.Repositorios.Grade
{ 
    public interface IRepositorioGrade
    {
        // CRUD Básico
        Task<IEnumerable<Dominio.Entidades.Grade>> PedidosPendentesAsync(IDbConnection conn, IDbTransaction transaction = null);
        Task<bool> AtualizarStatusAsync(Dominio.Entidades.Grade grade, IDbConnection conn, IDbTransaction transaction = null); 

    }
}
