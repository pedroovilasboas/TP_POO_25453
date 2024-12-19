using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace POO_25453_TP
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }

        // File paths for storing orders
        private static string ordersFile = @"C:\PROGRAM_CS\TP_POO_25453\Order\orders.txt";
        private static string myOrdersFile = @"C:\PROGRAM_CS\TP_POO_25453\Order\myorders.txt";

        static Order()
        {
            // Ensure order directories exist
            var orderDir = Path.GetDirectoryName(ordersFile);
            Directory.CreateDirectory(orderDir);

            // Create empty files if they don't exist
            if (!File.Exists(ordersFile))
            {
                File.WriteAllText(ordersFile, "");
            }
            if (!File.Exists(myOrdersFile))
            {
                File.WriteAllText(myOrdersFile, "");
            }
        }

        public static List<Order> LoadOrders()
        {
            if (!File.Exists(ordersFile)) return new List<Order>();

            return File.ReadAllLines(ordersFile)
                .Select(line =>
                {
                    var parts = line.Split(',');
                    return new Order
                    {
                        OrderID = int.Parse(parts[0]),
                        ClientID = int.Parse(parts[1]),
                        ProductID = int.Parse(parts[2]),
                        Quantity = int.Parse(parts[3]),
                        UnitPrice = decimal.Parse(parts[4]),
                        TotalPrice = decimal.Parse(parts[5]),
                        Status = parts[6]
                    };
                }).ToList();
        }

        public static void SaveOrders(List<Order> orders)
        {
            var lines = orders.Select(o => 
                $"{o.OrderID},{o.ClientID},{o.ProductID},{o.Quantity},{o.UnitPrice},{o.TotalPrice},{o.Status}");
            
            // Write to both files atomically
            try
            {
                File.WriteAllLines(ordersFile, lines);
                File.WriteAllLines(myOrdersFile, lines);
            }
            catch (Exception)
            {
                // If there's an error, try to restore from orders.txt
                if (File.Exists(ordersFile))
                {
                    var backupLines = File.ReadAllLines(ordersFile);
                    File.WriteAllLines(myOrdersFile, backupLines);
                }
                throw;
            }
        }

        public static int GenerateNewOrderID()
        {
            if (!File.Exists(ordersFile)) return 1;

            var lines = File.ReadAllLines(ordersFile);
            if (!lines.Any()) return 1;

            return lines.Select(line => int.Parse(line.Split(',')[0])).Max() + 1;
        }

        public bool ValidateOrder()
        {
            if (Quantity <= 0) return false;
            
            var product = Product.LoadProducts().FirstOrDefault(p => p.ProductID == ProductID);
            if (product == null) return false;
            
            var client = Client.LoadClients().FirstOrDefault(c => c.ClientID == ClientID);
            if (client == null) return false;

            if (product.StockQuantity < Quantity) return false;

            return true;
        }

        public void UpdateProductStock()
        {
            var products = Product.LoadProducts();
            var product = products.FirstOrDefault(p => p.ProductID == ProductID);
            if (product != null)
            {
                product.StockQuantity -= Quantity;
                Product.SaveProducts(products);
            }
        }
    }
}
