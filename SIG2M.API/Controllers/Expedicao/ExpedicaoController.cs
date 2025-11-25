using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIG2M.Dominio.Interfaces.Servicos.Expedicao;

namespace SIG2M.API.Controllers.Expedicao
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedicaoController : ControllerBase
    {
        private readonly IServicoExpedicoes _sExpedicoes;
        public ExpedicaoController(IServicoExpedicoes sExpedicoes)
        {
            _sExpedicoes = sExpedicoes;
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarTodos")]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                var expedicoes = await _sExpedicoes.ObterTodos();
                return Ok(expedicoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorId")]
        public async Task<IActionResult> BuscarPorId(long lista, int contador)
        {
            try
            {
                var expedicao = await _sExpedicoes.ObterPorId(lista, contador);
                return Ok(expedicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorLista")]
        public async Task<IActionResult> BuscarPorLista(long lista)
        {
            try
            {
                var expedicoes = await _sExpedicoes.ObterPorLista(lista);
                return Ok(expedicoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorMaterial")]
        public async Task<IActionResult> BuscarPorMaterial(int codMaterial)
        {
            try
            {
                var expedicoes = await _sExpedicoes.ObterPorMaterial(codMaterial);
                return Ok(expedicoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorSetor")]
        public async Task<IActionResult> BuscarPorSetor(string sigla)
        {
            try
            {
                var expedicoes = await _sExpedicoes.ObterPorSetor(sigla);
                return Ok(expedicoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("v1/Inserir")]
        public async Task<IActionResult> Inserir([FromBody] Dominio.Entidades.Expedicao expedicao)
        {
            try
            {
                var novaExpedicao = await _sExpedicoes.Inserir(expedicao);
                return Ok(novaExpedicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("v1/Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Dominio.Entidades.Expedicao expedicao)
        {
            try
            {
                var expedicaoAtualizada = await _sExpedicoes.Atualizar(expedicao);
                return Ok(expedicaoAtualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
