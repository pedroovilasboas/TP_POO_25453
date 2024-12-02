using System;
using System.Collections.Generic;
using System.IO;

namespace POO_25453_TP.DAL
{
    public static class Login
    {
        public static bool ValidateClientLogin(string username, string password)
        {
            // Use the absolute path directly
            string filePath = @"C:\PROGRAM_CS\25453_TP_POO\Client\clients.txt";
            return ValidateCredentials(username, password, filePath);
        }

        public static bool ValidateAccountLogin(string username, string password)
        {
            // Use the absolute path directly
            string filePath = @"C:\PROGRAM_CS\25453_TP_POO\Account\accounts.txt";
            return ValidateCredentials(username, password, filePath);
        }

        // General credential validation logic
        private static bool ValidateCredentials(string username, string password, string filePath)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Credentials file not found: {filePath}");
            }

            // Read all lines from the file
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                // Split the line into parts (assuming ';' as the delimiter)
                var parts = line.Split(',');

                // Check if the line contains enough fields
                // For Clients: username;password;name;email;phone;address;city;region;postalcode
                // For Accounts: username;password;name
                if (parts.Length >= 3 && parts[0] == username && parts[1] == password)
                {
                    // Valid credentials
                    return true;
                }
            }

            // No match found
            return false;
        }
    }
}
