using System;
using System.Windows.Forms;
using POO_25453_TP.BLL;

namespace POO_25453_TP
{
    public partial class LoginForm : Form
    {
        private LoginBLL loginBLL;

        public LoginForm()
        {
            InitializeComponent();
            loginBLL = new LoginBLL(); // Initialize the business logic layer
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string userType = radioButtonClient.Checked ? "client" : "account";

            try
            {
                if (loginBLL.Authenticate(username, password, userType))
                {
                    MessageBox.Show($"{userType} login successful!");
                    Form nextForm = userType == "client" ? new () : new AccountPage();
                    nextForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show($"Invalid {userType} credentials.");
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the login form
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
