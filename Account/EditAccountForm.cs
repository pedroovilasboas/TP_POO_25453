using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for editing existing administrator account details.
    /// Allows modification of account information such as username, password, and name.
    /// </summary>
    public partial class EditAccountForm : Form
    {
        private Account account;

        /// <summary>
        /// Initializes a new instance of the EditAccountForm.
        /// </summary>
        /// <param name="account">The account to be edited.</param>
        public EditAccountForm(Account account)
        {
            InitializeComponent();
            this.account = account; // Store the passed account
        }

        /// <summary>
        /// Handles the form load event.
        /// Populates the form fields with the current account information.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void EditAccountForm_Load(object sender, EventArgs e)
        {
            if (account != null) // Check if account is not null
            {
                textBoxName.Text = account.Name;        // Fill in the Name field
                textBoxUsername.Text = account.Username; // Fill in the Username field
            }
        }

        /// <summary>
        /// Handles the save button click event.
        /// Updates the account with the modified information and saves changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void Savebuton_Click(object sender, EventArgs e)
        {
            // Update the account data with new values
            account.Name = textBoxName.Text;
            account.Username = textBoxUsername.Text;
            account.Password = textBoxPassword.Text;

            // Call the method to update the account
            Account.UpdateAccount(account); // Update the account in the file

            // Close the form
            this.Close();
        }

        /// <summary>
        /// Handles the close button click event. Closes the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
