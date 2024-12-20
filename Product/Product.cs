using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Represents a product in the e-commerce system.
    /// Manages product information, inventory, and pricing.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Unique identifier for the product
        /// </summary>
        public int ProductID { get; private set; }

        /// <summary>
        /// Category classification of the product
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Brand of the product
        /// </summary>
        public Brand Brand { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Detailed description of the product
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Type or variant of the product
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Base price of the product before any discounts
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Current quantity available in stock
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// File path for storing product data
        /// </summary>
        private static string productsFile = @"C:\PROGRAM_CS\TP_POO_25453\Product\products.txt";

        /// <summary>
        /// Tracks the last used product ID for auto-increment
        /// </summary>
        private static int lastProductID = 0;

        /// <summary>
        /// Constructor for existing products loaded from storage
        /// </summary>
        /// <param name="productId">Existing product ID</param>
        /// <param name="category">Product category</param>
        /// <param name="brand">Product brand</param>
        /// <param name="name">Product name</param>
        /// <param name="description">Product description</param>
        /// <param name="type">Product type</param>
        /// <param name="price">Product price</param>
        /// <param name="stockQuantity">Available stock</param>
        public Product(int productId, Category category, Brand brand, string name, string description, string type, decimal price, int stockQuantity)
        {
            this.ProductID = productId; // Use the ID from the file
            this.Category = category;
            this.Brand = brand;
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.Price = price;
            this.StockQuantity = stockQuantity;
        }

        /// <summary>
        /// Constructor for creating new products
        /// Automatically generates a new product ID
        /// </summary>
        /// <param name="category">Product category</param>
        /// <param name="brand">Product brand</param>
        /// <param name="name">Product name</param>
        /// <param name="description">Product description</param>
        /// <param name="type">Product type</param>
        /// <param name="price">Product price</param>
        /// <param name="stockQuantity">Initial stock quantity</param>
        /// <exception cref="ArgumentNullException">Thrown when category or brand is null</exception>
        public Product(Category category, Brand brand, string name, string description, string type, decimal price, int stockQuantity)
        {
            if (category == null || brand == null)
                throw new ArgumentNullException("Category and Brand cannot be null");

            this.ProductID = ++lastProductID; // Increment the last used ID
            this.Category = category;
            this.Brand = brand;
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.Price = price;
            this.StockQuantity = stockQuantity;
        }

        /// <summary>
        /// Saves the current product to storage
        /// </summary>
        public void Save()
        {
            var products = LoadProducts();
            products.Add(this);
            SaveProducts(products);
        }

        /// <summary>
        /// Loads all products from storage
        /// Includes associated category and brand information
        /// </summary>
        /// <returns>List of all products in the system</returns>
        public static List<Product> LoadProducts()
        {
            var products = new List<Product>();
            if (!File.Exists(productsFile)) return products;

            var lines = File.ReadAllLines(productsFile);
            foreach (var line in lines)
            {
                try
                {
                    var parts = line.Split(',');
                    if (parts.Length != 8) continue;

                    int productId = int.Parse(parts[0]);
                    string brandName = parts[1];
                    string categoryName = parts[2];
                    
                    Brand brand = null;
                    Category category = null;

                    if (!string.IsNullOrEmpty(brandName))
                        brand = Brand.LoadBrands().FirstOrDefault(b => b.Name == brandName);
                    
                    if (!string.IsNullOrEmpty(categoryName))
                        category = Category.LoadCategories().FirstOrDefault(c => c.Name == categoryName);

                    var product = new Product(
                        productId,
                        category,
                        brand,
                        parts[3],
                        parts[4],
                        parts[5],
                        decimal.Parse(parts[6]),
                        int.Parse(parts[7])
                    );

                    products.Add(product);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Update lastProductID to the highest ID found in the file
            if (products.Any())
            {
                lastProductID = products.Max(p => p.ProductID);
            }
            else
            {
                lastProductID = 0; // Reset to 0 if no products exist
            }

            return products;
        }

        /// <summary>
        /// Saves multiple products to storage
        /// </summary>
        /// <param name="products">List of products to save</param>
        public static void SaveProducts(List<Product> products)
        {
            using (var writer = new StreamWriter(productsFile))
            {
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.ProductID},{product.Brand?.Name},{product.Category?.Name},{product.Name},{product.Description},{product.Type},{product.Price},{product.StockQuantity}");
                }
            }
        }

        /// <summary>
        /// Searches for products based on various criteria
        /// </summary>
        /// <param name="searchTerm">Term to search for in product details</param>
        /// <returns>List of products matching the search term</returns>
        public static List<Product> SearchProducts(string searchTerm)
        {
            return LoadProducts().Where(p =>
                p.Name.Contains(searchTerm) ||
                p.Description.Contains(searchTerm) ||
                p.Type.Contains(searchTerm) ||
                (p.Brand != null && p.Brand.Name.Contains(searchTerm)) ||
                (p.Category != null && p.Category.Name.Contains(searchTerm))
            ).ToList();
        }

        /// <summary>
        /// Updates the stock quantity of a product
        /// </summary>
        /// <param name="newStock">New stock quantity</param>
        public void UpdateStock(int newStock)
        {
            StockQuantity = newStock;

            var products = LoadProducts();
            var index = products.FindIndex(p => p.ProductID == ProductID);
            if (index != -1)
            {
                products[index] = this;
                SaveProducts(products);
            }
        }

        /// <summary>
        /// Updates all details of an existing product
        /// </summary>
        /// <param name="updatedProduct">Product with updated information</param>
        public static void UpdateProduct(Product updatedProduct)
        {
            var products = LoadProducts();
            var index = products.FindIndex(p => p.ProductID == updatedProduct.ProductID);

            if (index != -1)
            {
                products[index] = updatedProduct;
                SaveProducts(products);
            }
            else
            {
                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gets the final price after applying any active campaign discounts
        /// </summary>
        /// <returns>Discounted price of the product</returns>
        public decimal GetFinalPrice()
        {
            return Campaign.GetDiscountedPrice(this);
        }

        /// <summary>
        /// Gets a formatted string showing the product's price
        /// Includes both discounted and original price if a discount is active
        /// </summary>
        /// <returns>Formatted price string</returns>
        public string GetPriceDisplay()
        {
            decimal finalPrice = GetFinalPrice();
            if (finalPrice < Price)
            {
                return $"{finalPrice:C} (Original: {Price:C})";
            }
            return Price.ToString("C");
        }
    }
}
