using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        // File path for storing orders
        private static string ordersFile = @"C:\PROGRAM_CS\TP_POO_25453\Order\orders.txt";

        static Order()
        {
            // Ensure order directory exists
            var orderDir = Path.GetDirectoryName(ordersFile);
            Directory.CreateDirectory(orderDir);

            // Create empty file if it doesn't exist
            if (!File.Exists(ordersFile))
            {
                File.WriteAllText(ordersFile, "");
            }
        }

        public static List<Order> LoadOrders()
        {
            var orders = new List<Order>();
            if (!File.Exists(ordersFile)) return orders;

            // Carregar lista de clientes para obter os nomes
            var clients = Client.LoadClients();

            var lines = File.ReadAllLines(ordersFile);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                
                var parts = line.Split(';');
                if (parts.Length < 9) continue;

                try
                {
                    var clientId = int.Parse(parts[1]);
                    var client = clients.FirstOrDefault(c => c.ClientID == clientId);
                    
                    orders.Add(new Order
                    {
                        OrderID = int.Parse(parts[0]),
                        ClientID = clientId,
                        ClientName = client?.Name ?? "Unknown",
                        ProductID = int.Parse(parts[2]),
                        Quantity = int.Parse(parts[3]),
                        UnitPrice = decimal.Parse(parts[4]),
                        OriginalPrice = decimal.Parse(parts[5]),
                        TotalPrice = decimal.Parse(parts[6]),
                        Status = parts[7],
                        OrderDate = DateTime.Parse(parts[8])
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing order line: {line}. Error: {ex.Message}");
                }
            }

            return orders;
        }

        public static void SaveOrders(List<Order> newOrders)
        {
            try
            {
                // Converter as novas ordens para linhas de texto
                var newLines = newOrders.Select(o => string.Join(";",
                    o.OrderID,
                    o.ClientID,
                    o.ProductID,
                    o.Quantity,
                    o.UnitPrice,
                    o.OriginalPrice,
                    o.TotalPrice,
                    o.Status,
                    o.OrderDate.ToString("yyyy-MM-dd HH:mm:ss")
                ));

                // Adicionar as novas linhas ao final do arquivo
                File.AppendAllLines(ordersFile, newLines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<Order> LoadClientOrders(int clientID)
        {
            // Carregar todas as ordens e filtrar pelo ClientID
            // Ordenar por data decrescente para mostrar as mais recentes primeiro
            return LoadOrders()
                .Where(o => o.ClientID == clientID)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }

        public static int GenerateNewOrderID()
        {
            var orders = LoadOrders();
            if (!orders.Any()) return 1;
            return orders.Max(o => o.OrderID) + 1;
        }

        public bool ValidateOrder()
        {
            if (Quantity <= 0) return false;

            var product = Product.LoadProducts().FirstOrDefault(p => p.ProductID == ProductID);
            if (product == null) return false;

            return product.StockQuantity >= Quantity;
        }

        public void UpdateProductStock()
        {
            var product = Product.LoadProducts().FirstOrDefault(p => p.ProductID == ProductID);
            if (product != null)
            {
                product.UpdateStock(product.StockQuantity - Quantity);
            }
        }

        public void UpdateStatus(string newStatus)
        {
            try
            {
                // Ler todas as linhas do arquivo
                var lines = File.ReadAllLines(ordersFile).ToList();
                
                // Encontrar e atualizar a linha específica
                for (int i = 0; i < lines.Count; i++)
                {
                    var parts = lines[i].Split(';');
                    if (parts.Length >= 9 && int.Parse(parts[0]) == this.OrderID)
                    {
                        // Atualizar apenas o status (índice 7)
                        parts[7] = newStatus;
                        lines[i] = string.Join(";", parts);
                        break;
                    }
                }

                // Salvar todas as linhas de volta no arquivo
                File.WriteAllLines(ordersFile, lines);
                this.Status = newStatus;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
