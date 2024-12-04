using System;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class CartViewForm : Form
    {
        private Cart cart;

        public CartViewForm(int clientID)
        {
            InitializeComponent();
            // Load the cart for the specific client using their ClientID
            this.cart = Cart.LoadCart(clientID);
        }

        private void CartViewForm_Load(object sender, EventArgs e)
        {
            // Load and display the items in the cart when the form loads
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            // Clear rows before adding new data
            dgvCartItems.Rows.Clear();

            // Populate the DataGridView with cart items
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
        }



        private void btnIncreaseQuantity_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count > 0)
            {
                int productId = int.Parse(dgvCartItems.SelectedRows[0].Cells[0].Value.ToString());
                var cartItem = cart.Items.FirstOrDefault(item => item.ProductID == productId);

                if (cartItem != null)
                {
                    cartItem.Quantity++;
                    cart.SaveCart();
                    LoadCartItems();
                }
            }
        }

        private void btnDecreaseQuantity_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count > 0)
            {
                int productId = int.Parse(dgvCartItems.SelectedRows[0].Cells[0].Value.ToString());
                var cartItem = cart.Items.FirstOrDefault(item => item.ProductID == productId);

                if (cartItem != null)
                {
                    if (cartItem.Quantity > 1)
                    {
                        cartItem.Quantity--;
                        cart.SaveCart();
                        LoadCartItems();
                    }
                    else
                    {
                        MessageBox.Show("Cannot decrease quantity below 1. Use the Remove button to remove the item.");
                    }
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
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cart.Items.Any())
            {
                MessageBox.Show("Checkout complete!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cart.Items.Clear();
                cart.SaveCart();
                LoadCartItems();
            }
            else
            {
                MessageBox.Show("Your cart is empty. Add items to proceed.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
