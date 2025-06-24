using System;
using System.Collections.Generic;
using Modelo;

namespace Repository
{
    public class ProductData
    {
        // Propriedades estáticas
        public static List<Product> Product { get; set; } = new List<Product>();
        public static List<Order> Orders { get; set; } = new List<Order>();
        public static List<OrderItem> OrderItem { get; set; } = new List<OrderItem>();

        // Método para preencher os produtos
        public static void FillProductData()
        {
            Product.AddRange(new List<Product>
            {
                new() { Id = 1, ProductName = "Notebook Lenovo i5", Description = "Notebook com 8GB RAM e SSD 256GB", CurrentPrice = 3500.00f },
                new() { Id = 2, ProductName = "Mouse Logitech M170", Description = "Mouse sem fio, design ambidestro", CurrentPrice = 80.00f },
                new() { Id = 3, ProductName = "Teclado Mecânico Redragon", Description = "Teclado com switches blue e iluminação RGB", CurrentPrice = 250.00f },
                new() { Id = 4, ProductName = "Monitor LG 24” Full HD", Description = "Tela IPS com resolução 1920x1080", CurrentPrice = 800.00f },
                new() { Id = 5, ProductName = "HD Externo 1TB Seagate", Description = "HD portátil USB 3.0", CurrentPrice = 350.00f },
                new() { Id = 6, ProductName = "Pen Drive 64GB SanDisk", Description = "Transferência rápida USB 3.1", CurrentPrice = 70.00f },
                new() { Id = 7, ProductName = "Cadeira Gamer ThunderX3", Description = "Ergonômica, com ajuste de altura e reclinação", CurrentPrice = 1200.00f },
                new() { Id = 8, ProductName = "Roteador TP-Link Archer C6", Description = "Dual Band, MU-MIMO, 1200 Mbps", CurrentPrice = 220.00f },
                new() { Id = 9, ProductName = "Webcam Logitech C920", Description = "Full HD 1080p com microfone embutido", CurrentPrice = 430.00f },
                new() { Id = 10, ProductName = "Fonte Corsair 650W 80 Plus", Description = "Fonte de alimentação com certificação Bronze", CurrentPrice = 520.00f }
            });
        }
    }
}
