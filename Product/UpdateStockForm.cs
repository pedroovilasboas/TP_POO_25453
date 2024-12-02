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
            if (int.TryParse(textBoxStock.Text, out int newStock))
            {
                _product.UpdateStock(newStock);
                MessageBox.Show("Stock updated successfully!", "Success", MessageBoxButtons.OK);
                Close();
            }
            else
            {
                MessageBox.Show("Invalid stock quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateStockForm_Load(object sender, EventArgs e)
        {

        }
    }
}
