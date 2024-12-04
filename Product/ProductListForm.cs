using System;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class ProductListForm : Form
    {
        private System.Collections.Generic.List<Product> cart = new System.Collections.Generic.List<Product>();

        public ProductListForm()
        {
            InitializeComponent();
        }

        private void ProductListForm_Load(object sender, EventArgs e)
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
            // Clear existing rows and columns
            dgvProducts.Rows.Clear();
            dgvProducts.Columns.Clear();

            // Add columns
            dgvProducts.Columns.Add("ProductID", "Product ID");
            dgvProducts.Columns.Add("Name", "Name");
            dgvProducts.Columns.Add("Description", "Description");
            dgvProducts.Columns.Add("Brand", "Brand");
            dgvProducts.Columns.Add("Category", "Category");
            dgvProducts.Columns.Add("Price", "Price");
            dgvProducts.Columns.Add("StockQuantity", "Stock Quantity");

            // Populate rows
            foreach (var product in products)
            {
                dgvProducts.Rows.Add(
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var query = txtSearch.Text;

            var results = string.IsNullOrEmpty(query) ? Product.LoadProducts() : Product.SearchProducts(query);
            DisplayResults(results);
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a product to add to the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int productId;
            if (!int.TryParse(dgvProducts.SelectedRows[0].Cells["ProductID"].Value?.ToString(), out productId))
            {
                MessageBox.Show("Invalid Product ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var product = Product.LoadProducts().FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                // Validate quantity
                if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0 || quantity > product.StockQuantity)
                {
                    MessageBox.Show("Invalid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Add to cart without modifying the stock in the file
                cart.Add(new Product(
                    product.ProductID,
                    product.Category,
                    product.Brand,
                    product.Name,
                    product.Description,
                    product.Type,
                    product.Price,
                    quantity
                ));

                MessageBox.Show($"Added {quantity} of {product.Name} to the cart.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
