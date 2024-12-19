using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        // Absolute file path for accounts.txt
        private static string accountsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Account\accounts.txt");

        public Account(string username, string password, string name)
        {
            Username = username;
            Password = password;
            Name = name;
        }

        // Method to save account to file
        public void Save()
        {
            var accounts = LoadAccounts();
            accounts.Add(this);
            SaveAccounts(accounts);
        }

        // Method to load all accounts from file
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

        // Method to save a list of accounts to file
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

        // Method to search accounts by name or username
        public static List<Account> SearchAccounts(string query)
        {
            var accounts = LoadAccounts();
            query = query.ToLower();

            return accounts.Where(a => a.Name.ToLower().Contains(query) || a.Username.ToLower().Contains(query)).ToList();
        }

        // Method to update account information
        public static void UpdateAccount(Account updatedAccount)
        {
            var accounts = LoadAccounts();

            // Find account to update by username
            var index = accounts.FindIndex(acc => acc.Username == updatedAccount.Username);

            if (index != -1)
            {
                // Update account in the list
                accounts[index] = updatedAccount;

                // Save all accounts back to file
                SaveAccounts(accounts);
            }
            else
            {
                // Show error if account not found
                MessageBox.Show("Account not found for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        public static void DeleteAccount(string username)
        {
            var accounts = LoadAccounts();

            
            var accountToDelete = accounts.FirstOrDefault(acc => acc.Username == username);

            if (accountToDelete != null)
            {
                accounts.Remove(accountToDelete); // Remove account from list
                SaveAccounts(accounts); // Save updated list to file
            }
            else
            {
                MessageBox.Show("Account not found for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
