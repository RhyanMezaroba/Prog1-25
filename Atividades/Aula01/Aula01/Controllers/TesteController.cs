using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aula01.Controllers
{
    public class Result
    {
        public string Texto { get; set; } = string.Empty;
    }

    public class TesteController : Controller
    {
        private readonly ILogger<TesteController> _logger;

        public TesteController(ILogger<TesteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", new Result());
        }

        [HttpPost]
        public IActionResult Index(string texto)
        {
            Result resultado = new();
            resultado.Texto = CifraDeCesar(texto, 3); // Aplica a Cifra de César com deslocamento de 3

            return View("Index", resultado);
        }

        private string CifraDeCesar(string texto, int deslocamento)
        {
            char[] buffer = texto.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letra = buffer[i];

                if (char.IsLetter(letra))
                {
                    char limite = char.IsUpper(letra) ? 'A' : 'a';
                    letra = (char)(limite + (letra - limite + deslocamento) % 26);
                }

                buffer[i] = letra;
            }

            return new string(buffer);
        }
    }
}
