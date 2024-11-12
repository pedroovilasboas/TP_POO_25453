using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _25453_TP_POO
{
    public class Alert
    {
        // Atributos da classe Alert
        public int AlertId { get; set; }
        public string Message { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Caminho para o arquivo alerts.txt para persistência
        private static string alertsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Alert\alerts.txt");

        // Construtor
        public Alert(int alertId, string message, int productId)
        {
            AlertId = alertId;
            Message = message;
            ProductId = productId;
            CreatedAt = DateTime.Now;
        }

        // Método para criar um alerta para um produto específico
        public static void CreateAlert(Product product, string message)
        {
            var alerts = LoadAlerts();

            // Verifica se já existe um alerta para esse produto
            if (!alerts.Any(a => a.ProductId == product.ProductId))
            {
                int newAlertId = alerts.Count > 0 ? alerts.Max(a => a.AlertId) + 1 : 1;
                var newAlert = new Alert(newAlertId, message, product.ProductId);
                alerts.Add(newAlert);
                SaveAlerts(alerts);
            }
        }

        // Método para remover alerta para um produto específico
        public static void RemoveAlert(int productId)
        {
            var alerts = LoadAlerts();
            var alertToRemove = alerts.FirstOrDefault(a => a.ProductId == productId);

            if (alertToRemove != null)
            {
                alerts.Remove(alertToRemove);
                SaveAlerts(alerts);
            }
        }

        // Método para verificar se um alerta deve ser criado ou removido com base no stock
        public static void CheckAndGenerateAlert(Product product)
        {
            if (product.StockQuantity < 5)
            {
                CreateAlert(product, $"Stock baixo para o produto {product.Name}. Apenas {product.StockQuantity} unidades restantes.");
            }
            else
            {
                RemoveAlert(product.ProductId);
            }
        }

        // Método para carregar alertas a partir do arquivo
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
                        int productId = int.Parse(parts[2]);
                        DateTime createdAt = DateTime.Parse(parts[3]);

                        alerts.Add(new Alert(alertId, message, productId) { CreatedAt = createdAt });
                    }
                }
            }

            return alerts;
        }

        // Método para salvar uma lista de alertas no arquivo
        public static void SaveAlerts(List<Alert> alerts)
        {
            using (var writer = new StreamWriter(alertsFile))
            {
                foreach (var alert in alerts)
                {
                    writer.WriteLine($"{alert.AlertId},{alert.Message},{alert.ProductId},{alert.CreatedAt}");
                }
            }
        }

        // Método para obter todos os alertas ativos
        public static List<Alert> GetActiveAlerts()
        {
            return LoadAlerts();
        }
    }
}
