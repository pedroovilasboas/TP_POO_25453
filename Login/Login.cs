using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace POO_25453_TP
{
    public class Login
    {
        // Authentication method for Client
        public static bool ClientLogin(string username, string password)
        {
            // Load list of clients
            List<Client> clients = Client.LoadClients();

            // Check if client with matching username and password exists
            var client = clients.Find(c => c.Username == username && c.Password == password);
            if (client != null)
            {
                // Redirect to client homepage
                MessageBox.Show("Client login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Example: Redirect to client home page
                // ClientHomePage(client);
                return true;
            }
            else
            {
                MessageBox.Show("Client login failed. Please check your credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Authentication method for Account
        public static bool AccountLogin(string username, string password)
        {
            // Load list of accounts
            List<Account> accounts = Account.LoadAccounts();

            // Check if account with matching username and password exists
            var account = accounts.Find(a => a.Username == username && a.Password == password);
            if (account != null)
            {
                // Redirect to account management homepage
                MessageBox.Show("Account login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Example: Redirect to account management home page
                // AccountHomePage(account);
                return true;
            }
            else
            {
                MessageBox.Show("Account login failed. Please check your credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
