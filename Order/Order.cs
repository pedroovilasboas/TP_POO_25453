using System;
using System.Collections.Generic;
using System.IO;

namespace _25453_TP_POO
{
    public class Order
    {
        // Properties of the Order class
        public int OrderId { get; set; }
        public Client Client { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        // Path to the orders.txt file
        private static string ordersFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Order\orders.txt");

        // Constructor to initialize an Order object
        public Order(int orderId, Client client, List<Product> products, decimal totalPrice, DateTime orderDate, string status)
        {
            OrderId = orderId;
            Client = client ?? throw new ArgumentNullException(nameof(client));
            Products = products ?? throw new ArgumentNullException(nameof(products));
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            Status = status ?? throw new ArgumentNullException(nameof(status));
        }

        // Method to save an order to the file
        public void Save()
        {
            var orders = LoadOrders();
            orders.Add(this);
            SaveOrders(orders);
        }

        // Method to load orders from the file
        public static List<Order> LoadOrders()
        {
            var orders = new List<Order>();

            if (File.Exists(ordersFile))
            {
                var lines = File.ReadAllLines(ordersFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 6)
                    {
                        var client = Client.LoadClients().Find(c => c.Username == parts[1]); // Simplified for example
                        var products = new List<Product>(); // Simplified for example

                        // Parse the products from a stored format if necessary
                        // Here we assume the products are stored in a way that allows them to be parsed correctly
                        orders.Add(new Order(int.Parse(parts[0]), client, products, decimal.Parse(parts[2]), DateTime.Parse(parts[3]), parts[4]));
                    }
                }
            }

            return orders;
        }

        // Method to save a list of orders to the file
        public static void SaveOrders(List<Order> orders)
        {
            using (var writer = new StreamWriter(ordersFile))
            {
                foreach (var order in orders)
                {
                    // Simplified product saving; you might need to adjust this based on how products should be saved
                    writer.WriteLine($"{order.OrderId},{order.Client.Username},{order.TotalPrice},{order.OrderDate},{order.Status}");
                }
            }
        }

        // Method to search for orders by a query
        public static List<Order> SearchOrders(string query)
        {
            var orders = LoadOrders();
            query = query.ToLower();

            return orders.FindAll(o => o.Client.Name.ToLower().Contains(query) || o.Status.ToLower().Contains(query));
        }

        // Method to update an existing order
        public static void UpdateOrder(Order updatedOrder)
        {
            var orders = LoadOrders();
            var index = orders.FindIndex(ord => ord.OrderId == updatedOrder.OrderId);

            if (index != -1)
            {
                orders[index] = updatedOrder;
                SaveOrders(orders);
            }
            else
            {
                Console.WriteLine("Order not found for update.");
            }
        }

        // Method to delete an order by its ID
        public static void DeleteOrder(int orderId)
        {
            var orders = LoadOrders();
            var orderToDelete = orders.Find(ord => ord.OrderId == orderId);

            if (orderToDelete != null)
            {
                orders.Remove(orderToDelete);
                SaveOrders(orders);
            }
            else
            {
                Console.WriteLine("Order not found for deletion.");
            }
        }
    }
}
