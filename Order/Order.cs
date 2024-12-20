using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Represents an order in the e-commerce system.
    /// Manages order creation, tracking, and status updates.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Unique identifier for the order
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// ID of the client who placed the order
        /// </summary>
        public int ClientID { get; set; }

        /// <summary>
        /// Name of the client who placed the order
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// ID of the product being ordered
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Quantity of products ordered
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price per unit of the product
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Original price before any discounts
        /// </summary>
        public decimal OriginalPrice { get; set; }

        /// <summary>
        /// Final price after applying discounts
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Current status of the order (e.g., Pending, Shipped)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Date and time when the order was placed
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// File path for storing orders data
        /// </summary>
        private static string ordersFile = @"C:\PROGRAM_CS\TP_POO_25453\Order\orders.txt";

        /// <summary>
        /// Static constructor to initialize the orders storage
        /// Creates the directory and file if they don't exist
        /// </summary>
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

        /// <summary>
        /// Loads all orders from the storage file
        /// Includes client names by joining with client data
        /// </summary>
        /// <returns>List of all orders in the system</returns>
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

        /// <summary>
        /// Saves a list of new orders to the storage file
        /// </summary>
        /// <param name="newOrders">List of orders to save</param>
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

        /// <summary>
        /// Loads all orders for a specific client
        /// Orders are sorted by date in descending order (newest first)
        /// </summary>
        /// <param name="clientID">ID of the client</param>
        /// <returns>List of orders for the specified client</returns>
        public static List<Order> LoadClientOrders(int clientID)
        {
            // Carregar todas as ordens e filtrar pelo ClientID
            // Ordenar por data decrescente para mostrar as mais recentes primeiro
            return LoadOrders()
                .Where(o => o.ClientID == clientID)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }

        /// <summary>
        /// Generates a new unique order ID
        /// </summary>
        /// <returns>Next available order ID</returns>
        public static int GenerateNewOrderID()
        {
            var orders = LoadOrders();
            if (!orders.Any()) return 1;
            return orders.Max(o => o.OrderID) + 1;
        }

        /// <summary>
        /// Validates if the order can be placed
        /// Checks quantity and product stock availability
        /// </summary>
        /// <returns>True if order is valid, false otherwise</returns>
        public bool ValidateOrder()
        {
            if (Quantity <= 0) return false;

            var product = Product.LoadProducts().FirstOrDefault(p => p.ProductID == ProductID);
            if (product == null) return false;

            return product.StockQuantity >= Quantity;
        }

        /// <summary>
        /// Updates the product stock after an order is placed
        /// Reduces the stock quantity by the ordered amount
        /// </summary>
        public void UpdateProductStock()
        {
            var product = Product.LoadProducts().FirstOrDefault(p => p.ProductID == ProductID);
            if (product != null)
            {
                product.UpdateStock(product.StockQuantity - Quantity);
            }
        }

        /// <summary>
        /// Updates the status of an order in the storage file
        /// </summary>
        /// <param name="newStatus">New status to set for the order</param>
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
