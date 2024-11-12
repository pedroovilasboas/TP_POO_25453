using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _25453_TP_POO
{
    public class Order
    {
        // Propriedades da classe Order
        public int OrderId { get; set; }
        public Client Client { get; set; }
        public List<Product> Products { get; set; }

        // Calcula o preço total dos produtos
        public decimal TotalPrice
        {
            get
            {
                return Products.Sum(p => p.Price);
            }
        }

        public DateTime OrderDate { get; set; }
        public string Status { get; set; } // Status do pedido, e.g., "Por Enviar", "Concluída"

        // Caminho para o arquivo de pedidos
        private static string ordersFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "orders.txt");

        // Construtor para inicializar um pedido
        public Order(int orderId, Client client, List<Product> products, DateTime orderDate, string status = "Por Enviar")
        {
            OrderId = orderId;
            Client = client;
            Products = products ?? new List<Product>();
            OrderDate = orderDate;
            Status = status;
        }


    }
}
