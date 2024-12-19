using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public class Brand
    {
        public int BrandID { get; set; } // Unique identifier for each brand
        public string Name { get; set; }
        public string Description { get; set; }

        // File path for brands.txt
        private static string brandsFile = @"C:\PROGRAM_CS\TP_POO_25453\Brand\brands.txt";

        // Static field to keep track of the last used ID
        private static int lastBrandID = 0;

        // Constructor for creating a new brand with a unique ID
        public Brand(string name, string description)
        {
            if (lastBrandID == 0)
            {
                var brands = LoadBrands(); 
                lastBrandID = brands.Any() ? brands.Max(b => b.BrandID) : 0;
            }

            BrandID = ++lastBrandID; 
            Name = name;
            Description = description;
        }


        // Constructor for loading an existing brand from file with a specific ID
        public Brand(int id, string name, string description)
        {
            BrandID = id;
            Name = name;
            Description = description;

            // Update lastBrandID to ensure unique IDs for future brands
            if (id > lastBrandID)
            {
                lastBrandID = id;
            }
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
                    if (parts.Length == 3)
                    {
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        string description = parts[2];

                        brands.Add(new Brand(id, name, description));
                    }
                }

                // Update the lastBrandID to ensure unique IDs
                lastBrandID = brands.Any() ? brands.Max(b => b.BrandID) : 0;
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
                    // Save each brand as "ID,Name,Description"
                    writer.WriteLine($"{brand.BrandID},{brand.Name},{brand.Description}");
                }
            }
        }

        // Method to search brands by name or description
        public static List<Brand> SearchBrands(string query)
        {
            var brands = LoadBrands();
            query = query.ToLower();

            // Return brands where name or description contains the search query
            return brands.Where(b => b.Name.ToLower().Contains(query) || b.Description.ToLower().Contains(query)).ToList();
        }

        // Method to update a brand by ID
        public static void UpdateBrand(Brand updatedBrand)
        {
            var brands = LoadBrands();
            var index = brands.FindIndex(brd => brd.BrandID == updatedBrand.BrandID);

            if (index != -1)
            {
                // Replace the old brand with the updated one
                brands[index] = updatedBrand;
                SaveBrands(brands);
            }
            else
            {
                MessageBox.Show("Brand not found for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to delete a brand by ID
        public static void DeleteBrand(int id)
        {
            var brands = LoadBrands();
            var brandToDelete = brands.FirstOrDefault(brd => brd.BrandID == id);

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
