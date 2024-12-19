using POO_25453_TP.DAL;
using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Get username and password from the text boxes
            var username = textBoxUsername.Text;
            var password = textBoxPassword.Text;

            // Validate credentials using the ValidateAccountLogin method
            if (Login.ValidateAccountLogin(username, password))
            {
                // If credentials are valid, open the AccountPage
                var accountPage = new AccountPage();
                accountPage.Show();
                this.Close();
            }
            else
            {
                // Show an error message if credentials are invalid
                MessageBox.Show("Invalid credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminLoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
