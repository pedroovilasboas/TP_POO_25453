using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for updating product stock quantities.
    /// Provides interface for modifying the stock level of existing products,
    /// with validation to ensure stock quantities remain non-negative.
    /// </summary>
    public partial class UpdateStockForm : Form
    {
        private Product _product;

        /// <summary>
        /// Initializes a new instance of the UpdateStockForm.
        /// </summary>
        /// <param name="product">The product whose stock needs to be updated.</param>
        public UpdateStockForm(Product product)
        {
            InitializeComponent();
            _product = product;
        }

        /// <summary>
        /// Handles the form load event. Displays the current product name
        /// and stock quantity in the form labels.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void UpdateStockForm_Load(object sender, EventArgs e)
        {
            if (_product != null)
            {
                labelProductName.Text = $"Product Name: {_product.Name}";
                labelCurrentStock.Text = $"Current Stock: {_product.StockQuantity}";
            }
        }

        /// <summary>
        /// Handles the update button click event. Validates and updates the product's
        /// stock quantity with the entered value. Shows appropriate success or error messages.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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
