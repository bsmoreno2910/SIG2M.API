using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIG2M.Dominio.Interfaces.Servicos.Movimento;

namespace SIG2M.API.Controllers.Movimento
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoController : ControllerBase
    {
        private readonly IServicoMovimento _sMovimento;
        public MovimentoController(IServicoMovimento sMovimento)
        {
            _sMovimento = sMovimento;
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarTodos")]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                var materiais = await _sMovimento.ObterTodos();
                return Ok(materiais);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorId")]
        public async Task<IActionResult> BuscarPorId(int ano, int codMovimento)
        {
            try
            {
                var movimento = await _sMovimento.ObterPorId(ano, codMovimento);
                return Ok(movimento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorDocumento")]
        public async Task<IActionResult> BuscarPorDocumento(long lista, int contador)
        {
            try
            {
                var movimento = await _sMovimento.ObterPorDocumento(lista, contador);
                return Ok(movimento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }   

        [HttpPost]
        [Authorize]
        [Route("v1/Inserir")]
        public async Task<IActionResult> Inserir([FromBody] Dominio.Entidades.Movimento movimento)
        {
            try
            {
                var novoMovimento = await _sMovimento.Inserir(movimento);
                return Ok(novoMovimento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("v1/Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Dominio.Entidades.Movimento movimento)
        {
            try
            {
                var movimentoAtualizado = await _sMovimento.Atualizar(movimento);
                return Ok(movimentoAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
