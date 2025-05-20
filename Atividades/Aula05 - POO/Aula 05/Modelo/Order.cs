using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Order
    {
        //Criando pontos de regiões
        #region Atributos
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public Address? ShippingAddress { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
        #endregion

        public Order() // <== ORDER
        {
            OrderDate = DateTime.Now;
            OrderItems = new List<OrderItem>();
        }

        public Order(int orderId, Address address) : this() // : this() faz erferência para ORDER 
        {
            this.Id = orderId;
            this.ShippingAddress = new Address
            {
                Street = $"Endereço {orderId}"
            };
        }

        public bool Validate()
        {
            bool isValid = true;

            if (Customer == null)
            {
                isValid = false;
                Console.WriteLine("Erro: Cliente não pode ser nulo.");
            }

            if (ShippingAddress == null || string.IsNullOrWhiteSpace(ShippingAddress.Street))
            {
                isValid = false;
                Console.WriteLine("Erro: Endereço de entrega é obrigatório.");
            }

            if (OrderItems == null || !OrderItems.Any())
            {
                isValid = false;
                Console.WriteLine("Erro: O pedido deve conter pelo menos um item.");
            }

            return isValid;
        }
    }
}
