using System;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class ProductListForm : Form
    {
        // Instance of the Cart to store products and quantities
        private Cart cart;

        public ProductListForm(Cart cart)
        {
            InitializeComponent();
            this.cart = new Cart(); 
        }

        // Event triggered when the form loads
        private void ProductListForm_Load(object sender, EventArgs e)
        {
            RefreshProductList(); 
        }

        // Refresh the product list from the file and display them
        private void RefreshProductList()
        {
            var products = Product.LoadProducts(); 
            DisplayResults(products); 
        }

        // Populate the DataGridView with product information
        private void DisplayResults(System.Collections.Generic.List<Product> products)
        {
            dgvProducts.Rows.Clear();
            dgvProducts.Columns.Clear();

            
            dgvProducts.Columns.Add("ProductID", "Product ID");
            dgvProducts.Columns.Add("Name", "Name");
            dgvProducts.Columns.Add("Description", "Description");
            dgvProducts.Columns.Add("Brand", "Brand");
            dgvProducts.Columns.Add("Category", "Category");
            dgvProducts.Columns.Add("Price", "Price");
            dgvProducts.Columns.Add("StockQuantity", "Stock Quantity");

            
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

        // Search products based on the query entered in the search box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var query = txtSearch.Text;

            // If query is empty, load all products; otherwise, perform a search
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

            // Get the selected product ID
            if (!int.TryParse(dgvProducts.SelectedRows[0].Cells["ProductID"].Value?.ToString(), out int productId))
            {
                MessageBox.Show("Invalid Product ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Find the product in the loaded product list
            var product = Product.LoadProducts().FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                // Validate the entered quantity
                if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Invalid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Add the product and quantity to the cart
                cart.AddToCart(product, quantity);

                MessageBox.Show($"Added {quantity} of {product.Name} to the cart.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
