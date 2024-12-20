using POO_25453_TP.DAL;
using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for administrator login authentication.
    /// Provides interface for administrators to enter their credentials
    /// and access the administrator dashboard.
    /// </summary>
    public partial class AdminLoginForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the AdminLoginForm.
        /// </summary>
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the login button click event. Validates the entered credentials
        /// and opens the administrator dashboard if authentication is successful.
        /// Shows an error message if credentials are invalid.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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

        /// <summary>
        /// Handles the form load event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void AdminLoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
