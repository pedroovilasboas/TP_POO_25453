using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Initial login selection form that allows users to choose between
    /// administrator or client login options.
    /// </summary>
    public partial class LoginSelectionForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the LoginSelectionForm.
        /// </summary>
        public LoginSelectionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the administrator login button click event.
        /// Opens the AdminLoginForm and hides the current form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            // Open Admin Login Form
            var adminLoginForm = new AdminLoginForm();
            adminLoginForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Handles the client login button click event.
        /// Opens the ClientLoginForm and hides the current form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void buttonClient_Click(object sender, EventArgs e)
        {
            // Open Client Options Form (Login/Create Account)
            var clientloginform = new ClientLoginForm();
            clientloginform.Show();
            this.Hide();
        }

        /// <summary>
        /// Handles the form load event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void LoginSelectionForm_Load(object sender, EventArgs e)
        {

        }
    }
}