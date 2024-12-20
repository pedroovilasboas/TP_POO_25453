using System;
using System.Linq;
using System.Windows.Forms;
using static POO_25453_TP.Cart;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
        /// Initializes a new instance of the CartViewForm
        /// </summary>
        /// <param name="clientID"></param>
        public CartViewForm(int clientID)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing cart view: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Re-throw to be caught by the caller
            }
        }


        /// <summary>
        /// Handles the form load event
        /// Loads and displays the cart items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            try
            {
                if (dgvCartItems.Columns.Count == 0)
                {
                    // Only set up columns if they don't exist
                    SetupDataGridColumns();
                }

                dgvCartItems.Rows.Clear();

                if (cart == null || cart.Items == null)
                {
                    MessageBox.Show("Error: Cart not initialized properly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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

                UpdateTotalDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cart items: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridColumns()
        {
            dgvCartItems.Columns.Clear();
            dgvCartItems.Columns.Add("ProductID", "Product ID");
            dgvCartItems.Columns.Add("ProductName", "Product Name");
            dgvCartItems.Columns.Add("Quantity", "Quantity");
            dgvCartItems.Columns.Add("OriginalPrice", "Original Price");
            dgvCartItems.Columns.Add("DiscountedPrice", "Price with Discount");
            dgvCartItems.Columns.Add("Savings", "Savings");
            dgvCartItems.Columns.Add("TotalPrice", "Total Price");

            // Set column widths for better presentation
            dgvCartItems.Columns["ProductID"].Width = 80;
            dgvCartItems.Columns["ProductName"].Width = 200;
            dgvCartItems.Columns["Quantity"].Width = 80;
            dgvCartItems.Columns["OriginalPrice"].Width = 100;
            dgvCartItems.Columns["DiscountedPrice"].Width = 120;
            dgvCartItems.Columns["Savings"].Width = 100;
            dgvCartItems.Columns["TotalPrice"].Width = 100;
        }

        private void UpdateTotalDisplay()
        {
            decimal cartTotal = cart.Items.Sum(item => item.DiscountedPrice * item.Quantity);
            decimal originalTotal = cart.Items.Sum(item => item.OriginalPrice * item.Quantity);
            decimal totalSavings = originalTotal - cartTotal;

            lblTotal.Text = $"Total: {cartTotal:C}";
            if (totalSavings > 0)
            {
                lblTotal.Text += $" (You save: {totalSavings:C})";
            }
        }

        /// <summary>
        /// Handles the increase quantity button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    LoadCartItems();
                    txtQuantity.Text = cartItem.Quantity.ToString();
                }
            }
        }

        /// <summary>
        /// Handles the decrease quantity button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    LoadCartItems();
                    txtQuantity.Text = cartItem.Quantity.ToString();
                }
                else
                {
                    MessageBox.Show("Cannot decrease quantity below 1. Use the Remove button to remove the item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the selection change event in the cart items grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCartItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCartItems.SelectedRows[0];
                if (selectedRow.Cells["Quantity"].Value != null)
                {
                    txtQuantity.Text = selectedRow.Cells["Quantity"].Value.ToString();
                }
            }
        }

        /// <summary>
        /// Handles the remove item button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count > 0)
            {
                int productId = int.Parse(dgvCartItems.SelectedRows[0].Cells["ProductID"].Value.ToString());
                cart.Items = cart.Items.Where(item => item.ProductID != productId).ToList();
                cart.SaveCart();
                LoadCartItems();
                txtQuantity.Text = string.Empty;
            }
        }

        /// <summary>
        /// Handles the checkout button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cart.Items.Count == 0)
            {
                MessageBox.Show("Your cart is empty.", "Cart Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItems = dgvCartItems.SelectedRows.Count > 0
                ? dgvCartItems.SelectedRows.Cast<DataGridViewRow>()
                    .Select(row => cart.Items.FirstOrDefault(item => 
                        item.ProductID == int.Parse(row.Cells["ProductID"].Value.ToString())))
                    .Where(item => item != null)
                    .ToList()
                : cart.Items.ToList();

            decimal totalAmount = selectedItems.Sum(item => item.DiscountedPrice * item.Quantity);
            string message = dgvCartItems.SelectedRows.Count > 0
                ? $"Proceed with checkout for selected items?\nTotal Amount: {totalAmount:C}"
                : $"Proceed with checkout for all items?\nTotal Amount: {totalAmount:C}";

            if (MessageBox.Show(message, "Confirm Checkout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    cart.Checkout(selectedItems);
                    MessageBox.Show("Checkout complete! Your orders have been placed.", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCartItems();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during checkout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuantity.Text) && dgvCartItems.SelectedRows.Count > 0)
            {
                var currentRow = dgvCartItems.SelectedRows[0];
                
                if (!int.TryParse(txtQuantity.Text, out int newQuantity) || newQuantity <= 0)
                {
                    MessageBox.Show("Please enter a valid positive number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantity.Text = currentRow.Cells["Quantity"].Value.ToString();
                    return;
                }

                int productId = int.Parse(currentRow.Cells["ProductID"].Value.ToString());
                var cartItem = cart.Items.FirstOrDefault(item => item.ProductID == productId);

                if (cartItem != null)
                {
                    // Verify stock availability (assuming you have a way to check stock)
                    cartItem.Quantity = newQuantity;
                    cart.SaveCart();
                    LoadCartItems();
                }
            }
        }
    }
}
