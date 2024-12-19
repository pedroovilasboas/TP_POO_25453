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

        private static string cartFile = @"C:\PROGRAM_CS\TP_POO_25453\Cart\cart.txt";

        public Cart(int clientID)
        {
            this.ClientID = clientID;
            // Ensure cart directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(cartFile));
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


        public bool Checkout()
        {
            if (!Items.Any())
            {
                throw new InvalidOperationException("Cart is empty");
            }

            // Create new orders
            var orders = new List<Order>();
            int newOrderID = Order.GenerateNewOrderID();

            foreach (var item in Items)
            {
                var order = new Order
                {
                    OrderID = newOrderID,
                    ClientID = ClientID,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price,
                    TotalPrice = item.Price * item.Quantity,
                    Status = "Pending"
                };

                // Validate the order
                if (!order.ValidateOrder())
                {
                    throw new InvalidOperationException($"Invalid order for product {item.ProductName}. Please check product availability.");
                }

                orders.Add(order);
            }

            try
            {
                // Save all orders
                Order.SaveOrders(orders);

                // Update product stock
                foreach (var order in orders)
                {
                    order.UpdateProductStock();
                }

                // Clear the cart
                Items.Clear();
                SaveCart();

                return true;
            }
            catch (Exception)
            {
                // If anything fails, the transaction should be rolled back
                throw;
            }
        }






    }


}
