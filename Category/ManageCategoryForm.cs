using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class ManageCategoryForm : Form
    {
        public ManageCategoryForm()
        {
            InitializeComponent();
        }

        private void ManageCategoryForm_Load(object sender, EventArgs e)
        {
            // Load all categories when the form loads
            var categories = Category.LoadCategories();
            DisplayResults(categories);
        }

        // If the search box is empty, load all categories; otherwise, search for the query
        private void buttonGo_Click(object sender, EventArgs e)
        {
            string query = textBoxSearch.Text;

            var results = string.IsNullOrEmpty(query) ? Category.LoadCategories() : Category.SearchCategories(query);
            DisplayResults(results);
        }


        private void DisplayResults(List<Category> results)
        {
            // Clear and configure DataGridView columns
            dataGridViewResults.Columns.Clear();
            dataGridViewResults.Columns.Add("CategoryId", "ID");
            dataGridViewResults.Columns.Add("Name", "Name");
            dataGridViewResults.Columns.Add("Description", "Description");

            dataGridViewResults.Rows.Clear();
            foreach (var category in results)
            {
                dataGridViewResults.Rows.Add(category.CategoryId, category.Name, category.Description);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Ensure one row is selected
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one category to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get selected category ID
            int selectedId = int.Parse(dataGridViewResults.SelectedRows[0].Cells["CategoryId"].Value.ToString());
            var category = Category.LoadCategories().Find(c => c.CategoryId == selectedId);

            if (category != null)
            {
                // Open the EditCategoryForm with selected category data
                EditCategoryForm editForm = new EditCategoryForm(category);
                editForm.ShowDialog();

                // Refresh the results after editing
                var results = Category.LoadCategories();
                DisplayResults(results);
            }
            else
            {
                MessageBox.Show("Category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Ensure one row is selected
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one category to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get selected category ID
            int selectedId = int.Parse(dataGridViewResults.SelectedRows[0].Cells["CategoryId"].Value.ToString());

            var confirmResult = MessageBox.Show("Are you sure you want to delete this category?",
                                                 "Confirm Delete",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Delete the category
                Category.DeleteCategory(selectedId);

                // Refresh the results after deletion
                var results = Category.LoadCategories();
                DisplayResults(results);

                MessageBox.Show("Category deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }
    }
}
