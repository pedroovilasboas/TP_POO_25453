using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25453_TP_POO
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        // Caminho para o arquivo accounts.txt
        //private static string accountsFile = Path.Combine(Environment.CurrentDirectory, "accounts.txt");


        // Caminho para o arquivo absuluto para saccounts.txt
        private static string accountsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Account\accounts.txt");


        public Account(string username, string password, string name)
        {
            Username = username;
            Password = password;
            Name = name;

        }

        // Save file method
        public void Save()
        {
            var accounts = LoadAccounts();
            accounts.Add(this);
            SaveAccounts(accounts);
        }

        // Load Accounts method
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

        // Save accounts
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

        //Search accounts
        public static List<Account> SearchAccounts(string query)
        {
            var accounts = LoadAccounts();
            query = query.ToLower();

            return accounts.Where(a => a.Name.ToLower().Contains(query) || a.Username.ToLower().Contains(query)).ToList();
        }


        public static void UpdateAccount(Account updatedAccount)
        {
            // Carregar todas as contas
            var accounts = LoadAccounts();

            // Encontrar a conta a ser atualizada pelo Username
            var index = accounts.FindIndex(acc => acc.Username == updatedAccount.Username);

            if (index != -1)
            {
                // Atualizar a conta na lista
                accounts[index] = updatedAccount;

                // Salvar todas as contas de volta no arquivo
                SaveAccounts(accounts);
            }
            else
            {
                // Se não encontrar a conta, pode adicionar um erro ou mensagem
                MessageBox.Show("Account not found for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DeleteAccount(string username)
        {
            var accounts = LoadAccounts();

            // Encontrar a conta a ser excluída
            var accountToDelete = accounts.FirstOrDefault(acc => acc.Username == username);

            if (accountToDelete != null)
            {
                accounts.Remove(accountToDelete); // Remover a conta da lista
                SaveAccounts(accounts); // Salvar a lista atualizada no arquivo
            }
            else
            {
                MessageBox.Show("Account not found for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
