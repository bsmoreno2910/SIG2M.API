using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIG2M.Dominio.Entidades;
using SIG2M.Dominio.Interfaces.Servicos.Grupos;

namespace SIG2M.API.Controllers.Grupos
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubGrupoController : ControllerBase
    {
        private readonly IServicoSubGrupos _sSubGrupos;
        public SubGrupoController(IServicoSubGrupos sSubGrupos)
        {
            _sSubGrupos = sSubGrupos;
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarTodos")]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                var subgrupos = await _sSubGrupos.ObterTodos(null);
                return Ok(subgrupos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorId")]
        public async Task<IActionResult> BuscarPorId(short codSubGrupo)
        {
            try
            {
                var subgrupo = await _sSubGrupos.ObterPorId(codSubGrupo, null);
                return Ok(subgrupo);
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
                var subgrupo = await _sSubGrupos.ObterPorNome(nome, null);
                return Ok(subgrupo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorGrupo")]
        public async Task<IActionResult> BuscarPorGrupo(short codGrupo)
        {
            try
            {
                var subgrupos = await _sSubGrupos.ObterPorGrupo(codGrupo, null);
                return Ok(subgrupos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("v1/Inserir")]
        public async Task<IActionResult> Inserir([FromBody] Subgrupo subgrupo)
        {
            try
            {
                var novoSubgrupo = await _sSubGrupos.Inserir(subgrupo, null);
                return Ok(novoSubgrupo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("v1/Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Subgrupo subgrupo)
        {
            try
            {
                var subgrupoAtualizado = await _sSubGrupos.Atualizar(subgrupo, null);
                return Ok(subgrupoAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
