using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _25453_TP_POO
{
    public class Payment
    {
        // Atributos da classe Payment
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsConfirmed { get; set; }

        // Caminho para o arquivo payments.txt para persistência
        private static string paymentsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Payment\payments.txt");

        // Construtor
        public Payment(int paymentId, int orderId, decimal amount, DateTime paymentDate, string paymentMethod, bool isConfirmed = false)
        {
            PaymentId = paymentId;
            OrderId = orderId;
            Amount = amount;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
            IsConfirmed = isConfirmed;
        }

        // Método para processar um pagamento
        public static void ProcessPayment(Order order, decimal amount, string paymentMethod)
        {
            var payments = LoadPayments();
            int newPaymentId = payments.Count > 0 ? payments.Max(p => p.PaymentId) + 1 : 1;

            var newPayment = new Payment(newPaymentId, order.OrderId, amount, DateTime.Now, paymentMethod);
            payments.Add(newPayment);
            SavePayments(payments);
        }

        // Método para confirmar o pagamento
        public void ConfirmPayment()
        {
            IsConfirmed = true;
            var payments = LoadPayments();
            var index = payments.FindIndex(p => p.PaymentId == this.PaymentId);
            if (index != -1)
            {
                payments[index] = this;
                SavePayments(payments);
            }
        }

        // Método para carregar pagamentos a partir do arquivo
        public static List<Payment> LoadPayments()
        {
            var payments = new List<Payment>();

            if (File.Exists(paymentsFile))
            {
                var lines = File.ReadAllLines(paymentsFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 6)
                    {
                        int paymentId = int.Parse(parts[0]);
                        int orderId = int.Parse(parts[1]);
                        decimal amount = decimal.Parse(parts[2]);
                        DateTime paymentDate = DateTime.Parse(parts[3]);
                        string paymentMethod = parts[4];
                        bool isConfirmed = bool.Parse(parts[5]);

                        payments.Add(new Payment(paymentId, orderId, amount, paymentDate, paymentMethod, isConfirmed));
                    }
                }
            }

            return payments;
        }

        // Método para salvar uma lista de pagamentos no arquivo
        public static void SavePayments(List<Payment> payments)
        {
            using (var writer = new StreamWriter(paymentsFile))
            {
                foreach (var payment in payments)
                {
                    writer.WriteLine($"{payment.PaymentId},{payment.OrderId},{payment.Amount},{payment.PaymentDate},{payment.PaymentMethod},{payment.IsConfirmed}");
                }
            }
        }

        // Método para obter o pagamento por ID de pedido
        public static Payment GetPaymentByOrderId(int orderId)
        {
            var payments = LoadPayments();
            return payments.FirstOrDefault(p => p.OrderId == orderId);
        }
    }
}
