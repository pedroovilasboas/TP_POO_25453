using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class UpdateStockForm : Form
    {
        private Product _product;

        // Constructor that receives the product to update
        public UpdateStockForm(Product product)
        {
            InitializeComponent();
            _product = product;
        }

        // Load event to populate product details
        private void UpdateStockForm_Load(object sender, EventArgs e)
        {
            if (_product != null)
            {
                labelProductName.Text = $"Product Name: {_product.Name}";
                labelCurrentStock.Text = $"Current Stock: {_product.StockQuantity}";
            }
        }

        // Button click event to update stock
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse the entered stock value
                var addedStock = int.Parse(textBoxStock.Text);

                if (addedStock < 0)
                {
                    MessageBox.Show("Stock cannot be negative.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the product stock
                _product.UpdateStock(_product.StockQuantity + addedStock);

                MessageBox.Show("Stock updated successfully!", "Success", MessageBoxButtons.OK);
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid numeric value for stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
