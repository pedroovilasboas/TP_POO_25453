using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for adding new administrator accounts to the system.
    /// Provides interface for entering account details such as username,
    /// password, and name.
    /// </summary>
    public partial class AddAccountForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the AddAccountForm.
        /// </summary>
        public AddAccountForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form load event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void AddAccountForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the add button click event.
        /// Creates and saves a new administrator account with the entered details.
        /// Shows appropriate success or error messages.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void Addbuton_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string name = textBoxName.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Username and Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Account newAccount = new Account(username, password, name);
            newAccount.Save();

            MessageBox.Show("Account added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

    }

}
