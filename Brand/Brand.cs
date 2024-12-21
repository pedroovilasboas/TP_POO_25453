using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Represents a product brand in the e-commerce system.
    /// Manages brand information and provides CRUD operations.
    /// </summary>
    public class Brand
    {
        /// <summary>
        /// Unique identifier for the brand
        /// </summary>
        public int BrandID { get; set; }

        /// <summary>
        /// Name of the brand
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the brand
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// File path for storing brand data
        /// </summary>
        private static string brandsFile = @"C:\PROGRAM_CS\TP_POO_25453\Brand\brands.txt";

        /// <summary>
        /// Tracks the last used brand ID for auto-increment
        /// </summary>
        private static int lastBrandID = 0;

        /// <summary>
        /// Constructor for creating a new brand
        /// Automatically generates a new brand ID
        /// </summary>
        /// <param name="name">Brand name</param>
        /// <param name="description">Brand description</param>
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

        /// <summary>
        /// Constructor for loading existing brands from storage
        /// </summary>
        /// <param name="id">Existing brand ID</param>
        /// <param name="name">Brand name</param>
        /// <param name="description">Brand description</param>
        public Brand(int id, string name, string description)
        {
            BrandID = id;
            Name = name;
            Description = description;

            if (id > lastBrandID)
            {
                lastBrandID = id;
            }
        }

        /// <summary>
        /// Saves the current brand to storage
        /// </summary>
        public void Save()
        {
            var brands = LoadBrands();
            brands.Add(this);
            SaveBrands(brands);
        }

        /// <summary>
        /// Loads all brands from storage
        /// </summary>
        /// <returns>List of all brands in the system</returns>
        public static List<Brand> LoadBrands()
        {
            var brands = new List<Brand>();

            if (File.Exists(brandsFile))
            {
                var lines = File.ReadAllLines(brandsFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 3)
                    {
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        string description = parts[2];

                        brands.Add(new Brand(id, name, description));
                    }
                }

                lastBrandID = brands.Any() ? brands.Max(b => b.BrandID) : 0;
            }

            return brands;
        }

        /// <summary>
        /// Saves multiple brands to storage
        /// </summary>
        /// <param name="brands">List of brands to save</param>
        public static void SaveBrands(List<Brand> brands)
        {
            using (var writer = new StreamWriter(brandsFile))
            {
                foreach (var brand in brands)
                {
                    writer.WriteLine($"{brand.BrandID};{brand.Name};{brand.Description}");
                }
            }
        }

        /// <summary>
        /// Searches for brands based on name or description
        /// </summary>
        /// <param name="query">Search term to match against name or description</param>
        /// <returns>List of matching brands</returns>
        public static List<Brand> SearchBrands(string query)
        {
            var brands = LoadBrands();
            query = query.ToLower();

            return brands.Where(b => b.Name.ToLower().Contains(query) || b.Description.ToLower().Contains(query)).ToList();
        }

        /// <summary>
        /// Updates an existing brand's information
        /// </summary>
        /// <param name="updatedBrand">Brand with updated information</param>
        public static void UpdateBrand(Brand updatedBrand)
        {
            var brands = LoadBrands();
            var index = brands.FindIndex(brd => brd.BrandID == updatedBrand.BrandID);

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

        /// <summary>
        /// Deletes a brand from the system
        /// </summary>
        /// <param name="id">ID of the brand to delete</param>
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
