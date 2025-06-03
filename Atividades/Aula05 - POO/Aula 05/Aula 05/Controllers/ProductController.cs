using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;

namespace Aula_05.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly ProductRepository _productRepository;

        public ProductController(IWebHostEnvironment environment)
        {
            _productRepository = new ProductRepository();
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> product = _productRepository.RetrieveAll();
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(Product c)
        {
            _productRepository.Save(c);
            List<Product> product = _productRepository.RetrieveAll();
            return View("Index", product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExportDeLimitatedFile()
        {
            string fileContent = String.Empty;
            foreach (Product c in _productRepository.RetrieveAll())
            {
                fileContent += $"{c.Id}, {c.ProductName}, {c.Description}, {c.CurrentPrice}\n";
            }

            var path = Path.Combine(environment.WebRootPath, "TextFiles");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var filepath = Path.Combine(path, "Delimitado.txt");

            if (!System.IO.File.Exists(filepath))
            {
                using (StreamWriter sw = System.IO.File.CreateText(filepath))
                {
                    sw.Write(fileContent);
                }
            }

            return View(); // View chamada: ExportDeLimitatedFile.cshtml
        }
    }
}
