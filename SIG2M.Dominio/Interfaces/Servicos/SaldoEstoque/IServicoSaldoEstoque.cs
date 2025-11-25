using SIG2M.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Interfaces.Servicos.SaldoEstoque
{
    public interface IServicoSaldoEstoque
    {
        Task<IEnumerable<VwSaldoEstoque>> ObterTodos();
        Task<IEnumerable<VwSaldoEstoque>> ObterPorAlmoxarifadoAsync(string sigla);
        Task<IEnumerable<VwSaldoEstoque>> ObterPorItemAsync(string cod_material);
        Task<IEnumerable<VwSaldoEstoque>> ObterPorAlmoxarifadoEItemAsync(string sigla, string cod_material);
    }
}
