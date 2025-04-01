using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata.Ecma335;
using Aulau03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aulau03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string GetIf(int x)
        {
            /* Estrutura sintática do IF
             * if(expressão booleana)
                 * {
                 *      Sentença de código a ser executada, caso a condição seja VERDADEIRA
                 * }
             * 
             * Caso o if tenha apenas uma linha de comando a ser executada na condicional, não à necessidade do uso das chaves
             * 
             * if(expressão booleana)
             *      Apenas um comando
            */

            string retorno = string.Empty;
            //int x = 10;
            if (x < 9) 
                retorno =  "X é maior que 9!";

            //x = 8;
            if (x > 9)
                retorno = "x é maior que 9!";
            else
                retorno = "X é menor que 9!";

            //x = 11;
            if (x == 10)
            {
                retorno = "Ora ora ";
                retorno += "X é igual a 10";
            }

            else if (x == 9)
            {
                retorno += "Hmmmmmmm ";
                retorno += "X é igual a 9!";
            }

            else if (x == 8)
            {
                retorno = "Bahhhh ";
                retorno += "X é igual a 8 tchê";
            }
            else
            { 
                retorno = "Sei lá que número é X! kkkk";
            }

            return retorno;
        }

        [HttpGet]
        public string GetSwitch(int x)
        {
            string retorno = string.Empty;
            switch (x)
            {
                case 0:
                    retorno = "X é zero!";
                    break;
                case 1:
                    retorno = "X é um!";
                    break;
                case 2:
                    retorno = "X é dois!";
                    break;
                case 3:
                    retorno = "X é três!";
                    break;
                default:
                    retorno = "X é algum número imprevisto!";
                    break;
            }

            return retorno;
        }

        [HttpGet]
        public string GetFor(int x)
        {
            string retorno = string.Empty;
            /* O comando de repetição FOR, possui a seguinte sintaxe:
             * for(<inicializador>; <expressão condicional>; <expressão de repetição>)
             * {
             *      Comando a serem executados
             * }
             * Inicializador: Elemento contador Tradicionalmente utilizado o I = índice;
             * Expressão Condicional: Especifica o teste a ser verificado quando o loop estiver executado o número definido de
             * interações;
             * Expressão de Repetição: Especifica a ação a ser executada como a variável contadora. Geralmente, um acumulo
             * ou decrécimo (acumulador);
             */

            for (int i = 1; i <= x; i++)
            {
                //E se eu quisesse interromper o laço caso ele fosse maior que 5

                if (i > 50)
                    break; //Comando BREAK interrompe o laço

                //Caso eu deseje que o laço siga em frente, forçando-o a continuar a execução
                if ((i % 2) != 0)
                    continue;

                retorno += $"{i};";
            }

            return retorno;
        }

        [HttpGet]
        public string GetForeach(string color)
        {
            /* O comando foreach (para cada) é utilizado para iterar por uma sequência de items em uma coleção, e servir como uma
             * opção simples de repetição
            */

            string[] colors = { "Vermelho", "Preto", "Azul", "Amarelo", "Branco", "Azul-marinho", "Rosa", "Roxo", "Cinza"};

            string retorno = string.Empty;

            if (colors.Contains(char.ToUpper(color[0]) + color.Substring(1)))

                retorno = "A cor escolhida é válida!";

            else
                retorno = "Cor escolhida inválida!";

            foreach (string s in colors)
            {
                retorno += $"[{s}]";
            }

            return retorno;
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
