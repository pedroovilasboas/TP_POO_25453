using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public class Client
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }

        // File path for clients.txt
        private static string clientsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Client\clients.txt");

        public Client(string username, string password, string name, string email, string phone, string address, string city, string region, string postalCode)
        {
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

        // Method to save a client
        public void Save()
        {
            var clients = LoadClients();
            clients.Add(this);
            SaveClients(clients);
        }

        // Method to load all clients from file
        public static List<Client> LoadClients()
        {
            var clients = new List<Client>();

            if (File.Exists(clientsFile))
            {
                var lines = File.ReadAllLines(clientsFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 9)
                    {
                        clients.Add(new Client(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7], parts[8]));
                    }
                }
            }

            Console.WriteLine($"Loaded {clients.Count} clients."); // Debugging
            return clients;
        }

        // Method to save a list of clients to file
        public static void SaveClients(List<Client> clients)
        {
            using (var writer = new StreamWriter(clientsFile))
            {
                foreach (var client in clients)
                {
                    writer.WriteLine($"{client.Username},{client.Password},{client.Name},{client.Email},{client.Phone},{client.Address},{client.City},{client.Region},{client.PostalCode}");
                }
            }
        }

        // Method to search clients by name, username, or email
        public static List<Client> SearchClients(string query)
        {
            var clients = LoadClients();
            query = query.ToLower();

            return clients.Where(c => c.Name.ToLower().Contains(query) || c.Username.ToLower().Contains(query) || c.Email.ToLower().Contains(query)).ToList();
        }

        // Method to update a client
        public static void UpdateClient(Client updatedClient)
        {
            var clients = LoadClients();
            var index = clients.FindIndex(cli => cli.Username == updatedClient.Username);

            if (index != -1)
            {
                clients[index] = updatedClient;
                SaveClients(clients);
                Console.WriteLine($"Updated client: {updatedClient.Username}"); // Debugging
            }
            else
            {
                MessageBox.Show("Client not found for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Client not found: {updatedClient.Username}"); // Debugging
            }
        }

        // Method to delete a client by username
        public static void DeleteClient(string username)
        {
            var clients = LoadClients();
            var clientToDelete = clients.FirstOrDefault(cli => cli.Username == username);

            if (clientToDelete != null)
            {
                clients.Remove(clientToDelete);
                SaveClients(clients);
                Console.WriteLine($"Deleted client: {username}"); // Debugging
            }
            else
            {
                MessageBox.Show("Client not found for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Client not found: {username}"); // Debugging
            }
        }
    }
}
