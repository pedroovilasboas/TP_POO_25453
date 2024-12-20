using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for editing existing product brand details.
    /// Provides interface for modifying brand name and description.
    /// </summary>
    public partial class EditBrandForm : Form
    {
        private Brand brand;

        /// <summary>
        /// Initializes a new instance of the EditBrandForm.
        /// </summary>
        /// <param name="brand">The brand to be edited.</param>
        public EditBrandForm(Brand brand)
        {
            InitializeComponent();
            this.brand = brand;
        }

        /// <summary>
        /// Handles the form load event.
        /// Populates the form fields with the current brand information.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void EditBrandForm_Load(object sender, EventArgs e)
        {
            textBoxName.Text = brand.Name;
            textBoxDescription.Text = brand.Description;
        }

        /// <summary>
        /// Handles the save button click event.
        /// Updates the brand with the modified information and saves changes.
        /// Shows a success message upon completion.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            brand.Name = textBoxName.Text;
            brand.Description = textBoxDescription.Text;

            Brand.UpdateBrand(brand);
            MessageBox.Show("Brand updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        /// <summary>
        /// Handles the close button click event. Closes the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
