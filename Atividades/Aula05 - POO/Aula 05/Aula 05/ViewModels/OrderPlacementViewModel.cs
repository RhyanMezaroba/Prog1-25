using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Aula05.ViewModels
{
    public class OrderPlacementViewModel
    {
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Selecione um cliente.")]
        public int SelectedCustomerId { get; set; }
        public List<SelectListItem> Customers { get; set; } = new List<SelectListItem>();

        [Display(Name = "Produto")]
        public int? SelectedProductIdToAdd { get; set; }
        public List<SelectListItem> AvailableProducts { get; set; } = new List<SelectListItem>();

        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();

        [Display(Name = "Valor Total")]
        public decimal TotalOrderValue { get; set; }

        public string ShippingAddress { get; set; }
    }
}