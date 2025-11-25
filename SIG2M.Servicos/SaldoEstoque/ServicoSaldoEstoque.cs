using SIG2M.Dominio.Entidades;
using SIG2M.Dominio.Interfaces.Repositorios.SaldoEstoque;
using SIG2M.Dominio.Interfaces.Servicos.Conexao;
using SIG2M.Dominio.Interfaces.Servicos.SaldoEstoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Servicos.SaldoEstoque
{
    public class ServicoSaldoEstoque : IServicoSaldoEstoque
    {
        private readonly IServicoDeConexao _conn;
        private readonly IRepositorioSaldoEstoque _rSaldoEstoque;
        public ServicoSaldoEstoque(IServicoDeConexao conn, IRepositorioSaldoEstoque rSaldoEstoque)
        {
            _conn = conn;
            _rSaldoEstoque = rSaldoEstoque;
        }

        public async Task<IEnumerable<VwSaldoEstoque>> ObterTodos()
        {
            using var conn = await _conn.ConectarAsync();
            return await _rSaldoEstoque.ObterTodos(conn);
        }
        public async Task<IEnumerable<VwSaldoEstoque>> ObterPorAlmoxarifadoAsync(string sigla)
        {
            using var conn = await _conn.ConectarAsync();
            return await _rSaldoEstoque.ObterPorAlmoxarifadoAsync(sigla, conn);
        }

        public async Task<IEnumerable<VwSaldoEstoque>> ObterPorItemAsync(string cod_material)
        {
            using var conn = await _conn.ConectarAsync();
            return await _rSaldoEstoque.ObterPorItemAsync(cod_material, conn);
        }

        public async Task<IEnumerable<VwSaldoEstoque>> ObterPorAlmoxarifadoEItemAsync(string sigla, string cod_material)
        {
            using var conn = await _conn.ConectarAsync();
            return await _rSaldoEstoque.ObterPorAlmoxarifadoEItemAsync(sigla, cod_material, conn);
        }
    }
}
