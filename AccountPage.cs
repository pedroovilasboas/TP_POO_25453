using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO
    
    ;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class AccountPage : Form
    {
        public AccountPage()
        {
            InitializeComponent();
        }

        // Method to load a form into the panel1
        private void LoadFormIntoPanel(Form form)
        {
            // Set the panel size to match the form's size
            form.Width = panel1.Width;
            form.Height = panel1.Height;

            // Load the form into the panel
            panel1.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel1.Controls.Add(form);
            form.Show();
        }

        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Reuse the existing AddAccountForm
            AddAccountForm addAccountForm = new AddAccountForm();

            // Load it into the panel
            LoadFormIntoPanel(addAccountForm);
        }

        private void manageAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageAccountForm manageAccountForm = new ManageAccountForm();
            LoadFormIntoPanel(manageAccountForm);
        }

        private void addClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClientForm addClientForm = new AddClientForm();
            LoadFormIntoPanel(addClientForm);
        }

        private void manageClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageClientForm manageClientForm = new ManageClientForm();
            LoadFormIntoPanel(manageClientForm);
        }

        private void addBrandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBrandForm addBrandForm = new AddBrandForm();
            LoadFormIntoPanel(addBrandForm);
        }

        private void manageBandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageBrandForm manageBrandForm = new ManageBrandForm();
            LoadFormIntoPanel(manageBrandForm);
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            LoadFormIntoPanel(addProductForm);
        }

        private void manageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageProductForm manageProductForm = new ManageProductForm();
            LoadFormIntoPanel(manageProductForm);
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCategoryForm addCategoryForm = new AddCategoryForm();
            LoadFormIntoPanel(addCategoryForm);
        }

        private void manageCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCategoryForm manageCategoryForm = new ManageCategoryForm();
            LoadFormIntoPanel(manageCategoryForm);
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdersManagementForm ordersManagementForm = new OrdersManagementForm();
            LoadFormIntoPanel(ordersManagementForm);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
