using System;
using System.Linq;
using System.Windows.Forms;
using static POO_25453_TP.Cart;

namespace POO_25453_TP
{
    public partial class CartViewForm : Form
    {
        private Cart cart;

        public CartViewForm(int clientID)
        {
            InitializeComponent();
            this.cart = Cart.LoadCart(clientID); // Load the cart for the specific client
        }

        private void CartViewForm_Load(object sender, EventArgs e)
        {
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            dgvCartItems.Rows.Clear();

            foreach (var item in cart.Items)
            {
                dgvCartItems.Rows.Add(
                    item.ProductID,
                    item.ProductName,
                    item.Quantity,
                    item.Price.ToString("C"),
                    (item.Quantity * item.Price).ToString("C")
                );
            }

            // Reset txtQuantity when the cart is loaded
            txtQuantity.Text = string.Empty;
        }

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
                    selectedRow.Cells["TotalPrice"].Value = (cartItem.Quantity * cartItem.Price).ToString("C");
                    txtQuantity.Text = cartItem.Quantity.ToString();
                }
            }
        }

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
                    selectedRow.Cells["TotalPrice"].Value = (cartItem.Quantity * cartItem.Price).ToString("C");
                    txtQuantity.Text = cartItem.Quantity.ToString();
                }
                else
                {
                    MessageBox.Show("Cannot decrease quantity below 1. Use the Remove button to remove the item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

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


    }
}

