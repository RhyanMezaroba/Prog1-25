using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Recursividade_Palíndromo.Models;

namespace Recursividade_Palíndromo.Controllers
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
        public string Recursividade(int n = 10) // colocando VOID na função se torna vazia
        {
            string retorno = string.Empty;

            int i = 1;
            while (i <= n) // meu FLAG, minha determinação para continuar o laço
            {
                retorno += $" {i} "; // Acumulador
                i++; //Contador. Sem ele seria um laço infinito
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
            if (count < 1)
                return $" {n} ";

            ret += $" {count} ";
            count--; //Decrement count

            //Chamada recursiva: Incrementa N e Decrementa count, para imprimir o número
            ret += NaturalNumberRecursion(n + 1, count);

            return ret;
        }
    }
}