using Modelo;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public static class OrderData
    {
        public static List<Order> Orders { get; set; } = new List<Order>();
        private static int _nextId = 1;

        public static int GetNextId()
        {
            return _nextId++;
        }
    }

    public class OrderRepository
    {
        private readonly CustomerRepository _customerRepository;
        private readonly ProductRepository _productRepository;

        public OrderRepository()
        {
            _customerRepository = new CustomerRepository();
            _productRepository = new ProductRepository();
        }

        public Order Retrieve(int id)
        {
            var order = OrderData.Orders.FirstOrDefault(o => o.Id == id);

            if (order != null)
            {
                if (order.Customer.Id != null && order.Customer.Id > 0)
                {
                    order.Customer = _customerRepository.Retrieve(order.Customer.Id);
                }
                else
                {
                    order.Customer = null;
                }

                if (order.OrderItems != null)
                {
                    foreach (var item in order.OrderItems)
                    {
                        if (item.Product != null && item.Product.Id != 0)
                        {
                            item.Product = _productRepository.Retrieve(item.Product.Id);
                        }
                    }
                }
            }
            return order;
        }

        public List<Order> RetrieveByName(string name)
        {
            var allOrders = RetrieveAll();

            List<Order> ret = new();
            foreach (Order o in allOrders)
            {
                if (o.Customer != null && o.Customer.Name != null && o.Customer.Name.ToLower().Contains(name.ToLower()))
                {
                    ret.Add(o);
                }
            }
            return ret;
        }

        public List<Order> RetrieveAll()
        {
            var orders = OrderData.Orders.ToList();

            foreach (var order in orders)
            {
                if (order.Customer.Id != null && order.Customer.Id > 0)
                {
                    order.Customer = _customerRepository.Retrieve(order.Customer.Id);
                }
                else
                {
                    order.Customer = null;
                }

                if (order.OrderItems != null)
                {
                    foreach (var item in order.OrderItems)
                    {
                        if (item.Product != null && item.Product.Id != 0)
                        {
                            item.Product = _productRepository.Retrieve(item.Product.Id);
                        }
                    }
                }
            }
            return orders;
        }

        public void Save(Order order)
        {
            if (order.Id == 0)
            {
                order.Id = OrderData.GetNextId();
                int? customerId = order.Customer?.Id;
                order.Customer = null;
                order.Customer.Id = customerId; // CORREÇÃO AQUI: atribui ao CustomerId (int?), não a order.Customer.Id

                OrderData.Orders.Add(order);
            }
            else
            {
                var existingOrder = OrderData.Orders.FirstOrDefault(o => o.Id == order.Id);
                if (existingOrder != null)
                {
                    existingOrder.OrderDate = order.OrderDate;
                    existingOrder.Customer.Id = order.Customer?.Id;
                    existingOrder.ShippingAddress = order.ShippingAddress;
                    existingOrder.OrderItems = order.OrderItems;
                }
            }
        }

        public bool Delete(Order order)
        {
            return OrderData.Orders.Remove(order);
        }

        public bool DeleteById(int id)
        {
            Order order = Retrieve(id);
            if (order != null)
            {
                return Delete(order);
            }
            return false;
        }

        public void Update(Order newOrder)
        {
            Order oldOrder = Retrieve(newOrder.Id);
            if (oldOrder != null)
            {
                oldOrder.Customer = _customerRepository.Retrieve(newOrder.Customer.Id);
                oldOrder.OrderDate = newOrder.OrderDate;
                oldOrder.ShippingAddress = newOrder.ShippingAddress;
                oldOrder.OrderItems = newOrder.OrderItems;
                oldOrder.CustomerId = newOrder.Customer.Id;
            }
        }

        public int GerCount()
        {
            return OrderData.Orders.Count;
        }
    }
}
