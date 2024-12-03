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
            // Check credentials (hardcoded for now)
            if (textBoxUsername.Text == "admin" && textBoxPassword.Text == "password")
            {
                var accountPage = new AccountPage();
                accountPage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
