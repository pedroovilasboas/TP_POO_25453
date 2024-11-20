using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class EditProductForm : Form
    {
        private Product product;

        public EditProductForm(Product product)
        {
           product = product;
            InitializeComponent();
        }

        private void EditProductForm_Load(object sender, EventArgs e)
        {
            comboBoxBrand.Items.Clear();
            List<Brand> brands = Brand.LoadBrands();
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string brandName = comboBoxBrand.SelectedItem.ToString();
            string name = textBoxName.Text;
            string description = textBoxDescription.Text;
            string type = textBoxType.Text;
            decimal price = decimal.Parse(textBoxPrice.Text);
            int stock = int.Parse(textBoxStock.Text);

            Brand brand = Brand.LoadBrands().Find(b => b.Name == brandName);

            product.Brand = brand;
            product.Name = name;
            product.Description = description;
            product.Type = type;
            product.Price = price;
            product.StockQuantity = stock;

            Product.UpdateProduct(product);
            MessageBox.Show("Product updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
