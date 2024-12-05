using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace POO_25453_TP
{
    public class Cart
    {

        public class CartItem
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }


        public int ClientID { get; private set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        private static string cartFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:\\PROGRAM_CS\\25453_TP_POO\\Cart\\cart.txt");

        public Cart(int clientID)
        {
            this.ClientID = clientID;
        }

        public void AddToCart(Product product, int quantity)
        {
            // Check if the product is already in the cart
            var existingItem = Items.FirstOrDefault(item => item.ProductID == product.ProductID);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem
                {
                    ProductID = product.ProductID,
                    ProductName = product.Name,
                    Quantity = quantity,
                    Price = product.Price
                });
            }

            SaveCart();
        }

        public void SaveCart()
        {
            // Read existing cart data
            var lines = new List<string>();
            if (File.Exists(cartFile))
            {
                lines.AddRange(File.ReadAllLines(cartFile)
                    .Where(line => int.Parse(line.Split(',')[0]) != ClientID));
            }

            // Add updated cart items for the current client
            lines.AddRange(Items.Select(item =>
                $"{ClientID},{item.ProductID},{item.ProductName},{item.Quantity},{item.Price}"));

            // Write back to cart.txt
            File.WriteAllLines(cartFile, lines);
        }

        public static Cart LoadCart(int clientID)
        {
            var cart = new Cart(clientID);
            if (!File.Exists(cartFile)) return cart;

            var lines = File.ReadAllLines(cartFile);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length != 5) continue;

                if (int.Parse(parts[0]) == clientID)
                {
                    cart.Items.Add(new CartItem
                    {
                        ProductID = int.Parse(parts[1]),
                        ProductName = parts[2],
                        Quantity = int.Parse(parts[3]),
                        Price = decimal.Parse(parts[4])
                    });
                }
            }

            return cart;
        }


        public void Checkout()
        {
            // Absolute paths
            string ordersFile = @"C:\PROGRAM_CS\25453_TP_POO\Order\orders.txt";
            string myOrdersFile = @"C:\PROGRAM_CS\25453_TP_POO\Order\myorders.txt";

            int newOrderID = 1;

            // Ensure the directory exists
            if (!Directory.Exists(@"C:\PROGRAM_CS\25453_TP_POO\Order"))
            {
                Directory.CreateDirectory(@"C:\PROGRAM_CS\25453_TP_POO\Order");
            }

            // Determine the next OrderID
            if (File.Exists(ordersFile))
            {
                var lines = File.ReadAllLines(ordersFile);
                if (lines.Any())
                {
                    newOrderID = lines.Select(line => int.Parse(line.Split(',')[0])).Max() + 1;
                }
            }

            // Create order lines for all items in the cart
            var orderLines = Items.Select(cartItem =>
            {
                // Round price to the nearest integer
                int unitPrice = (int)Math.Round(cartItem.Price);
                int totalPrice = unitPrice * cartItem.Quantity;

                // Format the line for the file
                return $"{newOrderID},{ClientID},{cartItem.ProductID},{cartItem.Quantity},{unitPrice},{totalPrice},Pending";
            }).ToList();

            // Append to orders.txt
            File.AppendAllLines(ordersFile, orderLines);

            // Append to myorders.txt
            File.AppendAllLines(myOrdersFile, orderLines);

            // Clear the cart
            Items.Clear();
            SaveCart();
        }






    }


}

