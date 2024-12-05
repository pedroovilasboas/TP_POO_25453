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
    public partial class ManageAccountForm : Form
    {
        public ManageAccountForm()
        {
            InitializeComponent();
        }

        private void ManageAccountForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            // Get the search query from the input field
            string query = textBoxSearch.Text;

            // Search for accounts based on the query
            var results = Account.SearchAccounts(query);

            // Display the search results in the checked list box
            DisplayResults(results);
        }

        private void DisplayResults(List<Account> results)
        {
            // Clear the current items in the checked list box
            checkedListBoxResults.Items.Clear();

            // Add each account result to the checked list box
            foreach (var account in results)
            {
                checkedListBoxResults.Items.Add($"{account.Name} ({account.Username})");
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Ensure that exactly one account is selected for editing
            if (checkedListBoxResults.CheckedItems.Count != 1)
            {
                MessageBox.Show("Please select exactly one account to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Extract the selected account's username from the list box
            string selectedAccountInfo = checkedListBoxResults.CheckedItems[0].ToString();
            string selectedUsername = selectedAccountInfo.Substring(selectedAccountInfo.IndexOf('(') + 1).TrimEnd(')');

            // Find the account using the username
            var account = Account.LoadAccounts().Find(acc => acc.Username == selectedUsername);

            if (account != null)
            {
                // Open the EditAccountForm to allow editing of the selected account
                EditAccountForm editForm = new EditAccountForm(account);
                editForm.ShowDialog();

                // Refresh the list after editing
                string query = textBoxSearch.Text;
                var results = Account.SearchAccounts(query);
                DisplayResults(results);
            }
            else
            {
                MessageBox.Show("Account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkedListBoxResults_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Close_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Ensure that exactly one account is selected for deletion
            if (checkedListBoxResults.CheckedItems.Count != 1)
            {
                MessageBox.Show("Please select exactly one account to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Extract the selected account's username from the list box
            string selectedAccountInfo = checkedListBoxResults.CheckedItems[0].ToString();
            string selectedUsername = selectedAccountInfo.Substring(selectedAccountInfo.IndexOf('(') + 1).TrimEnd(')');

            // Confirm deletion from the user
            var confirmResult = MessageBox.Show("Are you sure you want to delete this account?",
                                                 "Confirm Delete",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Delete the selected account
                Account.DeleteAccount(selectedUsername);

                // Refresh the list after deletion
                string query = textBoxSearch.Text;
                var results = Account.SearchAccounts(query);
                DisplayResults(results);

                MessageBox.Show("Account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
