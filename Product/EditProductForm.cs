using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for editing existing product information.
    /// Allows modification of product details including name, description,
    /// price, stock quantity, brand, and category information.
    /// </summary>
    public partial class EditProductForm : Form
    {
        private Product _product;

        /// <summary>
        /// Initializes a new instance of the EditProductForm.
        /// </summary>
        /// <param name="product">The product to be edited.</param>
        public EditProductForm(Product product)
        {
            InitializeComponent();
           _product = product;
        }

        /// <summary>
        /// Handles the form load event. Populates the form fields with the existing
        /// product information and loads available brands into the combo box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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
        

        /// <summary>
        /// Handles the save button click event. Updates the product with the modified
        /// information and saves changes to storage. Shows appropriate success or error messages.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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
