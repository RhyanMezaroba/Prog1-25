using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Repository
{
    internal class OrderRepository
    {
        public Order Retrieve()
        {
            return new Order();
        }
        public void Save(Order order)
        {
        }
    }
}
