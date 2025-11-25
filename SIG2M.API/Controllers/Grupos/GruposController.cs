using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIG2M.Dominio.Entidades;
using SIG2M.Dominio.Interfaces.Servicos.Grupos;

namespace SIG2M.API.Controllers.Grupos
{

    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        ILogger<GrupoController> _logger;
        private readonly IServicoGrupos _sGrupos;
        private readonly IServicoSubGrupos _sSubGrupos;
        private readonly IServicoFamilias _sFamilias;
        public GrupoController(ILogger<GrupoController> logger, IServicoGrupos sGrupos, IServicoSubGrupos sSubGrupos, IServicoFamilias sFamilias)
        {
            _logger = logger;
            _sGrupos = sGrupos;
            _sSubGrupos = sSubGrupos;
            _sFamilias = sFamilias;
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarTodos")]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                var grupos = await _sGrupos.ObterTodos(null);
                foreach (var grupo in grupos)
                {
                    grupo.SubGrupos = await _sSubGrupos.ObterPorGrupo(grupo.CodGrupo);
                    foreach (var subGrupo in grupo.SubGrupos)
                    {
                        subGrupo.Familias = await _sFamilias.ObterPorSubGrupo(subGrupo.CodSubgrupo);
                    }
                }

                return Ok(grupos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorId")]
        public async Task<IActionResult> BuscarPorId(short codGrupo)
        {
            try
            {
                var grupo = await _sGrupos.ObterPorId(codGrupo, null);
                return Ok(grupo);
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
                var grupo = await _sGrupos.ObterPorNome(nome, null);
                return Ok(grupo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("v1/Inserir")]
        public async Task<IActionResult> Inserir([FromBody] Dominio.Entidades.Grupo grupo)
        {
            try
            {
                var novoGrupo = await _sGrupos.Inserir(grupo, null);
                return Ok(novoGrupo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("v1/Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Dominio.Entidades.Grupo grupo)
        {
            try
            {
                var grupoAtualizado = await _sGrupos.Atualizar(grupo, null);
                return Ok(grupoAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
