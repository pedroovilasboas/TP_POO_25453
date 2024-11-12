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

        // Método para salvar o pedido no arquivo
        public void Save()
        {
            var orders = LoadOrders();
            orders.Add(this);
            SaveOrders(orders);
        }

        // Carrega pedidos do arquivo
        public static List<Order> LoadOrders()
        {
            var orders = new List<Order>();

            if (File.Exists(ordersFile))
            {
                var lines = File.ReadAllLines(ordersFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length > 4)
                    {
                        // Supondo que Client e Product tenham construtores adequados para inicializar com strings
                        var client = new Client(parts[1]);
                        var products = new List<Product>(); // Lógica para inicializar produtos
                        orders.Add(new Order(int.Parse(parts[0]), client, products, DateTime.Parse(parts[2]), parts[3]));
                    }
                }
            }

            return orders;
        }

        // Salva a lista de pedidos no arquivo
        public static void SaveOrders(List<Order> orders)
        {
            using (var writer = new StreamWriter(ordersFile))
            {
                foreach (var order in orders)
                {
                    // Escreve informações básicas dos pedidos no arquivo
                    writer.WriteLine($"{order.OrderId},{order.Client.Name},{order.OrderDate},{order.Status}");
                }
            }
        }

        // Pesquisa pedidos pelo nome do cliente ou status
        public static List<Order> SearchOrders(string query)
        {
            var orders = LoadOrders();
            query = query.ToLower();

            return orders.Where(o => o.Client.Name.ToLower().Contains(query) || o.Status.ToLower().Contains(query)).ToList();
        }

        // Atualiza o status do pedido para "Concluída"
        public static void CompleteOrder(int orderId)
        {
            var orders = LoadOrders();
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);

            if (order != null)
            {
                order.Status = "Concluída";
                SaveOrders(orders);
            }
            else
            {
                Console.WriteLine("Pedido não encontrado para conclusão.");
            }
        }
    }
}
