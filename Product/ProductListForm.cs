using System;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class ProductListForm : Form
    {
        private Cart cart;

        public ProductListForm(int clientID)
        {
            InitializeComponent();
            this.cart = Cart.LoadCart(clientID); // Load the cart for the logged-in client
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


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
