using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _25453_TP_POO
{
    public class Cart
    {
        // Cart class attributes
        public int CartId { get; set; }
        public Client Client { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal TotalPrice { get; private set; }

        // File path for cart.txt for persistence
        private static string cartFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Cart\cart.txt");

        // Constructor
        public Cart(int cartId, Client client)
        {
            CartId = cartId;
            Client = client;
            CalculateTotal();
        }

        // Method to add a product to the cart
        public void AddToCart(Product product)
        {
            Products.Add(product);
            CalculateTotal();
        }

        // Method to remove a product from the cart
        public void RemoveFromCart(Product product)
        {
            Products.Remove(product);
            CalculateTotal();
        }

        // Method to calculate the total price of the cart
        public void CalculateTotal()
        {
            TotalPrice = Products.Sum(p => p.Price);
        }

        // Method to clear the cart
        public void ClearCart()
        {
            Products.Clear();
            CalculateTotal();
        }

        // Method to complete purchase (checkout)
        public Order Checkout()
        {
            var order = new Order(GetNextOrderId(), Client, DateTime.Now, "To Ship")
            {
                Products = new List<Product>(Products)
            };
            order.CalculateTotal();
            order.Save();

            // Clear the cart after checkout
            ClearCart();

            return order;
        }

        // Method to save the cart state to file
        public void Save()
        {
            var carts = LoadCart();
            carts.Add(this);
            SaveCarts(carts);
        }

        // Method to load the cart from file
        public static List<Cart> LoadCart()
        {
            var carts = new List<Cart>();

            if (File.Exists(cartFile))
            {
                var lines = File.ReadAllLines(cartFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length > 2)
                    {
                        int cartId = int.Parse(parts[0]);
                        var client = new Client(parts[1]); // Simplified for example
                        var cart = new Cart(cartId, client);
                        carts.Add(cart);
                    }
                }
            }

            return carts;
        }

        // Method to save a list of carts to file
        public static void SaveCarts(List<Cart> carts)
        {
            using (var writer = new StreamWriter(cartFile))
            {
                foreach (var cart in carts)
                {
                    writer.WriteLine($"{cart.CartId},{cart.Client},{cart.TotalPrice}");
                }
            }
        }

        // Method to get the next order ID (simple example)
        private static int GetNextOrderId()
        {
            var orders = Order.LoadOrders();
            return orders.Count > 0 ? orders.Max(o => o.OrderId) + 1 : 1;
        }
    }
}
