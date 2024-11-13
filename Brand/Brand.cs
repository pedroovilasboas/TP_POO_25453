using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _25453_TP_POO
{
    public class Brand
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // File path for brands.txt
        private static string brandsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Brand\brands.txt");

        public Brand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        // Method to save a brand
        public void Save()
        {
            var brands = LoadBrands();
            brands.Add(this);
            SaveBrands(brands);
        }

        // Method to load all brands from file
        public static List<Brand> LoadBrands()
        {
            var brands = new List<Brand>();

            if (File.Exists(brandsFile))
            {
                var lines = File.ReadAllLines(brandsFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        brands.Add(new Brand(parts[0], parts[1]));
                    }
                }
            }

            return brands;
        }

        // Method to save a list of brands to file
        public static void SaveBrands(List<Brand> brands)
        {
            using (var writer = new StreamWriter(brandsFile))
            {
                foreach (var brand in brands)
                {
                    writer.WriteLine($"{brand.Name},{brand.Description}");
                }
            }
        }

        // Method to search brands by name or description
        public static List<Brand> SearchBrands(string query)
        {
            var brands = LoadBrands();
            query = query.ToLower();

            return brands.Where(b => b.Name.ToLower().Contains(query) || b.Description.ToLower().Contains(query)).ToList();
        }

        // Method to update a brand
        public static void UpdateBrand(Brand updatedBrand)
        {
            var brands = LoadBrands();
            var index = brands.FindIndex(brd => brd.Name == updatedBrand.Name);

            if (index != -1)
            {
                brands[index] = updatedBrand;
                SaveBrands(brands);
            }
            else
            {
                MessageBox.Show("Brand not found for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to delete a brand by name
        public static void DeleteBrand(string name)
        {
            var brands = LoadBrands();
            var brandToDelete = brands.FirstOrDefault(brd => brd.Name == name);

            if (brandToDelete != null)
            {
                brands.Remove(brandToDelete);
                SaveBrands(brands);
            }
            else
            {
                MessageBox.Show("Brand not found for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
