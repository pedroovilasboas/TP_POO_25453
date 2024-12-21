using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Represents a product category in the e-commerce system.
    /// Manages category information and provides CRUD operations.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Unique identifier for the category
        /// </summary>
        public int CategoryId { get; private set; }

        /// <summary>
        /// Name of the category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the category
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// File path for storing category data
        /// </summary>
        private static string categoriesFile = @"C:\PROGRAM_CS\TP_POO_25453\Category\categories.txt";

        /// <summary>
        /// Tracks the last used category ID for auto-increment
        /// </summary>
        private static int lastCategoryId = 0;

        /// <summary>
        /// Constructor for loading existing categories from storage
        /// </summary>
        /// <param name="categoryId">Existing category ID</param>
        /// <param name="name">Category name</param>
        /// <param name="description">Category description</param>
        public Category(int categoryId, string name, string description)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Constructor for creating new categories
        /// Automatically generates a new category ID
        /// </summary>
        /// <param name="name">Category name</param>
        /// <param name="description">Category description</param>
        public Category(string name, string description)
        {
            if (lastCategoryId == 0)
            {
                var categories = LoadCategories();
                lastCategoryId = categories.Any() ? categories.Max(c => c.CategoryId) : 0;
            }

            CategoryId = ++lastCategoryId;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Saves the current category to storage
        /// </summary>
        public void Save()
        {
            var categories = LoadCategories();
            categories.Add(this);
            SaveCategories(categories);
        }

        /// <summary>
        /// Loads all categories from storage
        /// </summary>
        /// <returns>List of all categories in the system</returns>
        public static List<Category> LoadCategories()
        {
            var categories = new List<Category>();

            if (File.Exists(categoriesFile))
            {
                var lines = File.ReadAllLines(categoriesFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 3)
                    {
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        string description = parts[2];

                        categories.Add(new Category(id, name, description));
                    }
                }

                lastCategoryId = categories.Any() ? categories.Max(c => c.CategoryId) : 0;
            }

            return categories;
        }

        /// <summary>
        /// Saves multiple categories to storage
        /// </summary>
        /// <param name="categories">List of categories to save</param>
        public static void SaveCategories(List<Category> categories)
        {
            using (var writer = new StreamWriter(categoriesFile))
            {
                foreach (var category in categories)
                {
                    writer.WriteLine($"{category.CategoryId};{category.Name};{category.Description}");
                }
            }
        }

        /// <summary>
        /// Searches for categories based on name or description
        /// </summary>
        /// <param name="query">Search term to match against name or description</param>
        /// <returns>List of matching categories</returns>
        public static List<Category> SearchCategories(string query)
        {
            var categories = LoadCategories();
            query = query.ToLower();

            return categories.Where(c =>
                c.Name.ToLower().Contains(query) ||
                c.Description.ToLower().Contains(query)
            ).ToList();
        }

        /// <summary>
        /// Updates an existing category's information
        /// </summary>
        /// <param name="updatedCategory">Category with updated information</param>
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

        /// <summary>
        /// Deletes a category from the system
        /// </summary>
        /// <param name="categoryId">ID of the category to delete</param>
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
