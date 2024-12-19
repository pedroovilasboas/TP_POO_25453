using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class EditProductForm : Form
    {
        private Product _product;

        public EditProductForm(Product product)
        {
            InitializeComponent();
           _product = product;
        }

        private void EditProductForm_Load(object sender, EventArgs e)
        {
            if (_product != null)
            {
                textBoxName.Text = _product.Name;
                textBoxDescription.Text = _product.Description;
                textBoxType.Text = _product.Type;
                textBoxPrice.Text = _product.Price.ToString();
                textBoxStock.Text = _product.StockQuantity.ToString();

                // Populate the brand dropdown
                comboBoxBrand.Items.Clear();
                var brands = Brand.LoadBrands();
                foreach (var brand in brands)
                {
                    comboBoxBrand.Items.Add(brand.Name);
                }
                comboBoxBrand.SelectedItem = _product.Brand?.Name;
            }
            else
            {
                MessageBox.Show("Error loading product data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
             
        }
        

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // update product data
                _product.Name = textBoxName.Text;
                _product.Description = textBoxDescription.Text;
                _product.Type = textBoxType.Text;
                _product.Price = decimal.Parse(textBoxPrice.Text);
                _product.StockQuantity = int.Parse(textBoxStock.Text);

                var brandName = comboBoxBrand.SelectedItem?.ToString();
                _product.Brand = Brand.LoadBrands().FirstOrDefault(b => b.Name == brandName);

                // Save the updated product
                Product.UpdateProduct(_product);

                MessageBox.Show("Product updated successfully.", "Success", MessageBoxButtons.OK);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving product: {ex.Message}", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
