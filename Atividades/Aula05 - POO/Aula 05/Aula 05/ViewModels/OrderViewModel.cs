using Modelo;

namespace Aula_05.ViewModels
{
    public class OrderViewModel
    {
        public List<Customer> Customers { get; set; } = [];
        public int? CustomerId { get; set; }
        public List<SelectedItem>? SelectedItems { get; set; }
    }
    public class SelectedItem
    { 
        public bool IsSelected { get; set; } = false; //aqui o booleano inicia como falso sem ter "false", ou seja, ó fru fru pra não se perder
        public OrderItem? OrderItem { get; set; } = null!;
    }
}
