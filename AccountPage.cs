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
    /// <summary>
    /// Main administrator dashboard form that provides access to all
    /// management functionalities through a menu-driven interface.
    /// Includes options for managing accounts, clients, brands,
    /// products, categories, orders, and campaigns.
    /// </summary>
    public partial class AccountPage : Form
    {
        /// <summary>
        /// Initializes a new instance of the AccountPage.
        /// </summary>
        public AccountPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads a form into the main panel, adjusting its size and display properties
        /// to fit within the panel boundaries.
        /// </summary>
        /// <param name="form">The form to be loaded into the panel.</param>
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

        /// <summary>
        /// Handles the add account menu item click.
        /// Opens the AddAccountForm in the main panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Reuse the existing AddAccountForm
            AddAccountForm addAccountForm = new AddAccountForm();

            // Load it into the panel
            LoadFormIntoPanel(addAccountForm);
        }

        /// <summary>
        /// Handles the manage account menu item click.
        /// Opens the ManageAccountForm in the main panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void manageAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageAccountForm manageAccountForm = new ManageAccountForm();
            LoadFormIntoPanel(manageAccountForm);
        }

        /// <summary>
        /// Handles the add client menu item click.
        /// Opens the AddClientForm in the main panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void addClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClientForm addClientForm = new AddClientForm();
            LoadFormIntoPanel(addClientForm);
        }

        /// <summary>
        /// Handles the manage client menu item click.
        /// Opens the ManageClientForm in the main panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void manageClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageClientForm manageClientForm = new ManageClientForm();
            LoadFormIntoPanel(manageClientForm);
        }

        /// <summary>
        /// Handles the add brand menu item click.
        /// Opens the AddBrandForm in the main panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void addBrandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBrandForm addBrandForm = new AddBrandForm();
            LoadFormIntoPanel(addBrandForm);
        }

        /// <summary>
        /// Handles the manage brand menu item click.
        /// Opens the ManageBrandForm in the main panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void manageBandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageBrandForm manageBrandForm = new ManageBrandForm();
            LoadFormIntoPanel(manageBrandForm);
        }

        /// <summary>
        /// Handles the add product menu item click.
        /// Opens the AddProductForm in the main panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            LoadFormIntoPanel(addProductForm);
        }

        /// <summary>
        /// Handles the manage product menu item click.
        /// Opens the ManageProductForm in the main panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void manageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageProductForm manageProductForm = new ManageProductForm();
            LoadFormIntoPanel(manageProductForm);
        }

        /// <summary>
        /// Handles the add category menu item click.
        /// Opens the AddCategoryForm in the main panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCategoryForm addCategoryForm = new AddCategoryForm();
            LoadFormIntoPanel(addCategoryForm);
        }

        /// <summary>
        /// Handles the manage category menu item click.
        /// Opens the ManageCategoryForm in the main panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void manageCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCategoryForm manageCategoryForm = new ManageCategoryForm();
            LoadFormIntoPanel(manageCategoryForm);
        }

        /// <summary>
        /// Handles the category menu item click.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the orders menu item click.
        /// Opens the OrdersForm in the main panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm();
            LoadFormIntoPanel(ordersForm);
        }

        /// <summary>
        /// Handles the manage campaigns menu item click.
        /// Opens the CampaignManagementForm in the main panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void manageCampaignsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CampaignManagementForm campaignForm = new CampaignManagementForm();
            LoadFormIntoPanel(campaignForm);
        }

        /// <summary>
        /// Handles the panel paint event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Paint event arguments.</param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Handles the menu strip item clicked event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Tool strip item clicked event arguments.</param>
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void warrantyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
