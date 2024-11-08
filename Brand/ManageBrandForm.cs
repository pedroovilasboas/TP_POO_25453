using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _25453_TP_POO
{
    public partial class ManageBrandForm : Form
    {
        public ManageBrandForm()
        {
            InitializeComponent();
        }

        private void ManageBrandForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            string query = textBoxSearch.Text;

            var results = Brand.SearchBrands(query);

            DisplayResults(results);
        }

        private void DisplayResults(List<Brand> results)
        {
            dataGridViewResults.Columns.Clear();
            dataGridViewResults.Columns.Add("BrandName", "Brand Name");
            dataGridViewResults.Columns.Add("Description", "Description");

            dataGridViewResults.Rows.Clear();
            foreach (var brand in results)
            {
                dataGridViewResults.Rows.Add(brand.BrandName, brand.Description);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one brand to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedBrandName = dataGridViewResults.SelectedRows[0].Cells["BrandName"].Value.ToString();
            var brand = Brand.LoadBrands().Find(br => br.BrandName == selectedBrandName);

            if (brand != null)
            {
               // EditBrandForm editForm = new EditBrandForm(brand);
              //  &&editForm.ShowDialog();

                string query = textBoxSearch.Text;
                var results = Brand.SearchBrands(query);
                DisplayResults(results);
            }
            else
            {
                MessageBox.Show("Brand not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one brand to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedBrandName = dataGridViewResults.SelectedRows[0].Cells["BrandName"].Value.ToString();

            var confirmResult = MessageBox.Show("Are you sure you want to delete this brand?",
                                                 "Confirm Delete",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                Brand.DeleteBrand(selectedBrandName);

                string query = textBoxSearch.Text;
                var results = Brand.SearchBrands(query);
                DisplayResults(results);

                MessageBox.Show("Brand deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
