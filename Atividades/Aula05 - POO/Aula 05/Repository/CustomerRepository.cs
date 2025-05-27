using Modelo;

namespace Repository
{
    public class CustomerRepository
    {
        public Customer Retrieve(int id)
        {
            foreach(Customer c in CustomerData.Customer)
                if (c.Id == id)
                    return c;

            return null!;
        }

        public List<Customer> RetrieveByName(string name)
        {
            List<Customer> ret = new List<Customer>();

            foreach(Customer c in CustomerData.Customer)
                if(c.Name!.ToLower().Contains(name.ToLower())) // .TOLOWER para fazer a comparação em minúsculo nos dois
                    ret.Add(c);

            return ret;
        }

        public List<Customer> RetrieveAll()
        {
            return CustomerData.Customer;
        }

        public void Save(Customer customer)
        {
            customer.Id = GerCount() + 1;
            CustomerData.Customer.Add(customer);
        }

        public bool Delete(Customer customer)
        {
            return CustomerData.Customer.Remove(customer);
        }

        public bool DeleteById(int id)
        {
            Customer customer = Retrieve(id);
            
            if(customer != null)
               return Delete(customer);

            return false;
        }

        public void Update(Customer newCustomer)
        {
            Customer oldCustomer = Retrieve(newCustomer.Id);
            oldCustomer.Name = newCustomer.Name;
            oldCustomer.WorkAddress = newCustomer.WorkAddress;
            oldCustomer.HomeAddress = newCustomer.HomeAddress;
        }

        public int GerCount()
        {
            return CustomerData.Customer.Count;
        }
    }
}
