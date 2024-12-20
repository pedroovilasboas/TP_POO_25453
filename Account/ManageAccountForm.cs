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
    /// Form for managing administrator accounts in the system.
    /// Provides functionality for viewing, searching, editing, and deleting administrator accounts.
    /// Also includes a data grid view to display all accounts and their details.
    /// </summary>
    public partial class ManageAccountForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the ManageAccountForm.
        /// </summary>
        public ManageAccountForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form load event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ManageAccountForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the search button click event.
        /// Searches for accounts based on the entered query and displays results.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void buttonGo_Click(object sender, EventArgs e)
        {
            // Get the search query from the input field
            string query = textBoxSearch.Text;

            // Search for accounts based on the query
            var results = Account.SearchAccounts(query);

            // Display the search results in the checked list box
            DisplayResults(results);
        }

        /// <summary>
        /// Displays the list of accounts in the checked list box.
        /// Shows account names and usernames for each account.
        /// </summary>
        /// <param name="results">List of accounts to display.</param>
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

        /// <summary>
        /// Handles the edit button click event.
        /// Opens the EditAccountForm for the selected account.
        /// Shows error messages if no account or multiple accounts are selected.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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

        /// <summary>
        /// Handles the selection change event in the results list box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void checkedListBoxResults_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Handles the close button click event. Closes the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void Close_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }

        /// <summary>
        /// Handles the delete button click event.
        /// Deletes the selected account after confirmation.
        /// Shows error messages if no account or multiple accounts are selected.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
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

        /// <summary>
        /// Handles the search text box change event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
