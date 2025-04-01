using Microsoft.AspNetCore.Mvc;

namespace Aulau03.Controllers
{
    public class JogoVelhaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(
            string A00, string A01, string A02,
            string A10, string A11, string A12,
            string A20, string A21, string A22
        )
        {
            string[,] matrixJV = new string[3, 3];
            matrixJV[0, 0] = A00;
            matrixJV[1, 0] = A01;
            matrixJV[2, 0] = A02;

            matrixJV[1, 0] = A10;
            matrixJV[1, 1] = A11;
            matrixJV[1, 2] = A12;

            matrixJV[2, 0] = A20;
            matrixJV[2, 1] = A21;
            matrixJV[2, 2] = A22;

            string winner = CheckWinner(matrixJV);
            if (!string.IsNullOrEmpty(winner))
            {
                ViewData["Winner"] = $"Jogador {winner} venceu!";
            }

            return View();
        }

        [HttpGet]
        private string CheckWinner(string[,] matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                if (matrix[i, 0] == matrix[i, 1] && matrix[i, 1] == matrix[i, 2] && !string.IsNullOrEmpty(matrix[i, 0]))
                    return matrix[i, 0];
            }

            for (int j = 0; j < 3; j++)
            {
                if (matrix[0, j] == matrix[1, j] && matrix[1, j] == matrix[2, j] && !string.IsNullOrEmpty(matrix[0, j]))
                    return matrix[0, j];
            }

            if (matrix[0, 0] == matrix[1, 1] && matrix[1, 1] == matrix[2, 2] && !string.IsNullOrEmpty(matrix[0, 0]))
                return matrix[0, 0];

            if (matrix[0, 2] == matrix[1, 1] && matrix[1, 1] == matrix[2, 0] && !string.IsNullOrEmpty(matrix[0, 2]))
                return matrix[0, 2];

            return string.Empty;
        }
    }
}