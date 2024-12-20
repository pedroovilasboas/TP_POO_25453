using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Represents an administrator account in the system.
    /// Manages account creation, authentication, and maintenance.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Username for account login
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password for account authentication
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Display name of the account holder
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// File path for storing account data
        /// </summary>
        private static string accountsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Account\accounts.txt");

        /// <summary>
        /// Constructor for creating a new account
        /// </summary>
        /// <param name="username">Unique username for the account</param>
        /// <param name="password">Account password</param>
        /// <param name="name">Display name for the account</param>
        public Account(string username, string password, string name)
        {
            Username = username;
            Password = password;
            Name = name;
        }

        /// <summary>
        /// Saves the current account to storage
        /// </summary>
        public void Save()
        {
            var accounts = LoadAccounts();
            accounts.Add(this);
            SaveAccounts(accounts);
        }

        /// <summary>
        /// Loads all accounts from storage
        /// </summary>
        /// <returns>List of all accounts in the system</returns>
        public static List<Account> LoadAccounts()
        {
            var accounts = new List<Account>();

            if (File.Exists(accountsFile))
            {
                var lines = File.ReadAllLines(accountsFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        accounts.Add(new Account(parts[0], parts[1], parts[2]));
                    }
                }
            }

            return accounts;
        }

        /// <summary>
        /// Saves multiple accounts to storage
        /// </summary>
        /// <param name="accounts">List of accounts to save</param>
        public static void SaveAccounts(List<Account> accounts)
        {
            using (var writer = new StreamWriter(accountsFile))
            {
                foreach (var account in accounts)
                {
                    writer.WriteLine($"{account.Username},{account.Password},{account.Name}");
                }
            }
        }

        /// <summary>
        /// Searches for accounts based on name or username
        /// </summary>
        /// <param name="query">Search term to match against name or username</param>
        /// <returns>List of matching accounts</returns>
        public static List<Account> SearchAccounts(string query)
        {
            var accounts = LoadAccounts();
            query = query.ToLower();

            return accounts.Where(a => a.Name.ToLower().Contains(query) || a.Username.ToLower().Contains(query)).ToList();
        }

        /// <summary>
        /// Updates an existing account's information
        /// </summary>
        /// <param name="updatedAccount">Account with updated information</param>
        public static void UpdateAccount(Account updatedAccount)
        {
            var accounts = LoadAccounts();

            var index = accounts.FindIndex(acc => acc.Username == updatedAccount.Username);

            if (index != -1)
            {
                accounts[index] = updatedAccount;
                SaveAccounts(accounts);
            }
            else
            {
                MessageBox.Show("Account not found for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Deletes an account from the system
        /// </summary>
        /// <param name="username">Username of the account to delete</param>
        public static void DeleteAccount(string username)
        {
            var accounts = LoadAccounts();
            var accountToDelete = accounts.FirstOrDefault(acc => acc.Username == username);

            if (accountToDelete != null)
            {
                accounts.Remove(accountToDelete);
                SaveAccounts(accounts);
            }
            else
            {
                MessageBox.Show("Account not found for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
