using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class ManageClientForm : Form
    {
        public ManageClientForm()
        {
            InitializeComponent();
        }



        // Event triggered when the "Go" button is clicked
        private void buttonGo_Click(object sender, EventArgs e)
        {
            string query = textBoxSearch.Text;

            
            var results = Client.SearchClients(query);

          
            DisplayResults(results);
        }

        // Method to display the search results in the DataGridView
        private void DisplayResults(List<Client> results)
        {
           
            dataGridViewResults.Columns.Clear();
            dataGridViewResults.Columns.Add("Name", "Name");
            dataGridViewResults.Columns.Add("Username", "Username");
            dataGridViewResults.Columns.Add("Email", "Email");
            dataGridViewResults.Columns.Add("Phone", "Phone");
            dataGridViewResults.Columns.Add("Address", "Address");
            dataGridViewResults.Columns.Add("City", "City");
            dataGridViewResults.Columns.Add("Region", "Region");
            dataGridViewResults.Columns.Add("PostalCode", "Postal Code");

            // Clear existing rows and populate new data
            dataGridViewResults.Rows.Clear();
            foreach (var client in results)
            {
                dataGridViewResults.Rows.Add(client.Name, client.Username, client.Email, client.Phone, client.Address, client.City, client.Region, client.PostalCode);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Ensure exactly one row is selected
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one client to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the username of the selected client
            string selectedUsername = dataGridViewResults.SelectedRows[0].Cells["Username"].Value.ToString();

            // Load all clients and find the one matching the username
            var client = Client.LoadClients().Find(cli => cli.Username == selectedUsername);

            if (client != null)
            {
                // Open the edit form with isClientEditing = false (admin editing)
                EditClientForm editForm = new EditClientForm(client, false); 
                editForm.ShowDialog();

                // Refresh the list of results after editing
                string query = textBoxSearch.Text;
                var results = Client.SearchClients(query);
                DisplayResults(results);
            }
            else
            {
                // Show an error message if the client was not found
                MessageBox.Show("Client not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Client not found in buttonEdit_Click: {selectedUsername}"); // Debugging
            }
        }

   
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Ensure exactly one row is selected
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one client to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the username of the selected client
            string selectedUsername = dataGridViewResults.SelectedRows[0].Cells["Username"].Value.ToString();

            // Confirm the deletion with the user
            var confirmResult = MessageBox.Show("Are you sure you want to delete this client?",
                                                 "Confirm Delete",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Delete the selected client
                Client.DeleteClient(selectedUsername);

                // Refresh the list of results after deletion
                string query = textBoxSearch.Text;
                var results = Client.SearchClients(query);
                DisplayResults(results);

                MessageBox.Show("Client deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void dataGridViewResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Code to handle cell clicks (if needed)
        }
    }
}
