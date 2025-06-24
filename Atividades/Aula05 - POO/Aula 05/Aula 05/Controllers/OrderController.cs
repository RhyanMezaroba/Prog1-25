using Aula_05.ViewModels;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace Aula05.Controllers
{
    public class OrderController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly OrderRepository _orderRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly ProductRepository _productRepository;

        public OrderController(IWebHostEnvironment environment)
        {
            this.environment = environment;
            _orderRepository = new OrderRepository();
            _customerRepository = new CustomerRepository();
            _productRepository = new ProductRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_orderRepository.RetrieveAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            OrderViewModel viewModel = new();
            viewModel.Customers = _customerRepository.RetrieveAll();

            var products = _productRepository.RetrieveAll();
            List<SelectedItem> item = new();

            foreach (var product in products)
            {
                item.Add(new SelectedItem()
                {
                    OrderItem = new()
                    {
                        Product = product,
                        Quantity = 0,
                        PurchasePrice = 0
                    },
                    IsSelected = false
                });
            }

            viewModel.SelectedItems = item;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Customers = _customerRepository.RetrieveAll();

                if (model.SelectedItems != null)
                {
                    foreach (var item in model.SelectedItems)
                    {
                        if (item.OrderItem != null && item.OrderItem.Product != null)
                        {
                            var product = _productRepository.Retrieve(item.OrderItem.Product.Id);
                            if (product != null)
                            {
                                item.OrderItem.PurchasePrice = product.CurrentPrice * item.OrderItem.Quantity;
                            }
                        }
                    }
                }

                return View(model);
            }

            Order order = new Order();
            order.Customer = _customerRepository.Retrieve(model.CustomerId.Value);
            order.OrderDate = DateTime.Now;

            order.OrderItems = new List<OrderItem>();

            int count = 1;
            foreach (var item in model.SelectedItems.Where(si => si.IsSelected && si.OrderItem?.Quantity > 0))
            {
                var product = _productRepository.Retrieve(item.OrderItem.Product.Id);

                if (product != null)
                {
                    var newOrderItem = new OrderItem()
                    {
                        Id = count,
                        Product = product,
                        Quantity = item.OrderItem.Quantity,
                        PurchasePrice = product.CurrentPrice * item.OrderItem.Quantity
                    };

                    order.OrderItems.Add(newOrderItem);
                    count++;
                }
            }

            if (order.OrderItems.Any())
            {
                _orderRepository.Save(order);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Nenhum item válido foi selecionado para o pedido.");
                model.Customers = _customerRepository.RetrieveAll();

                return View(model);
            }
        }
    }
}
