using System;
using System.Linq;
using System.Windows.Forms;

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
            var username = textBoxUsername.Text;
            var password = textBoxPassword.Text;

            var clients = Client.LoadClients();
            var client = clients.FirstOrDefault(c => c.Username == username && c.Password == password);

            if (client != null)
            {
                var clientPage = new ClientPage(client);
                clientPage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
