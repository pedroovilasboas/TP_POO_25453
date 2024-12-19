using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class ClientPage : Form
    {
        private Client currentClient;

        // Constructor that accepts a Client object
        public ClientPage(Client client)
        {
            currentClient = client ?? throw new ArgumentNullException(nameof(client));
            InitializeComponent();

            // Update the form's title to greet the client
            this.Text = $"Welcome, {currentClient.Name}!";
        }

        // Method to load a form into the panel
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

        // Event for Logout
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }

        // Event for editing account information
        private void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentClient == null)
            {
                MessageBox.Show("No client information available. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Open the EditClientForm in the panel
            EditClientForm editClientForm = new EditClientForm(currentClient);
            LoadFormIntoPanel(editClientForm);
        }

        // Event for viewing products
        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the ProductListForm in the panel
            ProductListForm productListForm = new ProductListForm(currentClient.ClientID);
            LoadFormIntoPanel(productListForm);
        }

        // Event for viewing the cart
        private void myCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the CartViewForm in the panel
            CartViewForm cartViewForm = new CartViewForm(currentClient.ClientID);
            LoadFormIntoPanel(cartViewForm);
        }

        private void ClientPage_Load(object sender, EventArgs e)
        {
            // Optionally, load a default form into the panel
            ProductListForm productListForm = new ProductListForm(currentClient.ClientID);
            LoadFormIntoPanel(productListForm);
        }

        private void myOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentClient == null)
            {
                MessageBox.Show("No client information available. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Open the MyOrdersForm in the panel
            MyOrdersForm myOrdersForm = new MyOrdersForm(currentClient.ClientID);
            LoadFormIntoPanel(myOrdersForm);
        }

    }
}
