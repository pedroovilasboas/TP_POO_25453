using System;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for managing products in the system.
    /// Provides functionality for viewing, searching, editing, and deleting products.
    /// Includes a data grid view to display all products and their details, with search and filter capabilities.
    /// </summary>
    public partial class ManageProductForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the ManageProductForm.
        /// </summary>
        public ManageProductForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form load event.
        /// Loads and displays all products when the form is initialized.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ManageProductForm_Load(object sender, EventArgs e)
        {
            RefreshProductList();
        }

        /// <summary>
        /// Refreshes the product list in the data grid view.
        /// Loads all products from storage and displays them.
        /// </summary>
        private void RefreshProductList()
        {
            var products = Product.LoadProducts();
            DisplayResults(products);
        }

        /// <summary>
        /// Displays the list of products in the data grid view.
        /// Sets up columns for Product ID, Name, Description, Brand, Category,
        /// Price, and Stock Quantity.
        /// </summary>
        /// <param name="products">List of products to display.</param>
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

        /// <summary>
        /// Handles the search button click event.
        /// Searches for products based on the entered query and displays results.
        /// If query is empty, displays all products.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var query = textBoxSearch.Text;

            var results = string.IsNullOrEmpty(query) ? Product.LoadProducts() : Product.SearchProducts(query);
            DisplayResults(results);
        }


        /// <summary>
        /// Handles the stock update button click event.
        /// Opens the UpdateStockForm for the selected product.
        /// Shows error messages if no product or multiple products are selected.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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

        /// <summary>
        /// Handles the edit button click event.
        /// Opens the EditProductForm for the selected product.
        /// Shows error messages if no product or multiple products are selected.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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

        /// <summary>
        /// Alternative handler for the edit button click event.
        /// Opens the EditProductForm for the selected product.
        /// Shows error messages if no product or multiple products are selected.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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
