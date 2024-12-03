using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class EditClientForm : Form
    {
        private Client client; // Stores the passed client object
        private bool isClientEditing; // indicate the context

        public EditClientForm(Client client, bool isClientEditing)
        {
            InitializeComponent();
            this.client = client;
            this.isClientEditing = isClientEditing; // Assign the context
        }


        private void EditClientForm_Load(object sender, EventArgs e)
        {
            if (client != null) // Check if the client object is not null
            {
                // Populate the text fields with client data
                textBoxName.Text = client.Name;
                textBoxUsername.Text = client.Username;
                textBoxUsername.ReadOnly = true; // Make the username field read-only
                textBoxEmail.Text = client.Email;
                textBoxPhone.Text = client.Phone;
                textBoxAddress.Text = client.Address;
                textBoxCity.Text = client.City;
                textBoxRegion.Text = client.Region;
                textBoxPostalCode.Text = client.PostalCode;
                textBoxPassword.Text = ""; // Leave the password field empty
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Update client data with form values
                client.Name = textBoxName.Text;
                client.Email = textBoxEmail.Text;
                client.Phone = textBoxPhone.Text;
                client.Address = textBoxAddress.Text;
                client.City = textBoxCity.Text;
                client.Region = textBoxRegion.Text;
                client.PostalCode = textBoxPostalCode.Text;

                bool passwordUpdated = false;

                // Update password only if a new value is provided
                if (!string.IsNullOrEmpty(textBoxPassword.Text))
                {
                    client.Password = textBoxPassword.Text;
                    passwordUpdated = true; // Flag to indicate the password was changed
                }

                // Save changes
                Client.UpdateClient(client);

                // Show success message
                MessageBox.Show("Client information has been updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Handle behavior based on the context
                if (isClientEditing && passwordUpdated)
                {
                    MessageBox.Show("Your password has been changed. Please log in again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Close the current form
                    this.Close();

                    // Close the ClientPage (main form) if available
                    var parentForm = this.Owner as ClientPage;
                    if (parentForm != null)
                    {
                        parentForm.Close();
                    }

                    // Reopen the LoginForm
                    var loginselectionForm = new LoginSelectionForm();
                    loginselectionForm.Show();
                }
                else
                {
                    // Close the form without redirecting to login
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ButtonClose_Click(object sender, EventArgs e)
        {
            // Close the form without saving changes
            this.Close();
        }
    }
}
