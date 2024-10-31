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

        // Caminho para o arquivo accounts.txt
        //private static string accountsFile = Path.Combine(Environment.CurrentDirectory, "accounts.txt");


        // Caminho para o arquivo absuluto para saccounts.txt
        private static string accountsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Account\accounts.txt");


        public Account(string username, string password)
        {
            Username = username;
            Password = password;
        }

        // Método para salvar uma conta no arquivo
        public void Save()
        {
            var accounts = LoadAccounts();
            accounts.Add(this);
            SaveAccounts(accounts);
        }

        // Método para carregar todas as contas do arquivo
        public static List<Account> LoadAccounts()
        {
            var accounts = new List<Account>();

            if (File.Exists(accountsFile))
            {
                var lines = File.ReadAllLines(accountsFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        accounts.Add(new Account(parts[0], parts[1]));
                    }
                }
            }

            return accounts;
        }

        // Método para salvar todas as contas no arquivo
        public static void SaveAccounts(List<Account> accounts)
        {
            using (var writer = new StreamWriter(accountsFile))
            {
                foreach (var account in accounts)
                {
                    writer.WriteLine($"{account.Username},{account.Password}");
                }
            }
        }
    }

}
