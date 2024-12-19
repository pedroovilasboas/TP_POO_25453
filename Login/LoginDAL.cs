using System;
using System.Collections.Generic;
using System.IO;

namespace POO_25453_TP.DAL
{
    public static class Login
    {
        // Validate login for a client using their username and password
        public static bool ValidateClientLogin(string username, string password)
        {
            
            string filePath = @"C:\PROGRAM_CS\TP_POO_25453\Client\clients.txt";
            return ValidateCredentials(username, password, filePath);
        }

        // Validate login for an account using the username and password
        public static bool ValidateAccountLogin(string username, string password)
        {
            
            string filePath = @"C:\PROGRAM_CS\TP_POO_25453\Account\accounts.txt";
            return ValidateCredentials(username, password, filePath);
        }

        // General method to validate credentials for both clients and accounts
        private static bool ValidateCredentials(string username, string password, string filePath)
        {
            
            if (!File.Exists(filePath))
            {
                return false; // Return false instead of throwing exception
            }

            // Read all lines from the file
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
               
                var parts = line.Split(',');

                // Check if the file is for accounts or clients
                if (filePath.Contains("accounts"))
                {
                    // Format for accounts: username,password,name
                    if (parts.Length >= 3 && parts[0] == username && parts[1] == password)
                    {
                        return true; // Valid account credentials
                    }
                }
                else if (filePath.Contains("clients"))
                {
                    // Format for clients: clientID,username,password,name,...
                    if (parts.Length >= 10 && parts[1] == username && parts[2] == password)
                    {
                        return true; // Valid client credentials
                    }
                }
            }

            return false;
        }
    }
}
