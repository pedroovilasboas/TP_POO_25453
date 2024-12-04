using System;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class CartViewForm : Form
    {
        private Cart cart;

        public CartViewForm(Cart cart)
        {
            InitializeComponent();
            this.cart = cart;
        }

        private void CartViewForm_Load(object sender, EventArgs e)
        {
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            // Clear existing rows
            dgvCartItems.Rows.Clear();

            // Configure columns if they are not already set
            if (dgvCartItems.Columns.Count == 0)
            {
                dgvCartItems.Columns.Add("ProductID", "Product ID");
                dgvCartItems.Columns.Add("Name", "Product Name");
                dgvCartItems.Columns.Add("Quantity", "Quantity");
                dgvCartItems.Columns.Add("Price", "Price");
                dgvCartItems.Columns.Add("Total", "Total");
            }

            // Populate rows with cart items
            foreach (var item in cart.GetCartItems())
            {
                dgvCartItems.Rows.Add(
                    item.Product.ProductID,
                    item.Product.Name,
                    item.Quantity,
                    item.Product.Price.ToString("0.00"),
                    (item.Quantity * item.Product.Price).ToString("0.00")
                );
            }

            // Update quantity label
            UpdateQuantityLabel();
        }



        private void UpdateQuantityLabel()
        {
            if (dgvCartItems.SelectedRows.Count == 1)
            {
                var selectedRow = dgvCartItems.SelectedRows[0];
                lblQuantity.Text = selectedRow.Cells["Quantity"].Value.ToString();
            }
            else
            {
                lblQuantity.Text = "0";
            }
        }

        private void btnIncreaseQuantity_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count == 1)
            {
                var selectedRow = dgvCartItems.SelectedRows[0];
                int productId = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);
                var item = cart.GetCartItems().FirstOrDefault(i => i.Product.ProductID == productId);

                if (item != null)
                {
                    item.Quantity++;
                    LoadCartItems();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to increase quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnDecreaseQuantity_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count == 1)
            {
                var selectedRow = dgvCartItems.SelectedRows[0];
                int productId = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);
                var item = cart.GetCartItems().FirstOrDefault(i => i.Product.ProductID == productId);

                if (item != null && item.Quantity > 1)
                {
                    item.Quantity--;
                    LoadCartItems();
                }
                else
                {
                    MessageBox.Show("Cannot reduce quantity below 1.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to decrease quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count == 1)
            {
                var selectedRow = dgvCartItems.SelectedRows[0];
                int productId = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);

                // Remove the item from the cart
                cart.RemoveFromCart(productId);
                LoadCartItems();

                MessageBox.Show("Product removed from the cart.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnCheckout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Checkout functionality to be implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

