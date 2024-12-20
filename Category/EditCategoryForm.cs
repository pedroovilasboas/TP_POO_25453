using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for editing existing product category details.
    /// Provides interface for modifying category name and description.
    /// </summary>
    public partial class EditCategoryForm : Form
    {
        private Category _category;

        /// <summary>
        /// Initializes a new instance of the EditCategoryForm.
        /// </summary>
        /// <param name="category">The category to be edited.</param>
        public EditCategoryForm(Category category)
        {
            InitializeComponent();
            _category = category;
        }

        /// <summary>
        /// Handles the form load event.
        /// Populates the form fields with the current category information.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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

        /// <summary>
        /// Handles the save button click event.
        /// Updates the category with the modified information and saves changes.
        /// Shows a success message upon completion.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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

        /// <summary>
        /// Handles the close button click event. Closes the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            // Close the form without saving
            this.Close();
        }
    }
}
