using System;
using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class LoginSelectionForm : Form
    {
        public LoginSelectionForm()
        {
            InitializeComponent();
        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            // Open Admin Login Form
            var adminLoginForm = new AdminLoginForm();
            adminLoginForm.Show();
            this.Hide();
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            // Open Client Options Form (Login/Create Account)
            var clientloginform = new ClientLoginForm();
            clientloginform.Show();
            this.Hide();
        }

        private void LoginSelectionForm_Load(object sender, EventArgs e)
        {

        }
    }
}