using Microsoft.AspNetCore.Mvc;
using static Controle_Veterinário.Models.VeterinariaModel;

namespace Controle_Veterinário.Controllers
{
    public class VeterinariaController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class AtendimentosController : ControllerBase
        {
            [HttpPost("registrar")]
            public IActionResult RegistrarAtendimento([FromBody] Atendimento atendimento)
            {
                return Ok("Atendimento registrado com sucesso.");
            }

            [HttpGet("historico")]
            public IActionResult BuscarAtendimentos(
                [FromQuery] int? animalId,
                [FromQuery] int? veterinarioId,
                [FromQuery] DateTime? inicio,
                [FromQuery] DateTime? fim)
            {
                return Ok("Lista de atendimentos filtrados.");
            }
        }

    }
}
