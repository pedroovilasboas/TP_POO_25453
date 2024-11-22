using System;
using System.Collections.Generic;
using System.IO;

namespace POO_25453_TP.DAL
{
    public static class LoginDAL
    {
        // Retrieves the list of client records from the file
        public static List<string> GetClients()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Client", "clients.txt");
            return GetDataFromFile(filePath);
        }

        // Retrieves the list of account records from the file
        public static List<string> GetAccounts()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Account", "accounts.txt");
            return GetDataFromFile(filePath);
        }

        // Generic method to retrieve data from a file
        private static List<string> GetDataFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }

            // Read all lines from the file and return as a list
            return new List<string>(File.ReadAllLines(filePath));
        }
    }
}
