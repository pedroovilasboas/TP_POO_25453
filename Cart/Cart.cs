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
            var carts = LoadCarts();
            carts.Add(this);
            SaveCarts(carts);
        }

        // Method to load all carts from file
        public static List<Cart> LoadCarts()
        {
            var carts = new List<Cart>();

            if (File.Exists(cartFile))
            {
                var lines = File.ReadAllLines(cartFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 3)
                    {
                        int cartId = int.Parse(parts[0]);
                        string clientUsername = parts[1];

                        // Load the client using a method like `Client.LoadClients()`
                        var client = Client.LoadClients().FirstOrDefault(c => c.Username == clientUsername);

                        if (client != null)
                        {
                            var cart = new Cart(cartId, client);

                            // Load products (assuming products are saved as IDs in a semicolon-separated format in parts[2])
                            var productIds = parts[2].Split(';');
                            foreach (var productIdStr in productIds)
                            {
                                if (int.TryParse(productIdStr, out int productId))
                                {
                                    // Load each product using a method like `Product.LoadProducts()`
                                    var product = Product.LoadProducts().FirstOrDefault(p => p.ProductID == productId);
                                    if (product != null)
                                    {
                                        cart.Products.Add(product);
                                    }
                                }
                            }
                            cart.CalculateTotal();
                            carts.Add(cart);
                        }
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
                    // Save each product ID in the cart as a semicolon-separated string
                    string productIds = string.Join(";", cart.Products.Select(p => p.ProductID));
                    writer.WriteLine($"{cart.CartId},{cart.Client.Username},{productIds},{cart.TotalPrice}");
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
