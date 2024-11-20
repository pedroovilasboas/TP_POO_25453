using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class EditBrandForm : Form
    {
        private Brand brand;

        public EditBrandForm(Brand brand)
        {
            InitializeComponent();
            this.brand = brand;
        }

        private void EditBrandForm_Load(object sender, EventArgs e)
        {
            textBoxName.Text = brand.Name;
            textBoxDescription.Text = brand.Description;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            brand.Name = textBoxName.Text;
            brand.Description = textBoxDescription.Text;

            Brand.UpdateBrand(brand);
            MessageBox.Show("Brand updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
