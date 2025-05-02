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
        public string PrintDescending(int n = 10)
        {
            return PrintDescendingRecursive(n);
        }

        private string PrintDescendingRecursive(int n)
        {
            if (n < 1)
                return "";

            return $"{n} " + PrintDescendingRecursive(n - 1);
        }

        [HttpGet]
        public string SumUpTo(int n = 10)
        {
            int result = SumRecursive(n);
            return $"Soma de 1 até {n} é {result}";
        }

        private int SumRecursive(int n)
        {
            if (n <= 1)
                return n;

            return n + SumRecursive(n - 1);
        }

        [HttpGet]
        public string CountCharacters(string input = "Exemplo")
        {
            int count = CountCharsRecursive(input);
            return $"A string \"{input}\" tem {count} caracteres.";
        }

        private int CountCharsRecursive(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            return 1 + CountCharsRecursive(input.Substring(1));
        }

        [HttpGet]
        public string IsPalindrome(string word = "arara")
        {
            bool result = CheckPalindromeRecursive(word.ToLower());
            return result ? $"\"{word}\" é um palíndromo!" : $"\"{word}\" não é um palíndromo.";
        }

        private bool CheckPalindromeRecursive(string s)
        {
            if (s.Length <= 1)
                return true;

            if (s[0] != s[^1])
                return false;

            return CheckPalindromeRecursive(s.Substring(1, s.Length - 2));
        }

        public IActionResult Recursao()
        {
            return View();
        }
    }
}
