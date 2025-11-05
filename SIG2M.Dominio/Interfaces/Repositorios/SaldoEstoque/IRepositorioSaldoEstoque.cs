using SIG2M.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Interfaces.Repositorios.SaldoEstoque
{
    public interface IRepositorioSaldoEstoque
    {
        Task<IEnumerable<VwSaldoEstoque>> ObterTodos(IDbConnection conn, IDbTransaction transaction = null);
        Task<IEnumerable<VwSaldoEstoque>> ObterPorAlmoxarifadoEItemAsync(string sigla, IDbConnection conn, IDbTransaction transaction = null);
    }
}
