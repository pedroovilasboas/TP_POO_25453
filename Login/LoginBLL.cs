using System;
using POO_25453_TP.DAL;

namespace POO_25453_TP.BLL
{
    public class LoginBLL
    {
        // Authenticates a client using their username and password
        public bool AuthenticateClient(string username, string password)
        {
            var clients = LoginDAL.GetClients();

            // Check if the username and password match any record
            foreach (var line in clients)
            {
                var parts = line.Split(';'); // Expected format: username;password
                if (parts.Length == 2 && parts[0] == username && parts[1] == password)
                {
                    return true;
                }
            }

            return false; // Return false if no match is found
        }

        // Authenticates an account using their username and password
        public bool AuthenticateAccount(string username, string password)
        {
            var accounts = LoginDAL.GetAccounts();

            // Check if the username and password match any record
            foreach (var line in accounts)
            {
                var parts = line.Split(';'); // Expected format: username;password
                if (parts.Length == 2 && parts[0] == username && parts[1] == password)
                {
                    return true;
                }
            }

            return false; // Return false if no match is found
        }
    }
}
