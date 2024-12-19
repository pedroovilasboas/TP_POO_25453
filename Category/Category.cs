using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public class Category
    {
        // Properties for Category
        public int CategoryId { get; private set; } // ID is now read-only
        public string Name { get; set; }
        public string Description { get; set; }

        // File path for categories.txt
        private static string categoriesFile = @"C:\PROGRAM_CS\TP_POO_25453\Category\categories.txt";

        // Static field to store the last used ID
        private static int lastCategoryId = 0;

        // Constructor for creating an existing categor
        public Category(int categoryId, string name, string description)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
        }


        // Constructor for creating an new category
        public Category(string name, string description)
        {
            // Increment lastCategoryId based on the current value
            if (lastCategoryId == 0)
            {
                var categories = LoadCategories();
                lastCategoryId = categories.Any() ? categories.Max(c => c.CategoryId) : 0;
            }

            CategoryId = ++lastCategoryId; // Assign the next available ID
            Name = name;
            Description = description;
        }


        // Method to save a category
        public void Save()
        {
            var categories = LoadCategories();
            categories.Add(this); // Add the new category to the list
            SaveCategories(categories);
        }

        public static List<Category> LoadCategories()
        {
            var categories = new List<Category>();

            if (File.Exists(categoriesFile))
            {
                var lines = File.ReadAllLines(categoriesFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        int categoryId = int.Parse(parts[0]);
                        string name = parts[1];
                        string description = parts[2];

                        categories.Add(new Category(categoryId, name, description)); // Use o construtor com 3 argumentos
                    }
                }

                // Atualiza o último ID usado
                lastCategoryId = categories.Any() ? categories.Max(c => c.CategoryId) : 0;
            }

            return categories;
        }


        // Method to save a list of categories to file
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

        // Method to search categories by name or description
        public static List<Category> SearchCategories(string query)
        {
            var categories = LoadCategories();
            query = query.ToLower();

            return categories.Where(c =>
                c.Name.ToLower().Contains(query) ||
                c.Description.ToLower().Contains(query)
            ).ToList();
        }

        // Method to update an existing category
        public static void UpdateCategory(Category updatedCategory)
        {
            var categories = LoadCategories();
            var index = categories.FindIndex(c => c.CategoryId == updatedCategory.CategoryId);

            if (index != -1)
            {
                categories[index] = updatedCategory;
                SaveCategories(categories);
            }
            else
            {
                MessageBox.Show("Category not found for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to delete a category by ID
        public static void DeleteCategory(int categoryId)
        {
            var categories = LoadCategories();
            var categoryToDelete = categories.FirstOrDefault(c => c.CategoryId == categoryId);

            if (categoryToDelete != null)
            {
                categories.Remove(categoryToDelete);
                SaveCategories(categories);
            }
            else
            {
                MessageBox.Show("Category not found for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
