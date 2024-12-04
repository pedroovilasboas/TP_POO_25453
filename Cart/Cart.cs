using System.Collections.Generic;

namespace POO_25453_TP
{
    public class Cart
    {
        // Structure to represent an item in the cart
        public class CartItem
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }

            public CartItem(Product product, int quantity)
            {
                Product = new Product(
                    product.ProductID,
                    product.Category, // Keep category if available
                    product.Brand,    // Keep brand details
                    product.Name,
                    product.Description,
                    product.Type,
                    product.Price,
                    product.StockQuantity // StockQuantity is not used in cart, just copied
                );
                Quantity = quantity; // Define how many are being purchased
            }
        }

        // List to hold cart items
        private List<CartItem> items = new List<CartItem>();

        // Add a product to the cart
        public void AddToCart(Product product, int quantity)
        {
            // Find if the product already exists in the cart
            var existingItem = items.Find(item => item.Product.ProductID == product.ProductID);
            if (existingItem != null)
            {
                // Update the quantity if the product already exists
                existingItem.Quantity += quantity;
            }
            else
            {
                // Add a new item to the cart
                items.Add(new CartItem(product, quantity));
            }
        }

        // Get all cart items
        public List<CartItem> GetCartItems()
        {
            return items;
        }

        // Remove an item from the cart
        public void RemoveFromCart(int productId)
        {
            items.RemoveAll(item => item.Product.ProductID == productId);
        }

        // Clear the entire cart
        public void ClearCart()
        {
            items.Clear();
        }
    }
}
