using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace POO_25453_TP
{
    public class Alert
    {
        // Class attributes
        public int AlertId { get; set; }
        public string Message { get; set; }
        public int ProductID { get; set; } // Updated to match the `ProductID` naming convention
        public DateTime CreatedAt { get; set; }

        // File path for alerts.txt for persistence
        private static string alertsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\POO_25453_TP\Alert\alerts.txt");

        // Constructor
        public Alert(int alertId, string message, int productID)
        {
            AlertId = alertId;
            Message = message;
            ProductID = productID;
            CreatedAt = DateTime.Now;
        }

        // Method to create an alert for a specific product
        public static void CreateAlert(Product product, string message)
        {
            var alerts = LoadAlerts();

            // Checks if an alert already exists for this product
            if (!alerts.Any(a => a.ProductID == product.ProductID))
            {
                int newAlertId = alerts.Count > 0 ? alerts.Max(a => a.AlertId) + 1 : 1;
                var newAlert = new Alert(newAlertId, message, product.ProductID);
                alerts.Add(newAlert);
                SaveAlerts(alerts);
            }
        }

        // Method to remove an alert for a specific product
        public static void RemoveAlert(int productID)
        {
            var alerts = LoadAlerts();
            var alertToRemove = alerts.FirstOrDefault(a => a.ProductID == productID);

            if (alertToRemove != null)
            {
                alerts.Remove(alertToRemove);
                SaveAlerts(alerts);
            }
        }

        // Method to check and create or remove an alert based on stock level
        public static void CheckAndGenerateAlert(Product product)
        {
            if (product.StockQuantity < 5)
            {
                CreateAlert(product, $"Low stock for product {product.Name}. Only {product.StockQuantity} units remaining.");
            }
            else
            {
                RemoveAlert(product.ProductID);
            }
        }

        // Method to load alerts from file
        public static List<Alert> LoadAlerts()
        {
            var alerts = new List<Alert>();

            if (File.Exists(alertsFile))
            {
                var lines = File.ReadAllLines(alertsFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        int alertId = int.Parse(parts[0]);
                        string message = parts[1];
                        int productID = int.Parse(parts[2]);
                        DateTime createdAt = DateTime.Parse(parts[3]);

                        alerts.Add(new Alert(alertId, message, productID) { CreatedAt = createdAt });
                    }
                }
            }

            return alerts;
        }

        // Method to save a list of alerts to file
        public static void SaveAlerts(List<Alert> alerts)
        {
            using (var writer = new StreamWriter(alertsFile))
            {
                foreach (var alert in alerts)
                {
                    writer.WriteLine($"{alert.AlertId},{alert.Message},{alert.ProductID},{alert.CreatedAt}");
                }
            }
        }

        // Method to get all active alerts
        public static List<Alert> GetActiveAlerts()
        {
            return LoadAlerts();
        }
    }
}
