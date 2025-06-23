using System.ComponentModel.DataAnnotations;

namespace Aula05.ViewModels
{
    public class OrderItemViewModel
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório meu caro.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero seu maluco.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória, sem nada é complicado.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero monte kkkkk.")]
        public int Quantity { get; set; }

        public bool IsSelected { get; set; }

        public decimal TotalItemValue => Price * Quantity;
    }
}