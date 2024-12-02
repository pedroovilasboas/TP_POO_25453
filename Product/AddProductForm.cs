using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void EditProductForm_Load(object sender, EventArgs e)
        {
            // Carregar as marcas no ComboBox
            comboBoxBrand.Items.Clear();
            List<Brand> brands = Brand.LoadBrands();

            if (brands.Count == 0)
            {
                MessageBox.Show("No brands available. Please add a brand first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var brand in brands)
            {
                comboBoxBrand.Items.Add(brand.Name);
            }

            comboBoxBrand.SelectedItem = product.Brand.Name;
            textBoxName.Text = product.Name;
            textBoxDescription.Text = product.Description;
            textBoxType.Text = product.Type;
            textBoxPrice.Text = product.Price.ToString();
            textBoxStock.Text = product.StockQuantity.ToString();
            }

            try
            {
                string brandName = comboBoxBrand.SelectedItem.ToString();
                string name = textBoxName.Text;
                string description = textBoxDescription.Text;
                string type = textBoxType.Text;
                decimal price = decimal.Parse(textBoxPrice.Text);
                int stock = int.Parse(textBoxStock.Text);

                // Obter a marca selecionada
                Brand brand = Brand.LoadBrands().Find(b => b.Name == brandName);

                if (brand == null)
                {
                    MessageBox.Show("Selected brand is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Criar novo produto
                Product newProduct = new Product(brandName, name, description, type, price, stock);
                newProduct.Save();

                MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Price and Stock must be numeric values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
