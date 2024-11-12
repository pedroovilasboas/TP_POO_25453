using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _25453_TP_POO
{
    public class Product
    {
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Caminho para o arquivo products.txt
        private static string productsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Product\products.txt");

        public Product(Category category, Brand brand, string name, string description, string type, decimal price, int stockQuantity)
        {
            Category = category;
            Brand = brand;
            Name = name;
            Description = description;
            Type = type;
            Price = price;
            StockQuantity = stockQuantity;
        }

     

        // Método para salvar produto
        public void Save()
        {
            var products = LoadProducts();
            products.Add(this);
            SaveProducts(products);
        }

        // Método para carregar produtos
        public static List<Product> LoadProducts()
        {
            var products = new List<Product>();

            if (File.Exists(productsFile))
            {
                var lines = File.ReadAllLines(productsFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 6)
                    {
                        var brandName = parts[0];
                        var brand = Brand.LoadBrands().FirstOrDefault(b => b.Name == brandName);

                        if (brand != null)
                        {
                            products.Add(new Product(
                                brand,
                                parts[1],
                                parts[2],
                                parts[3],
                                decimal.Parse(parts[4]),
                                int.Parse(parts[5])
                            ));
                        }
                    }
                }
            }

            return products;
        }

        // Método para salvar lista de produtos
        public static void SaveProducts(List<Product> products)
        {
            using (var writer = new StreamWriter(productsFile))
            {
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.Brand.Name},{product.Name},{product.Description},{product.Type},{product.Price},{product.StockQuantity}");
                }
            }
        }

        // Método para procurar produtos
        public static List<Product> SearchProducts(string query)
        {
            var products = LoadProducts();
            query = query.ToLower();

            return products.Where(p =>
                p.Name.ToLower().Contains(query) ||
                p.Description.ToLower().Contains(query) ||
                p.Type.ToLower().Contains(query) ||
                p.Brand.Name.ToLower().Contains(query)
            ).ToList();
        }


        public void UpdateStock(int newStock)
        {
            StockQuantity = newStock;
            Alert.CheckAndGenerateAlert(this);
        }

        // Método para atualizar produto
        public static void UpdateProduct(Product updatedProduct)
        {
            var products = LoadProducts();
            var index = products.FindIndex(p => p.Name == updatedProduct.Name && p.Brand.Name == updatedProduct.Brand.Name);

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

        // Método para eliminar produto
        public static void DeleteProduct(string name, string brandName)
        {
            var products = LoadProducts();
            var productToDelete = products.FirstOrDefault(p => p.Name == name && p.Brand.Name == brandName);

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
    }
}
