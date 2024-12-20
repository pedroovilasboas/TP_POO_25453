using System;
using System.Linq;
using System.Windows.Forms;
using POO_25453_TP.DAL;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for client login authentication.
    /// Provides interface for clients to enter their credentials
    /// and access their account dashboard. Also includes option to create new account.
    /// </summary>
    public partial class ClientLoginForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the ClientLoginForm.
        /// </summary>
        public ClientLoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the login button click event. Validates the entered credentials,
        /// loads the client information, and opens the client dashboard if authentication
        /// is successful. Shows appropriate error messages for invalid credentials or errors.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var username = textBoxUsername.Text;
                var password = textBoxPassword.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Login.ValidateClientLogin(username, password))
                {
                    var clients = Client.LoadClients();
                    var client = clients.FirstOrDefault(c => c.Username == username);
                    
                    if (client != null)
                    {
                        var clientPage = new ClientPage(client);
                        clientPage.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Client information not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Handles the create account button click event.
        /// Opens the AddClientForm for new client registration.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            // Create and display the AddClientForm
            var addClientForm = new AddClientForm();
            addClientForm.ShowDialog(); // Use ShowDialog to keep the login form on hold
        }

        /// <summary>
        /// Handles the form load event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ClientLoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
