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
            /* Estrutura sint�tica do IF
             * if(express�o booleana)
                 * {
                 *      Senten�a de c�digo a ser executada, caso a condi��o seja VERDADEIRA
                 * }
             * 
             * Caso o if tenha apenas uma linha de comando a ser executada na condicional, n�o � necessidade do uso das chaves
             * 
             * if(express�o booleana)
             *      Apenas um comando
            */

            string retorno = string.Empty;
            //int x = 10;
            if (x < 9) 
                retorno =  "X � maior que 9!";

            //x = 8;
            if (x > 9)
                retorno = "x � maior que 9!";
            else
                retorno = "X � menor que 9!";

            //x = 11;
            if (x == 10)
            {
                retorno = "Ora ora ";
                retorno += "X � igual a 10";
            }

            else if (x == 9)
            {
                retorno += "Hmmmmmmm ";
                retorno += "X � igual a 9!";
            }

            else if (x == 8)
            {
                retorno = "Bahhhh ";
                retorno += "X � igual a 8 tch�";
            }
            else
            { 
                retorno = "Sei l� que n�mero � X! kkkk";
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
                    retorno = "X � zero!";
                    break;
                case 1:
                    retorno = "X � um!";
                    break;
                case 2:
                    retorno = "X � dois!";
                    break;
                case 3:
                    retorno = "X � tr�s!";
                    break;
                default:
                    retorno = "X � algum n�mero imprevisto!";
                    break;
            }

            return retorno;
        }

        [HttpGet]
        public string GetFor(int x)
        {
            string retorno = string.Empty;
            /* O comando de repeti��o FOR, possui a seguinte sintaxe:
             * for(<inicializador>; <express�o condicional>; <express�o de repeti��o>)
             * {
             *      Comando a serem executados
             * }
             * Inicializador: Elemento contador Tradicionalmente utilizado o I = �ndice;
             * Express�o Condicional: Especifica o teste a ser verificado quando o loop estiver executado o n�mero definido de
             * intera��es;
             * Express�o de Repeti��o: Especifica a a��o a ser executada como a vari�vel contadora. Geralmente, um acumulo
             * ou decr�cimo (acumulador);
             */

            for (int i = 1; i <= x; i++)
            {
                //E se eu quisesse interromper o la�o caso ele fosse maior que 5

                if (i > 50)
                    break; //Comando BREAK interrompe o la�o

                //Caso eu deseje que o la�o siga em frente, for�ando-o a continuar a execu��o
                if ((i % 2) != 0)
                    continue;

                retorno += $"{i};";
            }

            return retorno;
        }

        [HttpGet]
        public string GetForeach(string color)
        {
            /* O comando foreach (para cada) � utilizado para iterar por uma sequ�ncia de items em uma cole��o, e servir como uma
             * op��o simples de repeti��o
            */

            string[] colors = { "Vermelho", "Preto", "Azul", "Amarelo", "Branco", "Azul-marinho", "Rosa", "Roxo", "Cinza"};

            string retorno = string.Empty;

            if (colors.Contains(char.ToUpper(color[0]) + color.Substring(1)))

                retorno = "A cor escolhida � v�lida!";

            else
                retorno = "Cor escolhida inv�lida!";

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
