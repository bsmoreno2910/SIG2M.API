using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIG2M.Dominio.Entidades;
using SIG2M.Dominio.Interfaces.Servicos.Grupos;

namespace SIG2M.API.Controllers.Grupos
{

    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private readonly IServicoFamilias _sFamilias;
        public FamiliaController(IServicoFamilias sFamilias)
        {
            _sFamilias = sFamilias;
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarTodos")]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                var familias = await _sFamilias.ObterTodos(null);
                return Ok(familias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorId")]
        public async Task<IActionResult> BuscarPorId(short codFamilia)
        {
            try
            {
                var familia = await _sFamilias.ObterPorId(codFamilia, null);
                return Ok(familia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorNome")]
        public async Task<IActionResult> BuscarPorNome(string nome)
        {
            try
            {
                var familia = await _sFamilias.ObterPorNome(nome, null);
                return Ok(familia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorSubGrupo")]
        public async Task<IActionResult> BuscarPorSubGrupo(short codSubGrupo)
        {
            try
            {
                var familias = await _sFamilias.ObterPorSubGrupo(codSubGrupo, null);
                return Ok(familias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("v1/Inserir")]
        public async Task<IActionResult> Inserir([FromBody] Familia familia)
        {
            try
            {
                var novaFamilia = await _sFamilias.Inserir(familia,null);
                return Ok(novaFamilia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("v1/Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Familia familia)
        {
            try
            {
                var familiaAtualizada = await _sFamilias.Atualizar(familia, null);
                return Ok(familiaAtualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
