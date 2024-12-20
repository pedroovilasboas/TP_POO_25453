using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for editing existing client information.
    /// Allows modification of client details including personal information,
    /// contact details, and optionally updating their password.
    /// </summary>
    public partial class EditClientForm : Form
    {
        private Client client; // Stores the passed client object

        public EditClientForm(Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void EditClientForm_Load(object sender, EventArgs e)
        {
            if (client != null)
            {
                // Populate the text fields with client data
                textBoxName.Text = client.Name;
                textBoxUsername.Text = client.Username;
                textBoxUsername.ReadOnly = true; // Make username read-only
                textBoxEmail.Text = client.Email;
                textBoxPhone.Text = client.Phone;
                textBoxAddress.Text = client.Address;
                textBoxCity.Text = client.City;
                textBoxRegion.Text = client.Region;
                textBoxPostalCode.Text = client.PostalCode;
                textBoxPassword.Text = ""; // Leave password field empty
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Update client information
            client.Name = textBoxName.Text;
            client.Email = textBoxEmail.Text;
            client.Phone = textBoxPhone.Text;
            client.Address = textBoxAddress.Text;
            client.City = textBoxCity.Text;
            client.Region = textBoxRegion.Text;
            client.PostalCode = textBoxPostalCode.Text;

            if (!string.IsNullOrEmpty(textBoxPassword.Text))
            {
                client.Password = textBoxPassword.Text; // Update password if provided
            }

            // Save changes to the client using ClientID
            Client.UpdateClient(client);

            MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form without saving changes
        }
    }
}
