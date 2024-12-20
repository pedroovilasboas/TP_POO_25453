using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for managing product brands in the system.
    /// Provides functionality for viewing, searching, editing, and deleting brands.
    /// Displays brands in a data grid view with ID, name, and description.
    /// </summary>
    public partial class ManageBrandForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the ManageBrandForm.
        /// </summary>
        public ManageBrandForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form load event.
        /// Loads and displays all brands when the form is initialized.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ManageBrandForm_Load(object sender, EventArgs e)
        {
            // Load all brands when the form loads
            RefreshBrandList();
        }

        /// <summary>
        /// Handles the search button click event.
        /// Searches for brands based on the entered query and displays results.
        /// If query is empty, displays all brands.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void buttonGo_Click(object sender, EventArgs e)
        {
            string query = textBoxSearch.Text;

            // If the query is empty, list all brands; otherwise, search for the query
            var results = string.IsNullOrEmpty(query) ? Brand.LoadBrands() : Brand.SearchBrands(query);
            DisplayResults(results);
        }

        /// <summary>
        /// Displays the list of brands in the data grid view.
        /// Sets up columns for Brand ID, Name, and Description.
        /// </summary>
        /// <param name="results">List of brands to display.</param>
        private void DisplayResults(List<Brand> results)
        {
            // Clear existing columns and rows
            dataGridViewResults.Columns.Clear();
            dataGridViewResults.Rows.Clear();

            // Add columns for Brand ID, Name, and Description
            dataGridViewResults.Columns.Add("BrandID", "Brand ID");
            dataGridViewResults.Columns.Add("Name", "Name");
            dataGridViewResults.Columns.Add("Description", "Description");

            // Add rows for each brand in the results
            foreach (var brand in results)
            {
                dataGridViewResults.Rows.Add(brand.BrandID, brand.Name, brand.Description);
            }
        }

        /// <summary>
        /// Refreshes the brand list in the data grid view.
        /// Loads all brands from storage and displays them.
        /// </summary>
        private void RefreshBrandList()
        {
            // Load all brands and display them in the grid
            var allBrands = Brand.LoadBrands();
            DisplayResults(allBrands);
        }

        /// <summary>
        /// Handles the edit button click event.
        /// Opens the EditBrandForm for the selected brand.
        /// Shows error messages if no brand or multiple brands are selected.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Ensure exactly one row is selected
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one brand to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Retrieve the selected Brand ID from the grid
            int selectedId = Convert.ToInt32(dataGridViewResults.SelectedRows[0].Cells["BrandID"].Value);

            // Find the brand by ID
            var brand = Brand.LoadBrands().FirstOrDefault(brd => brd.BrandID == selectedId);

            if (brand != null)
            {
                // Open the EditBrandForm with the selected brand
                EditBrandForm editForm = new EditBrandForm(brand);
                editForm.ShowDialog();

                // Refresh the brand list after editing
                RefreshBrandList();
            }
            else
            {
                MessageBox.Show("Brand not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the delete button click event.
        /// Deletes the selected brand after confirmation.
        /// Shows error messages if no brand or multiple brands are selected.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Ensure exactly one row is selected
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one brand to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Retrieve the selected Brand ID from the grid
            int selectedId = Convert.ToInt32(dataGridViewResults.SelectedRows[0].Cells["BrandID"].Value);

            // Confirm deletion
            var confirmResult = MessageBox.Show("Are you sure you want to delete this brand?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Delete the brand and refresh the list
                Brand.DeleteBrand(selectedId);
                RefreshBrandList();
                MessageBox.Show("Brand deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the close button click event. Closes the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
