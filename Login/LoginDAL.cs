using System;
using System.Collections.Generic;
using System.IO;

namespace POO_25453_TP.DAL
{
    /// <summary>
    /// Handles authentication and validation of user credentials.
    /// Provides methods for validating both client and account logins.
    /// </summary>
    public static class Login
    {
        /// <summary>
        /// Validates client login credentials against stored client data
        /// </summary>
        /// <param name="username">Client's username</param>
        /// <param name="password">Client's password</param>
        /// <returns>True if credentials are valid, false otherwise</returns>
        public static bool ValidateClientLogin(string username, string password)
        {
            // Validate login for a client using their username and password
            string filePath = @"C:\PROGRAM_CS\TP_POO_25453\Client\clients.txt";
            return ValidateCredentials(username, password, filePath);
        }

        /// <summary>
        /// Validates account login credentials against stored account data
        /// </summary>
        /// <param name="username">Account's username</param>
        /// <param name="password">Account's password</param>
        /// <returns>True if credentials are valid, false otherwise</returns>
        public static bool ValidateAccountLogin(string username, string password)
        {
            // Validate login for an account using the username and password
            string filePath = @"C:\PROGRAM_CS\TP_POO_25453\Account\accounts.txt";
            return ValidateCredentials(username, password, filePath);
        }

        /// <summary>
        /// General method to validate credentials for both clients and accounts
        /// </summary>
        /// <param name="username">Username to validate</param>
        /// <param name="password">Password to validate</param>
        /// <param name="filePath">Path to the credentials file</param>
        /// <returns>True if credentials are valid, false otherwise</returns>
        private static bool ValidateCredentials(string username, string password, string filePath)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                return false; // Return false instead of throwing exception
            }

            // Read all lines from the file
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                // Split the line into parts
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
