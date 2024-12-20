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
            public decimal OriginalPrice { get; set; }
            public decimal DiscountedPrice { get; set; }

            public override string ToString()
            {
                return $"{ProductID};{ProductName};{Quantity};{OriginalPrice};{DiscountedPrice}";
            }

            public static CartItem FromString(string line)
            {
                var parts = line.Split(';');
                return new CartItem
                {
                    ProductID = int.Parse(parts[0]),
                    ProductName = parts[1],
                    Quantity = int.Parse(parts[2]),
                    OriginalPrice = decimal.Parse(parts[3]),
                    DiscountedPrice = decimal.Parse(parts[4])
                };
            }
        }


        public int ClientID { get; private set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        private static readonly string cartFile = @"C:\PROGRAM_CS\TP_POO_25453\Cart\cart.txt";

        public Cart(int clientID)
        {
            this.ClientID = clientID;
        }

        public void AddToCart(Product product, int quantity)
        {
            decimal discountedPrice = Campaign.GetDiscountedPrice(product);
            
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
                    OriginalPrice = product.Price,
                    DiscountedPrice = discountedPrice
                });
            }

            SaveCart();
        }

        public void AddToCart(Product product, int quantity, decimal discountedPrice)
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
                    OriginalPrice = product.Price,
                    DiscountedPrice = discountedPrice
                });
            }

            SaveCart();
        }

        public void SaveCart()
        {
            try
            {
                // Create directory if it doesn't exist
                string directory = Path.GetDirectoryName(cartFile);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                List<string> lines = new List<string>();

                // Preservar itens de outros clientes
                if (File.Exists(cartFile))
                {
                    lines = File.ReadAllLines(cartFile)
                        .Where(line => 
                        {
                            if (string.IsNullOrWhiteSpace(line)) return false;
                            
                            try
                            {
                                var parts = line.Split(';');
                                return parts.Length >= 6 && int.Parse(parts[0]) != ClientID;
                            }
                            catch
                            {
                                return false; // Ignorar linhas inválidas
                            }
                        })
                        .ToList();
                }

                // Adicionar itens do cliente atual
                foreach (var item in Items)
                {
                    string line = $"{ClientID};{item.ProductID};{item.ProductName};{item.Quantity};{item.OriginalPrice:F2};{item.DiscountedPrice:F2}";
                    lines.Add(line);
                }

                // Save to file
                File.WriteAllLines(cartFile, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static Cart LoadCart(int clientID)
        {
            var cart = new Cart(clientID);

            if (File.Exists(cartFile))
            {
                foreach (var line in File.ReadAllLines(cartFile))
                {
                    var parts = line.Split(';');
                    if (parts.Length == 6 && int.Parse(parts[0]) == clientID)
                    {
                        cart.Items.Add(new CartItem
                        {
                            ProductID = int.Parse(parts[1]),
                            ProductName = parts[2],
                            Quantity = int.Parse(parts[3]),
                            OriginalPrice = decimal.Parse(parts[4]),
                            DiscountedPrice = decimal.Parse(parts[5])
                        });
                    }
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
                    UnitPrice = item.DiscountedPrice,
                    OriginalPrice = item.OriginalPrice,
                    TotalPrice = item.DiscountedPrice * item.Quantity,
                    Status = "Pending",
                    OrderDate = DateTime.Now
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
            catch (Exception ex)
            {
                throw new Exception($"Error processing checkout: {ex.Message}");
            }
        }
    }
}
