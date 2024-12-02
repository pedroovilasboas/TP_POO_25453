using System;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            comboBoxBrand.Items.Clear();
            comboBoxCategory.Items.Clear();

            foreach (var brand in Brand.LoadBrands())
                comboBoxBrand.Items.Add(brand.Name);

            foreach (var category in Category.LoadCategories())
                comboBoxCategory.Items.Add(category.Name);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                    string.IsNullOrWhiteSpace(textBoxDescription.Text) ||
                    string.IsNullOrWhiteSpace(textBoxType.Text) ||
                    comboBoxBrand.SelectedItem == null ||
                    comboBoxCategory.SelectedItem == null)
                {
                    MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var name = textBoxName.Text;
                var description = textBoxDescription.Text;
                var type = textBoxType.Text;
                var price = decimal.Parse(textBoxPrice.Text);
                var stock = int.Parse(textBoxStock.Text);

                var brandName = comboBoxBrand.SelectedItem.ToString();
                var categoryName = comboBoxCategory.SelectedItem.ToString();

                var brand = Brand.LoadBrands().FirstOrDefault(b => b.Name == brandName);
                var category = Category.LoadCategories().FirstOrDefault(c => c.Name == categoryName);

                if (brand == null || category == null)
                {
                    MessageBox.Show("Invalid brand or category selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var product = new Product(category, brand, name, description, type, price, stock);
                product.Save();

                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
