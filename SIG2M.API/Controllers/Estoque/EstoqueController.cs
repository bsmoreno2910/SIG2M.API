using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIG2M.Dominio.Interfaces.Servicos.SaldoEstoque;

namespace SIG2M.API.Controllers.Estoque
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IServicoSaldoEstoque _sSaldoEstoque;
        public EstoqueController(IServicoSaldoEstoque sSaldoEstoque)
        {
            _sSaldoEstoque = sSaldoEstoque;
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarTodos")] 
        public async Task<IActionResult> BuscarTodos()
        { 
            try
            {
                var estoque = await _sSaldoEstoque.ObterTodos();
                return Ok(estoque);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorAlmoxarifado")]
        public async Task<IActionResult> BuscarPorAlmoxarifado(string sigla)
        {
            try
            {
                var estoque = await _sSaldoEstoque.ObterPorAlmoxarifadoAsync(sigla);
                return Ok(estoque);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorItem")]
        public async Task<IActionResult> BuscarPorItem(string cod_material)
        {
            try
            {
                var estoque = await _sSaldoEstoque.ObterPorItemAsync(cod_material);
                return Ok(estoque);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorAlmoxarifadoItem")]
        public async Task<IActionResult> BuscarPorAlmoxarifadoItem(string sigla, string cod_material)
        {
            try
            {
                var estoque = await _sSaldoEstoque.ObterPorAlmoxarifadoEItemAsync(sigla, cod_material);
                return Ok(estoque);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
