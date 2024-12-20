using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public class Product
    {
        // Properties for Product
        public int ProductID { get; private set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // File path for storing products
        private static string productsFile = @"C:\PROGRAM_CS\TP_POO_25453\Product\products.txt";
        private static int lastProductID = 0;

        // Constructor for existing product (loaded from file)
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

        // Constructor for new product (creating a new entry)
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

        // Method to save the product
        public void Save()
        {
            var products = LoadProducts();
            products.Add(this);
            SaveProducts(products);
        }

        // Method to load all products
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

        // Method to save all products
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

        // Method to search products
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

        // Method to update stock quantity
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

        // Method to update product details
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

        public decimal GetFinalPrice()
        {
            return Campaign.GetDiscountedPrice(this);
        }

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
