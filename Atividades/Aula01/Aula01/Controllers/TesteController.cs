using Microsoft.AspNetCore.Mvc; // Name space (normalmente chamado)

namespace Aula01.Controllers
{
    public class Result
    {
        public string Texto = string.Empty;
    }
    public class TesteController : Controller // Utilizando     "Ctrl ." abre uma opção de importação para o Controller 
    {
        private readonly ILogger<TesteController> _logger; //SNAPE CASE "_logger"
        public TesteController(ILogger<TesteController> logger)
        {
            _logger = logger;
        }

        [HttpGet] // Deixando explicito que o Index vai atender o protocolo do HTTP
        public IActionResult Index()
        {
            return View("Index", new Result());
        }

        [HttpPost]
        public IActionResult Index(string texto)
        {
            Result resultado = new();
            resultado.Texto = texto.ToUpper();

            return View("Index", resultado);
        }
    }
}
