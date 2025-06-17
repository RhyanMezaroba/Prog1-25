using Modelo;

namespace Repository
{
    public class OrderRepository
    {
        public Order Retrieve(int id)
        {
            foreach (Order c in CustomerData.Orders)
                if (c.Id == id)
                    return c;

            return null!;
        }

        public List<Order> RetrieveByName(string name)
        {
            List<Order> ret = [];

            foreach (Order o in CustomerData.Orders)
                if (o.Customer!.Name!.ToLower().Contains(name.ToLower())) // .TOLOWER para fazer a comparação em minúsculo nos dois
                    ret.Add(o);

            return ret;
        }

        public List<Order> RetrieveAll()
        {
            return CustomerData.Orders;
        }

        public void Save(Order order)
        {
            order.Id = GerCount() + 1;
            CustomerData.Orders.Add(order);
        }

        public bool Delete(Order order)
        {
            return CustomerData.Orders.Remove(order);
        }

        public bool DeleteById(int id)
        {
            Order order = Retrieve(id);

            if (order != null)
                return Delete(order);

            return false;
        }

        public void Update(Order newOrder)
        {
            Order oldOrder = Retrieve(newOrder.Id);
            oldOrder.Customer = newOrder.Customer;
            oldOrder.OrderDate = newOrder.OrderDate;
            oldOrder.ShippingAddress = newOrder.ShippingAddress;
            oldOrder.OrderItems = newOrder.OrderItems;
        }

        public int GerCount()
        {
            return CustomerData.Orders.Count;
        }
    }
}
