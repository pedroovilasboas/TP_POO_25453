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
            // Code to load the form, if necessary
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Capture the values for ID, Name, and Description
            if (!int.TryParse(textBoxCategoryId.Text, out int categoryId))
            {
                MessageBox.Show("Please enter a valid numeric ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string categoryName = textBoxCategoryName.Text;
            string description = textBoxDescription.Text;

            // Check if any field is empty
            if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("All fields must be filled out.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new instance of Category and save it
            Category newCategory = new Category(categoryId, categoryName, description);
            newCategory.Save();

            MessageBox.Show("Category added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
