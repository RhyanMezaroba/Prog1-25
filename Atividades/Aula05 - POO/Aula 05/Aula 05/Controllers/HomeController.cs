using System.Diagnostics;
using Aula_05.Models;
using Microsoft.AspNetCore.Mvc;
using Modelo;

namespace Aula_05.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Order _order;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Customer c1 = new Customer();
            c1.Name = "Frodo";
            c1.ObjectCount++; // 1 pois é do objeto c1
            Customer.InstanceCount++; // 1 aqui contou por conta da classe

            var c2 = new Customer();
            c2.Name = "Galadria";
            c2.ObjectCount++; // 1 pois é do objeto c2
            Customer.InstanceCount++; // 2 aqui sim muda, por conta da classe

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
