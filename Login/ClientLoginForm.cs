using System;
using System.Linq;
using System.Windows.Forms;
using POO_25453_TP.DAL;

namespace POO_25453_TP
{
    public partial class ClientLoginForm : Form
    {
        public ClientLoginForm()
        {
            InitializeComponent();
        }

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


        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            // Create and display the AddClientForm
            var addClientForm = new AddClientForm();
            addClientForm.ShowDialog(); // Use ShowDialog to keep the login form on hold
        }

        private void ClientLoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
