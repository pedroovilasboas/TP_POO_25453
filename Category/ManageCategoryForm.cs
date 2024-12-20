using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for managing product categories in the system.
    /// Provides functionality for viewing, searching, editing, and deleting categories.
    /// Displays categories in a data grid view with ID, name, and description.
    /// </summary>
    public partial class ManageCategoryForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the ManageCategoryForm.
        /// </summary>
        public ManageCategoryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form load event.
        /// Loads and displays all categories when the form is initialized.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ManageCategoryForm_Load(object sender, EventArgs e)
        {
            // Load all categories when the form loads
            var categories = Category.LoadCategories();
            DisplayResults(categories);
        }

        /// <summary>
        /// Handles the search button click event.
        /// Searches for categories based on the entered query and displays results.
        /// If query is empty, displays all categories.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void buttonGo_Click(object sender, EventArgs e)
        {
            string query = textBoxSearch.Text;

            var results = string.IsNullOrEmpty(query) ? Category.LoadCategories() : Category.SearchCategories(query);
            DisplayResults(results);
        }

        /// <summary>
        /// Displays the list of categories in the data grid view.
        /// Sets up columns for Category ID, Name, and Description.
        /// </summary>
        /// <param name="results">List of categories to display.</param>
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

        /// <summary>
        /// Handles the edit button click event.
        /// Opens the EditCategoryForm for the selected category.
        /// Shows error messages if no category or multiple categories are selected.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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

        /// <summary>
        /// Handles the delete button click event.
        /// Deletes the selected category after confirmation.
        /// Shows error messages if no category or multiple categories are selected.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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

        /// <summary>
        /// Handles the close button click event. Closes the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }
    }
}
