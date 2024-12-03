using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class UpdateStockForm : Form
    {
        private Product _product;

        public UpdateStockForm(Product product)
        {
            InitializeComponent();
            _product = product;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var addedStock = int.Parse(textBoxStock.Text);
                _product.UpdateStock(_product.StockQuantity + addedStock);

                MessageBox.Show("Stock updated successfully!", "Success", MessageBoxButtons.OK);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
