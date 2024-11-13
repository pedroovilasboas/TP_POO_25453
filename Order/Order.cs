using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _25453_TP_POO
{
    public class Order
    {
        // Order class attributes
        public int OrderId { get; set; }
        public Client Client { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal TotalPrice { get; private set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        // File path for orders.txt for persistence
        private static string ordersFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Order\orders.txt");

        // Constructor
        public Order(int orderId, Client client, DateTime orderDate, string status = "To Ship")
        {
            OrderId = orderId;
            Client = client;
            OrderDate = orderDate;
            Status = status;
            CalculateTotal();
        }

        // Method to add a product to the order
        public void AddProduct(Product product)
        {
            Products.Add(product);
            CalculateTotal();
        }

        // Method to calculate the total price of the order
        public void CalculateTotal()
        {
            TotalPrice = Products.Sum(p => p.Price);
        }

        // Method to update the order status
        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
        }

        // Method to save the order to file
        public void Save()
        {
            var orders = LoadOrders();
            orders.Add(this);
            SaveOrders(orders);
        }

        // Method to load orders from file
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

        // Method to save a list of orders to file
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

        // Method to update an existing order
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

        // Method to delete an order by ID
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
