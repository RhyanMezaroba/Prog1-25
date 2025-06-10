using System.Text;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;

namespace Aula_05.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly CustomerRepository _customerRepository;

        public CustomerController(IWebHostEnvironment environment)
        {
            this.environment = environment;
            _customerRepository = new CustomerRepository(); // Idealmente injetar por DI
        }

        [HttpGet]
        public IActionResult Index()
        {
            var customers = _customerRepository.RetrieveAll();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer c)
        {
            if (!ModelState.IsValid)
                return View(c);

            _customerRepository.Save(c);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null || id.Value <= 0)
                return NotFound();

            var customer = _customerRepository.Retrieve(id.Value);
            if (customer is null)
                return NotFound();

            return View(customer);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id is null || id.Value <= 0)
                return NotFound();

            if (!_customerRepository.DeleteById(id.Value))
                return NotFound();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExportDelimitatedFile()
        {
            var customers = _customerRepository.RetrieveAll();
            var fileContent = new StringBuilder();

            foreach (var c in customers)
            {
                if (c.HomeAddress == null) continue;

                fileContent.AppendLine(
                    $"{c.Id};{c.Name};{c.HomeAddress.Id};{c.HomeAddress.Street1};{c.HomeAddress.Street2};" +
                    $"{c.HomeAddress.City};{c.HomeAddress.State};{c.HomeAddress.Country};" +
                    $"{c.HomeAddress.PostalCode};{c.HomeAddress.AddressType}"
                );
            }

            SaveFile(fileContent.ToString(), "ExportDelimitatedFile.txt");
            return View();
        }

        [HttpGet]
        public IActionResult ExportFixedFile()
        {
            var customers = _customerRepository.RetrieveAll();
            var fileContent = new StringBuilder();

            foreach (var c in customers)
            {
                if (c.HomeAddress == null) continue;

                fileContent.Append(
                    c.Id.ToString("D5") +
                    c.Name.PadRight(64).Substring(0, 64) +
                    c.HomeAddress.Id.ToString("D5") +
                    c.HomeAddress.City.PadRight(32).Substring(0, 32) +
                    c.HomeAddress.State.PadRight(2).Substring(0, 2) +
                    c.HomeAddress.Country.PadRight(32).Substring(0, 32) +
                    c.HomeAddress.Street1.PadRight(64).Substring(0, 64) +
                    c.HomeAddress.Street2.PadRight(64).Substring(0, 64) +
                    c.HomeAddress.PostalCode.PadRight(9).Substring(0, 9) +
                    c.HomeAddress.AddressType.PadRight(1).Substring(0, 1) +
                    "\n"
                );
            }

            SaveFile(fileContent.ToString(), "ExportFixedFile.txt");
            return RedirectToAction("Index");
        }

        private bool SaveFile(string content, string fileName)
        {
            if (string.IsNullOrWhiteSpace(content) || string.IsNullOrWhiteSpace(fileName))
                return false;

            var path = Path.Combine(environment.WebRootPath, "TextFiles");

            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                var filepath = Path.Combine(path, fileName);

                using (StreamWriter sw = new(filepath, false)) // overwrite if exists
                {
                    sw.Write(content);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar arquivo: {ex.Message}");
                return false;
            }
        }
    }
}
