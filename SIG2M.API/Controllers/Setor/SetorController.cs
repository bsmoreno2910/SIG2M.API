using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIG2M.Dominio.Interfaces.Servicos.Setor;

namespace SIG2M.API.Controllers.Setor
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly IServicoSetor _sSetores;
        public SetorController(IServicoSetor sSetores)
        {
            _sSetores = sSetores;
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarTodos")]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                var setores = await _sSetores.ObterTodos();
                return Ok(setores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorId")]
        public async Task<IActionResult> BuscarPorId(string sigla)
        {
            try
            {
                var setor = await _sSetores.ObterPorId(sigla);
                return Ok(setor);
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
                var setor = await _sSetores.ObterPorNome(nome);
                return Ok(setor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("v1/BuscarPorDistrito")]
        public async Task<IActionResult> BuscarPorDistrito(string distrito)
        {
            try
            {
                var setores = await _sSetores.ObterPorDistrito(distrito);
                return Ok(setores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("v1/Inserir")]
        public async Task<IActionResult> Inserir([FromBody] Dominio.Entidades.Setor setor)
        {
            try
            {
                var novoSetor = await _sSetores.Inserir(setor);
                return Ok(novoSetor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("v1/Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Dominio.Entidades.Setor setor)
        {
            try
            {
                var setorAtualizado = await _sSetores.Atualizar(setor);
                return Ok(setorAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
