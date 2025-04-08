using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using Aula04___Recursividade.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula04___Recursividade.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public string PrintNaturalFor(int n = 10) // colocando VOID na fun��o se torna vazia
        {
            string retorno = string.Empty;

            int i = 1;
            while (i <= n) // meu FLAG, minha determina��o para continuar o la�o
            {
                retorno += $" {i} "; // Acumulador
                i++; //Contador. Sem ele seria um la�o infinito
            }

            return retorno;
        }

        public string PrintNaturalRecursion(int count = 10)
        {
            string retorno = "";

            retorno = NaturalNumberRecursion(1, count);

            return retorno;
        }

        public string NaturalNumberRecursion(int n, int count)
        {
            string ret = string.Empty;

            //Caso Base: Se o contador for menor que 1
            if(count < 1)
                return $" {n} ";

            ret += $" {count} ";
            count--; //Decrement count

            //Chamada recursiva: Incrementa N e Decrementa count, para imprimir o n�mero
            ret += NaturalNumberRecursion(n + 1, count);

            return ret;
        }

    }
}
