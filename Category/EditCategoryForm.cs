using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class EditCategoryForm : Form
    {
        private Category _category;

        // Constructor to initialize the form with a category
        public EditCategoryForm(Category category)
        {
            InitializeComponent();
            _category = category;
        }

        private void EditCategoryForm_Load(object sender, EventArgs e)
        {
            // Populate fields with category data
            if (_category != null)
            {
                textBoxCategoryId.Text = _category.CategoryId.ToString();
                textBoxName.Text = _category.Name;
                textBoxDescription.Text = _category.Description;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Update category with new values
            _category.Name = textBoxName.Text;
            _category.Description = textBoxDescription.Text;

            // Update the category in storage
            Category.UpdateCategory(_category);

            // Inform the user and close the form
            MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            // Close the form without saving
            this.Close();
        }
    }
}
