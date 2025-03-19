using Microsoft.AspNetCore.Mvc;
using ProjetoSinistro.Models;
using ProjetoSinistro.Repositories;
using System.Threading.Tasks;

namespace ProjetoSinistro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepositorio _repositorio;

        public PacienteController(IPacienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var pacientes = await _repositorio.ObterTodosAsync();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var paciente = await _repositorio.ObterPorIdAsync(id);
            return paciente == null ? NotFound() : Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Paciente paciente)
        {
            await _repositorio.AdicionarAsync(paciente);
            return CreatedAtAction(nameof(ObterPorId), new { id = paciente.Id }, paciente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.Id) return BadRequest();
            await _repositorio.AtualizarAsync(paciente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            await _repositorio.RemoverAsync(id);
            return NoContent();
        }
    }
}
