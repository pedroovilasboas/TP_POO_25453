using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _25453_TP_POO
{
    public class Order
    {
        // Atributos da classe Order
        public int OrderId { get; set; }
        public Client Client { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal TotalPrice { get; private set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        // Caminho para o arquivo orders.txt para persistência
        private static string ordersFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Order\orders.txt");

        // Construtor
        public Order(int orderId, Client client, DateTime orderDate, string status = "Por Enviar")
        {
            OrderId = orderId;
            Client = client;
            OrderDate = orderDate;
            Status = status;
            CalculateTotal();
        }

        // Método para adicionar produto ao pedido
        public void AddProduct(Product product)
        {
            Products.Add(product);
            CalculateTotal();
        }

        // Método para calcular o preço total do pedido
        public void CalculateTotal()
        {
            TotalPrice = Products.Sum(p => p.Price);
        }

        // Método para atualizar o status do pedido
        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
        }

        // Método para salvar pedido no arquivo
        public void Save()
        {
            var orders = LoadOrders();
            orders.Add(this);
            SaveOrders(orders);
        }

        // Método para carregar pedidos a partir do arquivo
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
                        int orderId = int.Parse(parts[0]);
                        var client = new Client(parts[1]);
                        DateTime orderDate = DateTime.Parse(parts[2]);
                        string status = parts[3];

                        var order = new Order(orderId, client, orderDate, status);
                        orders.Add(order);
                    }
                }
            }

            return orders;
        }

        // Método para salvar uma lista de pedidos no arquivo
        public static void SaveOrders(List<Order> orders)
        {
            using (var writer = new StreamWriter(ordersFile))
            {
                foreach (var order in orders)
                {
                    writer.WriteLine($"{order.OrderId},{order.Client},{order.OrderDate},{order.Status}");
                }
            }
        }

        // Método para atualizar um pedido
        public static void UpdateOrder(Order updatedOrder)
        {
            var orders = LoadOrders();
            var index = orders.FindIndex(o => o.OrderId == updatedOrder.OrderId);

            if (index != -1)
            {
                orders[index] = updatedOrder;
                SaveOrders(orders);
            }
        }

        // Método para eliminar um pedido
        public static void DeleteOrder(int orderId)
        {
            var orders = LoadOrders();
            var orderToDelete = orders.FirstOrDefault(o => o.OrderId == orderId);

            if (orderToDelete != null)
            {
                orders.Remove(orderToDelete);
                SaveOrders(orders);
            }
        }
    }
}

