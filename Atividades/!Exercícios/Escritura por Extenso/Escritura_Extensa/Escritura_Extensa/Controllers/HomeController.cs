using System.Diagnostics;
using Escritura_Extensa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Escritura_Extensa.Controllers
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
        
        [HttpPost]
        public IActionResult ConverterNumero(string numero)
        {
            if (int.TryParse(numero, out int valor))
            {
                string numeroExtenso = ConverterParaExtenso(valor);
                ViewBag.NumeroExtenso = numeroExtenso;
            }
            else
            {
                ViewBag.NumeroExtenso = "Número inválido!";
            }

            return View("Index");
        }

        private string ConverterParaExtenso(long numero)
        {
            if (numero == 0) return "zero";

            string[] unidades = { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
            string[] dezenas = { "", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
            string[] especiais = { "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
            string[] centenas = { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

            string resultado = "";

            if (numero >= 1_000_000_000)
            {
                int bilhao = (int)(numero / 1_000_000_000);
                resultado += (bilhao == 1) ? "um bilhão" : ConverterParaExtenso(bilhao) + " bilhões";
                numero %= 1_000_000_000;
                if (numero > 0) resultado += " ";
            }

            if (numero >= 1_000_000)
            {
                int milhao = (int)(numero / 1_000_000);
                resultado += (milhao == 1) ? "um milhão" : ConverterParaExtenso(milhao) + " milhões";
                numero %= 1_000_000;
                if (numero > 0) resultado += " ";
            }

            if (numero >= 1_000)
            {
                int milhar = (int)(numero / 1_000);
                resultado += (milhar == 1) ? "mil" : ConverterParaExtenso(milhar) + " mil";
                numero %= 1_000;
                if (numero > 0) resultado += " ";
            }

            if (numero >= 100)
            {
                int centena = (int)(numero / 100);
                resultado += (centena == 1 && numero % 100 == 0) ? "cem" : centenas[centena];
                numero %= 100;
                if (numero > 0) resultado += " e ";
            }

            if (numero >= 10 && numero <= 19)
            {
                resultado += especiais[numero - 10];
                numero = 0;
            }
            else if (numero >= 20)
            {
                int dezena = (int)(numero / 10);
                resultado += dezenas[dezena];
                numero %= 10;
                if (numero > 0) resultado += " e ";
            }

            if (numero > 0)
            {
                resultado += unidades[numero];
            }

            return resultado.Trim();
        }
    }
}