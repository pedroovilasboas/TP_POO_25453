using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class ManageBrandForm : Form
    {
        public ManageBrandForm()
        {
            InitializeComponent();
        }

        private void ManageBrandForm_Load(object sender, EventArgs e)
        {
            // Load all brands when the form loads
            RefreshBrandList();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            string query = textBoxSearch.Text;

            // If the query is empty, list all brands; otherwise, search for the query
            var results = string.IsNullOrEmpty(query) ? Brand.LoadBrands() : Brand.SearchBrands(query);
            DisplayResults(results);
        }

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

        private void RefreshBrandList()
        {
            // Load all brands and display them in the grid
            var allBrands = Brand.LoadBrands();
            DisplayResults(allBrands);
        }

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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
