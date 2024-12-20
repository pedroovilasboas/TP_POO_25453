using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for managing clients in the system.
    /// Provides functionality for viewing, searching, editing, and deleting client accounts.
    /// Includes a data grid view to display all clients and their details, with search capabilities.
    /// </summary>
    public partial class ManageClientForm : Form
    {
        public ManageClientForm()
        {
            InitializeComponent();
        }

        // Search clients based on the query and display results
        private void buttonGo_Click(object sender, EventArgs e)
        {
            string query = textBoxSearch.Text;
            var results = Client.SearchClients(query);
            DisplayResults(results);
        }

        // Display search results in the data grid view
        private void DisplayResults(List<Client> results)
        {
            dataGridViewResults.Columns.Clear();
            dataGridViewResults.Columns.Add("ClientID", "Client ID");
            dataGridViewResults.Columns.Add("Name", "Name");
            dataGridViewResults.Columns.Add("Username", "Username");
            dataGridViewResults.Columns.Add("Email", "Email");
            dataGridViewResults.Columns.Add("Phone", "Phone");
            dataGridViewResults.Columns.Add("Address", "Address");
            dataGridViewResults.Columns.Add("City", "City");
            dataGridViewResults.Columns.Add("Region", "Region");
            dataGridViewResults.Columns.Add("PostalCode", "Postal Code");

            dataGridViewResults.Columns["ClientID"].Visible = false; // Hide ClientID

            dataGridViewResults.Rows.Clear();
            foreach (var client in results)
            {
                dataGridViewResults.Rows.Add(client.ClientID, client.Name, client.Username, client.Email, client.Phone, client.Address, client.City, client.Region, client.PostalCode);
            }
        }

        // Edit the selected client
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one client to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedClientID = int.Parse(dataGridViewResults.SelectedRows[0].Cells["ClientID"].Value.ToString());
            var client = Client.LoadClients().Find(cli => cli.ClientID == selectedClientID);

            if (client != null)
            {
                EditClientForm editForm = new EditClientForm(client);
                editForm.ShowDialog();

                string query = textBoxSearch.Text;
                var results = Client.SearchClients(query);
                DisplayResults(results);
            }
            else
            {
                MessageBox.Show("Client not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delete the selected client
        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one client to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedClientID = int.Parse(dataGridViewResults.SelectedRows[0].Cells["ClientID"].Value.ToString());

            var confirmResult = MessageBox.Show("Are you sure you want to delete this client?",
                                                 "Confirm Delete",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                Client.DeleteClient(selectedClientID);

                string query = textBoxSearch.Text;
                var results = Client.SearchClients(query);
                DisplayResults(results);

                MessageBox.Show("Client deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Close the form
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageClientForm_Load(object sender, EventArgs e)
        {
        }
    }
}
