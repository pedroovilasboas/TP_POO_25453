using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _25453_TP_POO
{
    public partial class LandPage : Form
    {
        public LandPage()
        {
            InitializeComponent();
        }

        private void LanPage_Load(object sender, EventArgs e)
        {

        }

        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAccountForm addAccountForm = new AddAccountForm();
            addAccountForm.ShowDialog();
        }

        private void manageAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageAccountForm manageAccountForm = new ManageAccountForm();
            manageAccountForm.ShowDialog();
        }

        private void addClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClientForm addClientForm = new AddClientForm();
            addClientForm.ShowDialog();
        }

        private void manageClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageClientForm manageClientForm = new ManageClientForm();
            manageClientForm.ShowDialog();
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCategoryForm addCategoryForm = new AddCategoryForm();
            addCategoryForm.ShowDialog();
        }

        private void manageCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addBrandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBrandForm addBrandForm = new AddBrandForm();
            addBrandForm.ShowDialog();
        }

        private void manageBrandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageBrandForm manageBrandForm = new ManageBrandForm();
            manageBrandForm.ShowDialog();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
        }

        private void manageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageProductForm manageProductForm = new ManageProductForm();
            manageProductForm.ShowDialog();
        }
    }
}
