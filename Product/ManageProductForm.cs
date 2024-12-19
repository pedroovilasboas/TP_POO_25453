using System;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class ManageProductForm : Form
    {
        public ManageProductForm()
        {
            InitializeComponent();
        }

        private void ManageProductForm_Load(object sender, EventArgs e)
        {
            RefreshProductList();
        }

        private void RefreshProductList()
        {
            var products = Product.LoadProducts();
            DisplayResults(products);
        }

        private void DisplayResults(System.Collections.Generic.List<Product> products)
        {
            // Clear the existing rows and columns
            dataGridViewResults.Rows.Clear();
            dataGridViewResults.Columns.Clear();

            // Add columns including Description
            dataGridViewResults.Columns.Add("ProductID", "Product ID");
            dataGridViewResults.Columns.Add("Name", "Name");
            dataGridViewResults.Columns.Add("Description", "Description");
            dataGridViewResults.Columns.Add("Brand", "Brand");
            dataGridViewResults.Columns.Add("Category", "Category");
            dataGridViewResults.Columns.Add("Price", "Price");
            dataGridViewResults.Columns.Add("StockQuantity", "Stock Quantity");

            
            foreach (var product in products)
            {
                dataGridViewResults.Rows.Add(
                    product.ProductID,
                    product.Name,
                    product.Description, 
                    product.Brand?.Name ?? "N/A", 
                    product.Category?.Name ?? "N/A", 
                    product.Price,
                    product.StockQuantity
                );
            }
        }

        // If the search box is empty, load all products; otherwise, search for the query
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var query = textBoxSearch.Text;

            var results = string.IsNullOrEmpty(query) ? Product.LoadProducts() : Product.SearchProducts(query);
            DisplayResults(results);
        }


        private void buttonStock_Click(object sender, EventArgs e)
        {
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a product to update stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int productId;
            if (!int.TryParse(dataGridViewResults.SelectedRows[0].Cells["ProductID"].Value?.ToString(), out productId))
            {
                MessageBox.Show("Invalid Product ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var product = Product.LoadProducts().FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                using (var stockForm = new UpdateStockForm(product))
                {
                    stockForm.ShowDialog();
                }
                RefreshProductList(); // Refresh the grid after stock update
            }
            else
            {
                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select one product to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var productId = int.Parse(dataGridViewResults.SelectedRows[0].Cells[0].Value.ToString());
            var product = Product.LoadProducts().FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                using (var editForm = new EditProductForm(product))
                {
                    editForm.ShowDialog();
                }
                RefreshProductList();
            }
        }

        private void buttonEdit_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select one product to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var productId = int.Parse(dataGridViewResults.SelectedRows[0].Cells[0].Value.ToString());
            var product = Product.LoadProducts().FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                using (var editForm = new EditProductForm(product))
                {
                    editForm.ShowDialog();
                }
                RefreshProductList(); // update table after editing
            }
            else
            {
                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
