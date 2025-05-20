using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Repository
{
    internal class OrderItemRepository
    {
        public OrderItem Retrieve(int orderId)
        {
            return new OrderItem();
        }

        public List<Order> Retrieve()
        {
            return new List<Order>();
        }
        public void Save(OrderItem orderItem)
        {
        }
    }
}
