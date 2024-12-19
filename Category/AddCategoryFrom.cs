using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class AddCategoryForm : Form
    {
        public AddCategoryForm()
        {
            InitializeComponent();
        }

        private void AddCategoryForm_Load(object sender, EventArgs e)
        {
            
            var categories = Category.LoadCategories();
            var nextId = categories.Any() ? categories.Max(c => c.CategoryId) + 1 : 1;
            textBoxCategoryId.Text = nextId.ToString();
            textBoxCategoryId.ReadOnly = true;
        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            // Retrieve input values
            string categoryName = textBoxCategoryName.Text;
            string description = textBoxDescription.Text;

            // Validate that required fields are filled
            if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("All fields must be filled out.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new category (ID is auto-generated)
            var newCategory = new Category(categoryName, description);
            newCategory.Save();

            // Notify the user and close the form
            MessageBox.Show("Category added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
