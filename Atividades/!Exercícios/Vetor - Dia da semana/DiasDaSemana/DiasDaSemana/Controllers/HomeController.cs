using System.Diagnostics;
using DiasDaSemana.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DiasDaSemana.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult DiaDaSemana(int numero)
        {
            string[] dias = { "Segunda-feira", "Ter�a-feira", "Quarta-feira", "Quinta-feira", "Sexta-feira", "S�bado", "Domingo" };

            int hoje = (int)DateTime.Now.DayOfWeek;

            int novoDia = (hoje + numero) % 7;

            if (novoDia < 0)
            {
                novoDia += 7;
            }

            string diaDaSemana = dias[novoDia];

            return Content($"O dia da semana ser�: {diaDaSemana}");
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
    }
}
