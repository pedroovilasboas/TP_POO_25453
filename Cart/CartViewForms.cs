using System;
using System.Linq;
using System.Windows.Forms;
using static POO_25453_TP.Cart;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for viewing and managing the shopping cart.
    /// Provides functionality for viewing cart items, updating quantities,
    /// removing items, and proceeding to checkout. Displays item details
    /// including prices, discounts, and total savings.
    /// </summary>
    public partial class CartViewForm : Form
    {
        private Cart cart;
        private Label lblTotal;

        /// <summary>
        /// Initializes a new instance of the CartViewForm.
        /// </summary>
        /// <param name="clientID">ID of the client whose cart to display.</param>
        public CartViewForm(int clientID)
        {
            InitializeComponent();
            this.cart = Cart.LoadCart(clientID);

            // Initialize and configure the total label
            lblTotal = new Label
            {
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(dgvCartItems.Right - 300, dgvCartItems.Bottom + 10),
                Size = new System.Drawing.Size(280, 25),
                TextAlign = System.Drawing.ContentAlignment.MiddleRight
            };
            this.Controls.Add(lblTotal);

            LoadCartItems();
        }

        /// <summary>
        /// Handles the form load event.
        /// Loads and displays the cart items.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void CartViewForm_Load(object sender, EventArgs e)
        {
            LoadCartItems();
        }

        /// <summary>
        /// Loads and displays cart items in the data grid view.
        /// Shows product details, quantities, prices, and savings.
        /// Highlights items with active discounts.
        /// </summary>
        private void LoadCartItems()
        {
            dgvCartItems.Rows.Clear();
            dgvCartItems.Columns.Clear();

            dgvCartItems.Columns.Add("ProductID", "Product ID");
            dgvCartItems.Columns.Add("ProductName", "Product Name");
            dgvCartItems.Columns.Add("Quantity", "Quantity");
            dgvCartItems.Columns.Add("OriginalPrice", "Original Price");
            dgvCartItems.Columns.Add("DiscountedPrice", "Price with Discount");
            dgvCartItems.Columns.Add("Savings", "Savings");
            dgvCartItems.Columns.Add("TotalPrice", "Total Price");

            foreach (var item in cart.Items)
            {
                decimal savings = (item.OriginalPrice - item.DiscountedPrice) * item.Quantity;
                decimal totalPrice = item.DiscountedPrice * item.Quantity;

                var row = dgvCartItems.Rows.Add(
                    item.ProductID,
                    item.ProductName,
                    item.Quantity,
                    item.OriginalPrice.ToString("C"),
                    item.DiscountedPrice.ToString("C"),
                    savings > 0 ? savings.ToString("C") : "-",
                    totalPrice.ToString("C")
                );

                // Highlight rows with discounts
                if (item.DiscountedPrice < item.OriginalPrice)
                {
                    dgvCartItems.Rows[row].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                }
            }

            // Calculate and display the total
            decimal cartTotal = cart.Items.Sum(item => item.DiscountedPrice * item.Quantity);
            decimal originalTotal = cart.Items.Sum(item => item.OriginalPrice * item.Quantity);
            decimal totalSavings = originalTotal - cartTotal;

            lblTotal.Text = $"Total: {cartTotal:C}";
            if (totalSavings > 0)
            {
                lblTotal.Text += $" (You save: {totalSavings:C})";
            }

            // Reset txtQuantity when the cart is loaded
            txtQuantity.Text = string.Empty;
        }

        /// <summary>
        /// Handles the increase quantity button click event.
        /// Increases the quantity of the selected cart item by one.
        /// Updates the display and saves changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnIncreaseQuantity_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCartItems.SelectedRows[0];
                int productId = int.Parse(selectedRow.Cells["ProductID"].Value.ToString());
                var cartItem = cart.Items.FirstOrDefault(item => item.ProductID == productId);

                if (cartItem != null)
                {
                    cartItem.Quantity++;
                    cart.SaveCart();

                    // Update DataGridView and txtQuantity
                    selectedRow.Cells["Quantity"].Value = cartItem.Quantity;
                    selectedRow.Cells["TotalPrice"].Value = (cartItem.DiscountedPrice * cartItem.Quantity).ToString("C");
                    txtQuantity.Text = cartItem.Quantity.ToString();
                }
            }
        }

        /// <summary>
        /// Handles the decrease quantity button click event.
        /// Decreases the quantity of the selected cart item by one.
        /// Shows warning if quantity would go below 1.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnDecreaseQuantity_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCartItems.SelectedRows[0];
                int productId = int.Parse(selectedRow.Cells["ProductID"].Value.ToString());
                var cartItem = cart.Items.FirstOrDefault(item => item.ProductID == productId);

                if (cartItem != null && cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    cart.SaveCart();

                    // Update DataGridView and txtQuantity
                    selectedRow.Cells["Quantity"].Value = cartItem.Quantity;
                    selectedRow.Cells["TotalPrice"].Value = (cartItem.DiscountedPrice * cartItem.Quantity).ToString("C");
                    txtQuantity.Text = cartItem.Quantity.ToString();
                }
                else
                {
                    MessageBox.Show("Cannot decrease quantity below 1. Use the Remove button to remove the item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the selection change event in the cart items grid.
        /// Updates the quantity text box with the selected item's quantity.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void dgvCartItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCartItems.SelectedRows[0];

                // Safeguard for missing column or null value
                if (selectedRow.Cells["Quantity"].Value != null)
                {
                    txtQuantity.Text = selectedRow.Cells["Quantity"].Value.ToString();
                }
            }
        }

        /// <summary>
        /// Handles the remove item button click event.
        /// Removes the selected item from the cart and updates the display.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count > 0)
            {
                int productId = int.Parse(dgvCartItems.SelectedRows[0].Cells[0].Value.ToString());
                cart.Items = cart.Items.Where(item => item.ProductID != productId).ToList();
                cart.SaveCart();
                LoadCartItems();

                // Clear txtQuantity after removing an item
                txtQuantity.Text = string.Empty;
            }
        }

        /// <summary>
        /// Handles the checkout button click event.
        /// Processes the checkout for all items in the cart.
        /// Shows appropriate success or error messages.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cart.Items.Any())
            {
                try
                {
                    cart.Checkout(); // Call the Checkout function in Cart.cs
                    MessageBox.Show("Checkout complete! Your orders have been placed.", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the cart view
                    LoadCartItems();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during checkout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Your cart is empty. Add items to proceed.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handles the cell content click event in the cart items grid.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void dgvCartItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
