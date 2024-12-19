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
    public partial class EditAccountForm : Form
    {
        private Account account;

        public EditAccountForm(Account account)
        {
            InitializeComponent();
            this.account = account; // Store the passed account
        }

        private void EditAccountForm_Load(object sender, EventArgs e)
        {
            if (account != null) // Check if account is not null
            {
                textBoxName.Text = account.Name;        // Fill in the Name field
                textBoxUsername.Text = account.Username; // Fill in the Username field
            }
        }

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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
