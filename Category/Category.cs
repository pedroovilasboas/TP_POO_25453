using System;
using System.Collections.Generic;
using System.IO;

namespace _25453_TP_POO
{
    public class Category
    {
        // Properties for Category
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Path to the file where categories will be saved
        private static string categoriesFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "categories.txt");

        // Constructor to initialize Category with ID, Name, and Description
        public Category(int categoryId, string name, string description)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
        }

        // Method to save a new category to the file
        public void Save()
        {
            var categories = LoadCategories();
            categories.Add(this);
            SaveCategories(categories);
        }

        // Method to load categories from the file
        public static List<Category> LoadCategories()
        {
            var categories = new List<Category>();

            if (File.Exists(categoriesFile))
            {
                var lines = File.ReadAllLines(categoriesFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 3)
                    {
                        int categoryId = int.Parse(parts[0]);
                        string name = parts[1];
                        string description = parts[2];
                        categories.Add(new Category(categoryId, name, description));
                    }
                }
            }

            return categories;
        }

        // Method to save all categories to the file
        public static void SaveCategories(List<Category> categories)
        {
            using (var writer = new StreamWriter(categoriesFile))
            {
                foreach (var category in categories)
                {
                    writer.WriteLine($"{category.CategoryId},{category.Name},{category.Description}");
                }
            }
        }
    }
}
