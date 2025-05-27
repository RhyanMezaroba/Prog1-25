using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Repository
{
    public class CustomerData
    {
        public static List<Customer> Customer { get; set; } = []; // STATIC = independente da tela do programa, essa classe vai ter o mesmo comportamento
        public static List<Product> Products { get; set; } = [];
        public static List<Order> Orders { get; set; } = [];
    }
}
