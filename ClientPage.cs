using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Main client dashboard form that provides access to all client-specific
    /// functionalities through a menu-driven interface. Includes options for
    /// managing account information, viewing products, accessing cart,
    /// and viewing order history.
    /// </summary>
    public partial class ClientPage : Form
    {
        private Client currentClient;

        /// <summary>
        /// Initializes a new instance of the ClientPage.
        /// </summary>
        /// <param name="client">The client whose information will be displayed.
        /// Cannot be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when client is null.</exception>
        public ClientPage(Client client)
        {
            currentClient = client ?? throw new ArgumentNullException(nameof(client));
            InitializeComponent();

            // Update the form's title to greet the client
            this.Text = $"Welcome, {currentClient.Name}!";
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
        /// Handles the logout menu item click.
        /// Closes the client dashboard and returns to the login screen.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }

        /// <summary>
        /// Handles the edit account menu item click.
        /// Opens the EditClientForm for the current client in the main panel.
        /// Shows an error if client information is not available.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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

        /// <summary>
        /// Handles the products menu item click.
        /// Opens the ProductListForm in the main panel, displaying available products
        /// for the current client.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the ProductListForm in the panel
            ProductListForm productListForm = new ProductListForm(currentClient.ClientID);
            LoadFormIntoPanel(productListForm);
        }

        /// <summary>
        /// Handles the my cart menu item click.
        /// Opens the CartViewForm in the main panel, displaying the current
        /// client's shopping cart.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void myCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the CartViewForm in the panel
            CartViewForm cartViewForm = new CartViewForm(currentClient.ClientID);
            LoadFormIntoPanel(cartViewForm);
        }

        /// <summary>
        /// Handles the form load event.
        /// Loads the ProductListForm by default in the main panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ClientPage_Load(object sender, EventArgs e)
        {
            // Optionally, load a default form into the panel
            ProductListForm productListForm = new ProductListForm(currentClient.ClientID);
            LoadFormIntoPanel(productListForm);
        }

        /// <summary>
        /// Handles the my orders menu item click.
        /// Opens the MyOrdersForm in the main panel, displaying the current
        /// client's order history. Shows an error if client information
        /// is not available.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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
