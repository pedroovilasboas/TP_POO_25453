using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace POO_25453_TP
{
    /// <summary>
    /// Represents a shopping cart in the e-commerce system.
    /// Manages cart items and checkout process for a client.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Represents an item in the shopping cart
        /// </summary>
        public class CartItem
        {
            /// <summary>
            /// ID of the product in the cart
            /// </summary>
            public int ProductID { get; set; }

            /// <summary>
            /// Name of the product
            /// </summary>
            public string ProductName { get; set; }

            /// <summary>
            /// Quantity of the product
            /// </summary>
            public int Quantity { get; set; }

            /// <summary>
            /// Original price before discounts
            /// </summary>
            public decimal OriginalPrice { get; set; }

            /// <summary>
            /// Price after applying discounts
            /// </summary>
            public decimal DiscountedPrice { get; set; }

            /// <summary>
            /// Converts cart item to string format for storage
            /// </summary>
            /// <returns>Semicolon-separated string of cart item data</returns>
            public override string ToString()
            {
                return $"{ProductID};{ProductName};{Quantity};{OriginalPrice};{DiscountedPrice}";
            }

            /// <summary>
            /// Creates a cart item from its string representation
            /// </summary>
            /// <param name="line">Semicolon-separated string of cart item data</param>
            /// <returns>New CartItem instance</returns>
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

        /// <summary>
        /// ID of the client who owns this cart
        /// </summary>
        public int ClientID { get; private set; }

        /// <summary>
        /// List of items in the cart
        /// </summary>
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        /// <summary>
        /// File path for storing cart data
        /// </summary>
        private static readonly string cartFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cart", "cart.txt");

        /// <summary>
        /// Constructor for creating a new cart
        /// </summary>
        /// <param name="clientID">ID of the client who owns the cart</param>
        public Cart(int clientID)
        {
            this.ClientID = clientID;
        }

        /// <summary>
        /// Adds a product to the cart with automatic discount calculation
        /// </summary>
        /// <param name="product">Product to add</param>
        /// <param name="quantity">Quantity to add</param>
        public void AddToCart(Product product, int quantity)
        {
            decimal discountedPrice = Campaign.GetDiscountedPrice(product);
            
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

        /// <summary>
        /// Adds a product to the cart with a specified discount price
        /// </summary>
        /// <param name="product">Product to add</param>
        /// <param name="quantity">Quantity to add</param>
        /// <param name="discountedPrice">Pre-calculated discounted price</param>
        public void AddToCart(Product product, int quantity, decimal discountedPrice)
        {
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

        /// <summary>
        /// Saves the current cart state to storage
        /// Preserves cart data for other clients
        /// </summary>
        public void SaveCart()
        {
            try
            {
                string directory = Path.GetDirectoryName(cartFile);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                List<string> lines = new List<string>();

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
                                return false;
                            }
                        })
                        .ToList();
                }

                foreach (var item in Items)
                {
                    string line = $"{ClientID};{item.ProductID};{item.ProductName};{item.Quantity};{item.OriginalPrice:F2};{item.DiscountedPrice:F2}";
                    lines.Add(line);
                }

                File.WriteAllLines(cartFile, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads a client's cart from storage
        /// </summary>
        /// <param name="clientID">ID of the client whose cart to load</param>
        /// <returns>Cart instance with loaded items</returns>
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

        /// <summary>
        /// Processes the checkout of specific items from the cart
        /// Creates orders for the specified items and updates product stock
        /// </summary>
        /// <param name="itemsToCheckout">List of items to checkout. If null, checkouts entire cart</param>
        /// <returns>True if checkout was successful</returns>
        /// <exception cref="InvalidOperationException">Thrown when cart is empty or order validation fails</exception>
        /// <exception cref="Exception">Thrown when checkout processing fails</exception>
        public bool Checkout(List<CartItem> itemsToCheckout = null)
        {
            var itemsToProcess = itemsToCheckout ?? Items;

            if (!itemsToProcess.Any())
            {
                throw new InvalidOperationException("No items selected for checkout");
            }

            var orders = new List<Order>();
            int newOrderID = Order.GenerateNewOrderID();

            foreach (var item in itemsToProcess)
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

                if (!order.ValidateOrder())
                {
                    throw new InvalidOperationException($"Invalid order for product {item.ProductName}. Please check product availability.");
                }

                orders.Add(order);
            }

            try
            {
                Order.SaveOrders(orders);

                foreach (var order in orders)
                {
                    order.UpdateProductStock();
                }

                // Remove only the checked out items from the cart
                if (itemsToCheckout != null)
                {
                    Items.RemoveAll(item => itemsToCheckout.Any(checkoutItem => 
                        checkoutItem.ProductID == item.ProductID));
                }
                else
                {
                    Items.Clear();
                }
                
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
