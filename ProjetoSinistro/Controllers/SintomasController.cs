using Microsoft.AspNetCore.Mvc;
using ProjetoSinistro.Dtos;

namespace ProjetoSinistro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SintomasController : ControllerBase
    {
        [HttpPost("identificar")]
        public IActionResult IdentificarSintomas([FromBody] IdentificarSintomasRequestDto request)
        {
            if (request?.Sintomas == null || !request.Sintomas.Any())
            {
                return BadRequest("A lista de sintomas não pode estar vazia.");
            }

            var response = new IdentificarSintomasResponseDto();

            if (request.Sintomas.Contains("dor de dente"))
            {
                response.Doenca = "Cárie";
                response.Gravidade = "Moderada";
                response.Recomendacao = "Agendar consulta com dentista especialista.";
            }
            else if (request.Sintomas.Contains("sensibilidade ao frio"))
            {
                response.Doenca = "Hipersensibilidade dentária";
                response.Gravidade = "Leve";
                response.Recomendacao = "Usar creme dental para dentes sensíveis.";
            }
            else if (request.Sintomas.Contains("sangramento nas gengivas"))
            {
                response.Doenca = "Gengivite";
                response.Gravidade = "Moderada";
                response.Recomendacao = "Visitar um dentista para limpeza.";
            }
            else
            {
                response.Doenca = "Desconhecida";
                response.Gravidade = "Não especificada";
                response.Recomendacao = "Agende uma consulta ao dentista.";
            }

            return Ok(response);
        }
    }
}
