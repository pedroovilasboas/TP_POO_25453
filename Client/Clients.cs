using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace POO_25453_TP
{
    /// <summary>
    /// Represents a client in the e-commerce system.
    /// Manages client information and provides CRUD operations.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Unique identifier for the client
        /// </summary>
        public int ClientID { get; set; }

        /// <summary>
        /// Client's username for authentication
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Client's password for authentication
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Client's full name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Client's email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Client's phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Client's street address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Client's city of residence
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Client's region or state
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Client's postal code
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// File path for storing client data
        /// </summary>
        private static string clientsFile = @"C:\PROGRAM_CS\TP_POO_25453\Client\clients.txt";

        /// <summary>
        /// Constructor for loading existing clients from storage
        /// </summary>
        /// <param name="clientID">Existing client ID</param>
        /// <param name="username">Client's username</param>
        /// <param name="password">Client's password</param>
        /// <param name="name">Client's full name</param>
        /// <param name="email">Client's email address</param>
        /// <param name="phone">Client's phone number</param>
        /// <param name="address">Client's street address</param>
        /// <param name="city">Client's city</param>
        /// <param name="region">Client's region</param>
        /// <param name="postalCode">Client's postal code</param>
        public Client(int clientID, string username, string password, string name, string email, string phone, string address, string city, string region, string postalCode)
        {
            ClientID = clientID;
            Username = username;
            Password = password;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
        }

        /// <summary>
        /// Constructor for creating new clients
        /// Automatically generates a new client ID
        /// </summary>
        /// <param name="username">Client's username</param>
        /// <param name="password">Client's password</param>
        /// <param name="name">Client's full name</param>
        /// <param name="email">Client's email address</param>
        /// <param name="phone">Client's phone number</param>
        /// <param name="address">Client's street address</param>
        /// <param name="city">Client's city</param>
        /// <param name="region">Client's region</param>
        /// <param name="postalCode">Client's postal code</param>
        public Client(string username, string password, string name, string email, string phone, string address, string city, string region, string postalCode)
        {
            ClientID = GenerateUniqueClientID();
            Username = username;
            Password = password;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
        }

        /// <summary>
        /// Generates a unique client ID for new clients
        /// </summary>
        /// <returns>New unique client ID</returns>
        private static int GenerateUniqueClientID()
        {
            var clients = LoadClients();
            return clients.Any() ? clients.Max(c => c.ClientID) + 1 : 1;
        }

        /// <summary>
        /// Loads all clients from storage
        /// </summary>
        /// <returns>List of all clients in the system</returns>
        public static List<Client> LoadClients()
        {
            var clients = new List<Client>();

            if (File.Exists(clientsFile))
            {
                var lines = File.ReadAllLines(clientsFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 10)
                    {
                        clients.Add(new Client(
                            int.Parse(parts[0]),
                            parts[1],
                            parts[2],
                            parts[3],
                            parts[4],
                            parts[5],
                            parts[6],
                            parts[7],
                            parts[8],
                            parts[9]
                        ));
                    }
                }
            }

            return clients;
        }

        /// <summary>
        /// Saves multiple clients to storage
        /// </summary>
        /// <param name="clients">List of clients to save</param>
        public static void SaveClients(List<Client> clients)
        {
            using (var writer = new StreamWriter(clientsFile))
            {
                foreach (var client in clients)
                {
                    writer.WriteLine($"{client.ClientID},{client.Username},{client.Password},{client.Name},{client.Email},{client.Phone},{client.Address},{client.City},{client.Region},{client.PostalCode}");
                }
            }
        }

        /// <summary>
        /// Saves the current client to storage
        /// </summary>
        public void Save()
        {
            var clients = LoadClients();
            clients.Add(this);
            SaveClients(clients);
        }

        /// <summary>
        /// Updates an existing client's information
        /// </summary>
        /// <param name="updatedClient">Client with updated information</param>
        /// <exception cref="Exception">Thrown when client is not found</exception>
        public static void UpdateClient(Client updatedClient)
        {
            var clients = LoadClients();
            var index = clients.FindIndex(cli => cli.ClientID == updatedClient.ClientID);

            if (index != -1)
            {
                clients[index] = updatedClient;
                SaveClients(clients);
            }
            else
            {
                throw new Exception("Client not found.");
            }
        }

        /// <summary>
        /// Deletes a client from the system
        /// </summary>
        /// <param name="clientID">ID of the client to delete</param>
        /// <exception cref="Exception">Thrown when client is not found</exception>
        public static void DeleteClient(int clientID)
        {
            var clients = LoadClients();
            var clientToDelete = clients.FirstOrDefault(cli => cli.ClientID == clientID);

            if (clientToDelete != null)
            {
                clients.Remove(clientToDelete);
                SaveClients(clients);
            }
            else
            {
                throw new Exception("Client not found.");
            }
        }

        /// <summary>
        /// Searches for clients based on name, username, or email
        /// </summary>
        /// <param name="query">Search term to match against name, username, or email</param>
        /// <returns>List of matching clients</returns>
        public static List<Client> SearchClients(string query)
        {
            var clients = LoadClients();
            query = query.ToLower();

            return clients.Where(c =>
                c.Name.ToLower().Contains(query) ||
                c.Username.ToLower().Contains(query) ||
                c.Email.ToLower().Contains(query)
            ).ToList();
        }
    }
}
