using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _25453_TP_POO
{
    public partial class ManageProductForm : Form
    {
        public ManageProductForm()
        {
            InitializeComponent();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            string query = textBoxSearch.Text;
            var results = Product.SearchProducts(query);
            DisplayResults(results);
        }

        private void DisplayResults(List<Product> results)
        {
            dataGridViewResults.Columns.Clear();
            dataGridViewResults.Columns.Add("Brand", "Brand");
            dataGridViewResults.Columns.Add("Name", "Name");
            dataGridViewResults.Columns.Add("Description", "Description");
            dataGridViewResults.Columns.Add("Type", "Type");
            dataGridViewResults.Columns.Add("Price", "Price");
            dataGridViewResults.Columns.Add("StockQuantity", "Stock Quantity");

            dataGridViewResults.Rows.Clear();
            foreach (var product in results)
            {
                dataGridViewResults.Rows.Add(product.Brand.Name, product.Name, product.Description, product.Type, product.Price, product.StockQuantity);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one product to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedName = dataGridViewResults.SelectedRows[0].Cells["Name"].Value.ToString();
            var product = Product.LoadProducts().Find(prod => prod.Name == selectedName);

            if (product != null)
            {
                EditProductForm editForm = new EditProductForm(product);
                editForm.ShowDialog();

                string query = textBoxSearch.Text;
                var results = Product.SearchProducts(query);
                DisplayResults(results);
            }
            else
            {
                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedName = dataGridViewResults.SelectedRows[0].Cells["Name"].Value.ToString();

            var confirmResult = MessageBox.Show("Are you sure you want to delete this product?",
                                                 "Confirm Delete",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                Product.DeleteProduct(selectedName);

                string query = textBoxSearch.Text;
                var results = Product.SearchProducts(query);
                DisplayResults(results);

                MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
