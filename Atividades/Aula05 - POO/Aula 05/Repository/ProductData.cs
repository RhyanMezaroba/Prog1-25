using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Repository
{
    public class ProductData
    {
        public static List<Product> Product { get; set; } = []; // STATIC = independente da tela do programa, essa classe vai ter o mesmo comportamento
        public static List<Order> Orders { get; set; } = [];
        public static List<OrderItem> OrderItem { get; set; } = [];
    }
}
