using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Repository
{
    internal class CustomerRepository
    {
        public Customer Retrieve()
        {
            return new Customer();
        }
        public void Save(Customer customer)
        {
        }
    }
}
