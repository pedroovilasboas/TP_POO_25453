using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class AddClientForm : Form
    {
        public AddClientForm()
        {
            InitializeComponent();
        }

        private void AddClientForm_Load(object sender, EventArgs e)
        {
        }

        private void AddButton_Click_1(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string name = textBoxName.Text;
            string email = textBoxEmail.Text;
            string phoneNumber = textBoxPhoneNumber.Text;
            string address = textBoxAddress.Text;
            string city = textBoxCity.Text;
            string region = textBoxRegion.Text;
            string postalCode = textBoxPostalCode.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(city) || string.IsNullOrEmpty(region) || string.IsNullOrEmpty(postalCode))
            {
                MessageBox.Show("All fields must be filled out.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new client with auto-generated ClientID
            Client newClient = new Client(username, password, name, email, phoneNumber, address, city, region, postalCode);
            newClient.Save(); // Save the new client to the file

            MessageBox.Show("Client added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
