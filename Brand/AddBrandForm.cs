using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class AddBrandForm : Form
    {
        public AddBrandForm()
        {
            InitializeComponent();
        }

        private void AddBrandForm_Load(object sender, EventArgs e)
        {
            var brands = Brand.LoadBrands();
            var nextId = brands.Any() ? brands.Max(b => b.BrandID) + 1 : 1;

            textBoxBrandId.Text = nextId.ToString();
            textBoxBrandId.ReadOnly = true; 
        }


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
