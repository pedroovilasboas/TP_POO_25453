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

        private void ManageClientForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            string query = textBoxSearch.Text;

            var results = Client.SearchClients(query);

            DisplayResults(results);
        }

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

            dataGridViewResults.Rows.Clear();
            foreach (var client in results)
            {
                dataGridViewResults.Rows.Add(client.Name, client.Username, client.Email, client.Phone, client.Address, client.City, client.Region, client.PostalCode);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one client to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedUsername = dataGridViewResults.SelectedRows[0].Cells["Username"].Value.ToString();
            var client = Client.LoadClients().Find(cli => cli.Username == selectedUsername);

            if (client != null)
            {
                // Abre o formulário de edição de cliente com os dados do cliente selecionado
                EditClientForm editForm = new EditClientForm(client);
                editForm.ShowDialog();

                // Atualiza a lista de resultados após a edição
                string query = textBoxSearch.Text;
                var results = Client.SearchClients(query);
                DisplayResults(results);
            }
            else
            {
                MessageBox.Show("Client not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Client not found in buttonEdit_Click: {selectedUsername}"); // Debugging
            }
        }

        private void dataGridViewResults_SelectionChanged(object sender, EventArgs e)
        {
            //
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one client to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedUsername = dataGridViewResults.SelectedRows[0].Cells["Username"].Value.ToString();

            var confirmResult = MessageBox.Show("Are you sure you want to delete this client?",
                                                 "Confirm Delete",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                Client.DeleteClient(selectedUsername);

                string query = textBoxSearch.Text;
                var results = Client.SearchClients(query);
                DisplayResults(results);

                MessageBox.Show("Client deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
