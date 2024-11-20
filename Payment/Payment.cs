using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace POO_25453_TP
{
    public class Payment
    {
        // Payment class attributes
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsConfirmed { get; set; }

        // File path for payments.txt for persistence
        private static string paymentsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\POO_25453_TP\Payment\payments.txt");

        // Constructor
        public Payment(int paymentId, int orderId, decimal amount, DateTime paymentDate, string paymentMethod, bool isConfirmed = false)
        {
            PaymentId = paymentId;
            OrderId = orderId;
            Amount = amount;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
            IsConfirmed = isConfirmed;
        }

        // Method to process a payment
        public static void ProcessPayment(Order order, decimal amount, string paymentMethod)
        {
            var payments = LoadPayments();
            int newPaymentId = payments.Count > 0 ? payments.Max(p => p.PaymentId) + 1 : 1;

            var newPayment = new Payment(newPaymentId, order.OrderId, amount, DateTime.Now, paymentMethod);
            payments.Add(newPayment);
            SavePayments(payments);
        }

        // Method to confirm the payment
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

        // Method to load payments from file
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

        // Method to save a list of payments to file
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

        // Method to get payment by order ID
        public static Payment GetPaymentByOrderId(int orderId)
        {
            var payments = LoadPayments();
            return payments.FirstOrDefault(p => p.OrderId == orderId);
        }
    }
}
