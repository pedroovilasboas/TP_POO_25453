using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for adding new product brands to the system.
    /// Provides interface for entering brand details such as name
    /// and description. Automatically generates brand ID.
    /// </summary>
    public partial class AddBrandForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the AddBrandForm.
        /// </summary>
        public AddBrandForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form load event.
        /// Generates and displays the next available brand ID.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void AddBrandForm_Load(object sender, EventArgs e)
        {
            var brands = Brand.LoadBrands();
            var nextId = brands.Any() ? brands.Max(b => b.BrandID) + 1 : 1;

            textBoxBrandId.Text = nextId.ToString();
            textBoxBrandId.ReadOnly = true; 
        }


        /// <summary>
        /// Handles the add button click event.
        /// Creates and saves a new brand with the entered details.
        /// Shows appropriate success or error messages.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            string brandName = textBoxBrandName.Text;
            string description = textBoxDescription.Text;

            if (string.IsNullOrEmpty(brandName) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("All fields must be filled out.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Brand newBrand = new Brand(brandName, description);
            newBrand.Save();

            MessageBox.Show("Brand added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
