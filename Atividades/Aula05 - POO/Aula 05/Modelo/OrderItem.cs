using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public double Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public Address? HomeAddress { get; set; }
        public Address? WorkAddress { get; set; }
        public bool Validate()
        {
            bool isValid = true;

            // THIS. serve para fixar o item da classe, para não gerar uma ambiguidade
            isValid = (this.Id > 0) && (this.Quantity > 0) && Product != null && Product.Validate() && (PurchasePrice > 0);

            return true;
        }        
    }
}