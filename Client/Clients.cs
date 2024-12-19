using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace POO_25453_TP
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }

        private static string clientsFile = @"C:\PROGRAM_CS\TP_POO_25453\Client\clients.txt";

        // Constructor with ClientID (used for loading existing clients)
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

        // Constructor without ClientID (used for new clients)
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

        // Generate a unique ClientID
        private static int GenerateUniqueClientID()
        {
            var clients = LoadClients();
            return clients.Any() ? clients.Max(c => c.ClientID) + 1 : 1;
        }

        // Load all clients from the file
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
                            int.Parse(parts[0]), // ClientID
                            parts[1],            // Username
                            parts[2],            // Password
                            parts[3],            // Name
                            parts[4],            // Email
                            parts[5],            // Phone
                            parts[6],            // Address
                            parts[7],            // City
                            parts[8],            // Region
                            parts[9]             // PostalCode
                        ));
                    }
                }
            }

            return clients;
        }

        // Save all clients to the file
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

        // Save the current client instance to the file
        public void Save()
        {
            var clients = LoadClients();
            clients.Add(this); // Add the current client
            SaveClients(clients); // Save the updated list
        }

        // Update an existing client
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

        // Delete a client by ClientID
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

        // Search for clients by query (name, username, or email)
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
