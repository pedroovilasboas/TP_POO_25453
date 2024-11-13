using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _25453_TP_POO
{
    public class Product
    {
        public int ProductID { get; private set; } // Unique ID for each product
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // File path for products.txt
        private static string productsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Product\products.txt");

        // Static variable to track the last used ProductID
        private static int lastProductID = 0;

        // Constructor for loading products from file (with ProductID)
        public Product(int productId, Category category, Brand brand, string name, string description, string type, decimal price, int stockQuantity)
        {
            ProductID = productId;
            Category = category;
            Brand = brand;
            Name = name;
            Description = description;
            Type = type;
            Price = price;
            StockQuantity = stockQuantity;

            // Update lastProductID to ensure unique IDs for new products
            if (productId > lastProductID)
            {
                lastProductID = productId;
            }
        }

        // Constructor for creating a new product with an auto-incremented ProductID
        public Product(Category category, Brand brand, string name, string description, string type, decimal price, int stockQuantity)
        {
            ProductID = ++lastProductID; // Increment ProductID for each new product
            Category = category;
            Brand = brand;
            Name = name;
            Description = description;
            Type = type;
            Price = price;
            StockQuantity = stockQuantity;
        }

        // Method to save a product
        public void Save()
        {
            var products = LoadProducts();
            products.Add(this);
            SaveProducts(products);
        }

        // Method to load products from file
        public static List<Product> LoadProducts()
        {
            var products = new List<Product>();

            if (File.Exists(productsFile))
            {
                var lines = File.ReadAllLines(productsFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 7) // Ensure we have all fields including ProductID
                    {
                        int productId = int.Parse(parts[0]);
                        var brandName = parts[1];
                        var brand = Brand.LoadBrands().FirstOrDefault(b => b.Name == brandName);

                        if (brand != null)
                        {
                            var product = new Product(
                                productId,
                                null, // Assuming Category is handled elsewhere
                                brand,
                                parts[2], // Name
                                parts[3], // Description
                                parts[4], // Type
                                decimal.Parse(parts[5]), // Price
                                int.Parse(parts[6]) // StockQuantity
                            );
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        // Method to save a list of products to file
        public static void SaveProducts(List<Product> products)
        {
            using (var writer = new StreamWriter(productsFile))
            {
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.ProductID},{product.Brand.Name},{product.Name},{product.Description},{product.Type},{product.Price},{product.StockQuantity}");
                }
            }
        }

        // Method to search products by name, description, type, or brand
        public static List<Product> SearchProducts(string query)
        {
            var products = LoadProducts();
            query = query.ToLower();

            return products.Where(p => p.Name.ToLower().Contains(query) || p.Description.ToLower().Contains(query) || p.Type.ToLower().Contains(query) || p.Brand.Name.ToLower().Contains(query)).ToList();
        }

        // Method to update stock quantity
        public void UpdateStock(int newStock)
        {
            StockQuantity = newStock;
            Alert.CheckAndGenerateAlert(this);
        }

        // Method to update a product
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
                MessageBox.Show("Product not found for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to delete a product by ID
        public static void DeleteProduct(int productId)
        {
            var products = LoadProducts();
            var productToDelete = products.FirstOrDefault(p => p.ProductID == productId);

            if (productToDelete != null)
            {
                products.Remove(productToDelete);
                SaveProducts(products);
            }
            else
            {
                MessageBox.Show("Product not found for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override string ToString()
        {
            return $"{Name}:{Price}"; // Save as "Name:Price" for each product
        }
    }
}
