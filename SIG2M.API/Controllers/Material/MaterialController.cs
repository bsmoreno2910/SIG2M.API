using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIG2M.Dominio.Interfaces.Servicos.Material;

namespace SIG2M.API.Controllers.Material
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IServicoMateriais _sMateriais;
        public MaterialController(IServicoMateriais sMateriais)
        {
            _sMateriais = sMateriais;
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarTodos")]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                var materiais = await _sMateriais.ObterTodos();
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
        public async Task<IActionResult> BuscarPorId(int codMaterial)
        {
            try
            {
                var material = await _sMateriais.ObterPorId(codMaterial);
                return Ok(material);
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
                var material = await _sMateriais.ObterPorNome(nome);
                return Ok(material);
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
                var materiais = await _sMateriais.ObterPorGrupo(codGrupo);
                return Ok(materiais);
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
                var materiais = await _sMateriais.ObterPorSubGrupo(codSubGrupo);
                return Ok(materiais);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorFamilia")]
        public async Task<IActionResult> BuscarPorFamilia(short codFamilia)
        {
            try
            {
                var materiais = await _sMateriais.ObterPorFamilia(codFamilia);
                return Ok(materiais);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("v1/Inserir")]
        public async Task<IActionResult> Inserir([FromBody] Dominio.Entidades.Material material)
        {
            try
            {
                var novoMaterial = await _sMateriais.Inserir(material);
                return Ok(novoMaterial);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("v1/Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Dominio.Entidades.Material material)
        {
            try
            {
                var materialAtualizado = await _sMateriais.Atualizar(material);
                return Ok(materialAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
