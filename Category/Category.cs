using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25453_TP_POO
{
    public class Category
    {
        // Propriedades para Category
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Caminho para o arquivo categories.txt
        private static string categoriesFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Category\category.txt");

        // Construtor para inicializar Category
        public Category(int categoryId, string name, string description)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
        }

        // Método para salvar uma categoria
        public void Save()
        {
            var categories = LoadCategories();
            categories.Add(this);
            SaveCategories(categories);
        }

        // Método para carregar categorias
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

                        categories.Add(new Category(categoryId, name, description));
                    }
                }
            }

            return categories;
        }

        // Método para salvar lista de categorias
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

        // Método para procurar categorias
        public static List<Category> SearchCategories(string query)
        {
            var categories = LoadCategories();
            query = query.ToLower();

            return categories.Where(c =>
                c.Name.ToLower().Contains(query) ||
                c.Description.ToLower().Contains(query)
            ).ToList();
        }

        // Método para atualizar uma categoria
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

        // Método para eliminar uma categoria
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
