using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class ClientPage : Form
    {
        private Client currentClient;

        // Constructor that accepts a Client as a parameter
        public ClientPage(Client client)
        {
            currentClient = client;  // Stores the received client
            InitializeComponent();

            // Using client information, such as name, to update the interface
            this.Text = $"Welcome, {currentClient.Name}!";
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentClient == null)
            {
                MessageBox.Show("No client information available. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Abrir EditClientForm para o cliente (isClientEditing = true)
            var editClientForm = new EditClientForm(currentClient, true); // Pass true for client editing
            editClientForm.Owner = this; // Define ClientPage como o dono do formulário
            editClientForm.ShowDialog();
        }


        private void LoadFormIntoPanel(Form form)
        {
            // Clear existing controls in the panel
            panel2.Controls.Clear();

            // Set the form as a child of the panel
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel2.Controls.Add(form);
            form.Show();
        }

    }
}