using System;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for displaying and interacting with the product catalog.
    /// Provides functionality for viewing products, their details, and prices.
    /// Includes features for adding products to cart and viewing discounted prices from active campaigns.
    /// </summary>
    public partial class ProductListForm : Form
    {
        private Cart cart;

        /// <summary>
        /// Initializes a new instance of the ProductListForm.
        /// </summary>
        /// <param name="clientID">The ID of the client viewing the product list.</param>
        public ProductListForm(int clientID)
        {
            InitializeComponent();
            this.cart = Cart.LoadCart(clientID); // Load the cart for the logged-in client
        }

        /// <summary>
        /// Handles the form load event. Initializes the product list display.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ProductListForm_Load(object sender, EventArgs e)
        {
            RefreshProductList();
        }

        /// <summary>
        /// Refreshes the product list by reloading all products and displaying them.
        /// </summary>
        private void RefreshProductList()
        {
            var products = Product.LoadProducts();
            DisplayResults(products);
        }

        /// <summary>
        /// Displays the list of products in the data grid view.
        /// Shows product details including prices and any active discounts.
        /// Highlights products with active discounts in green.
        /// </summary>
        /// <param name="products">List of products to display.</param>
        private void DisplayResults(System.Collections.Generic.List<Product> products)
        {
            dgvProducts.Rows.Clear();
            if (dgvProducts.Columns.Count == 0)
            {
                dgvProducts.Columns.Add("ProductID", "Product ID");
                dgvProducts.Columns.Add("Name", "Name");
                dgvProducts.Columns.Add("Brand", "Brand");
                dgvProducts.Columns.Add("Category", "Category");
                dgvProducts.Columns.Add("Description", "Description");
                dgvProducts.Columns.Add("OriginalPrice", "Original Price");
                dgvProducts.Columns.Add("Discount", "Discount");
                dgvProducts.Columns.Add("FinalPrice", "Final Price");
            }

            foreach (var product in products)
            {
                decimal discountedPrice = Campaign.GetDiscountedPrice(product);
                decimal discount = ((product.Price - discountedPrice) / product.Price) * 100;
                
                var row = dgvProducts.Rows.Add(
                    product.ProductID,
                    product.Name,
                    product.Brand?.Name ?? "",
                    product.Category?.Name ?? "",
                    product.Description,
                    product.Price.ToString("C"),
                    discount > 0 ? $"{discount:F0}%" : "-",
                    discountedPrice.ToString("C")
                );

                if (discount > 0)
                {
                    dgvProducts.Rows[row].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                }
            }
        }

        /// <summary>
        /// Handles the add to cart button click event. Adds the selected product
        /// to the cart with the specified quantity, applying any active discounts.
        /// Shows appropriate success or error messages.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var selectedRow = dgvProducts.SelectedRows[0];
                int productId = int.Parse(selectedRow.Cells["ProductID"].Value.ToString());

                var product = Product.LoadProducts().FirstOrDefault(p => p.ProductID == productId);
                if (product != null)
                {
                    if (int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
                    {
                        decimal discountedPrice = Campaign.GetDiscountedPrice(product);
                        cart.AddToCart(product, quantity);

                        string message = $"{quantity} units of {product.Name} added to cart!";
                        if (discountedPrice < product.Price)
                        {
                            message += $"\nPrice with discount: {discountedPrice:C}";
                        }

                        MessageBox.Show(message, "Cart Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product.", "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /// <summary>
        /// Handles the increase quantity button click event.
        /// Increments the quantity value by 1.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnIncreaseQuantity_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtQuantity.Text, out int quantity))
            {
                txtQuantity.Text = (quantity + 1).ToString();
            }
            else
            {
                MessageBox.Show("Invalid quantity. Resetting to 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Text = "1"; // Reset to a valid quantity
            }
        }

        /// <summary>
        /// Handles the decrease quantity button click event.
        /// Decrements the quantity value by 1, ensuring it doesn't go below 1.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnDecreaseQuantity_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtQuantity.Text, out int quantity) && quantity > 1)
            {
                txtQuantity.Text = (quantity - 1).ToString();
            }
            else
            {
                MessageBox.Show("Quantity cannot be less than 1.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Text = "1"; // Reset to a valid quantity
            }
        }


        /// <summary>
        /// Handles the close button click event. Closes the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
