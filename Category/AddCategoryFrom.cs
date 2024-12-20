using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for adding new product categories to the system.
    /// Provides interface for entering category details such as name
    /// and description. Automatically generates category ID.
    /// </summary>
    public partial class AddCategoryForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the AddCategoryForm.
        /// </summary>
        public AddCategoryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form load event.
        /// Generates and displays the next available category ID.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void AddCategoryForm_Load(object sender, EventArgs e)
        {
            
            var categories = Category.LoadCategories();
            var nextId = categories.Any() ? categories.Max(c => c.CategoryId) + 1 : 1;
            textBoxCategoryId.Text = nextId.ToString();
            textBoxCategoryId.ReadOnly = true;
        }


        /// <summary>
        /// Handles the add button click event.
        /// Creates and saves a new category with the entered details.
        /// Shows appropriate success or error messages.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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
