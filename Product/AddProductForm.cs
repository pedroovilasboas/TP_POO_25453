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
            try
            {
                // Load brands and categories
                comboBoxBrand.Items.Clear();
                comboBoxCategory.Items.Clear();

                // Load and store full Category objects
                var categories = Category.LoadCategories();
                if (categories.Any())
                {
                    comboBoxCategory.DisplayMember = "Name";
                    comboBoxCategory.ValueMember = "CategoryId";
                    foreach (var category in categories)
                    {
                        comboBoxCategory.Items.Add(category);
                    }
                }
                else
                {
                    MessageBox.Show("No categories found. Please add categories first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Load and store full Brand objects
                var brands = Brand.LoadBrands();
                if (brands.Any())
                {
                    comboBoxBrand.DisplayMember = "Name";
                    comboBoxBrand.ValueMember = "BrandID";
                    foreach (var brand in brands)
                    {
                        comboBoxBrand.Items.Add(brand);
                    }
                }
                else
                {
                    MessageBox.Show("No brands found. Please add brands first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Handle empty product list gracefully
                var products = Product.LoadProducts();
                textBoxID.Text = (products.Any() ? products.Max(p => p.ProductID) + 1 : 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation 
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
                decimal price;
                int stock;

                if (!decimal.TryParse(textBoxPrice.Text, out price))
                {
                    MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxStock.Text, out stock) || stock < 0)
                {
                    MessageBox.Show("Please enter a valid stock quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the selected Category and Brand objects directly
                var category = (Category)comboBoxCategory.SelectedItem;
                var brand = (Brand)comboBoxBrand.SelectedItem;

                // Create and save new product
                var product = new Product(category, brand, name, description, type, price, stock);
                product.Save();

                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
