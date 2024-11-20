using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class EditClientForm : Form
    {
        private Client _client;

        public EditClientForm(Client client)
        {
            InitializeComponent();
            _client = client; // Armazena o cliente passado
        }

        private void EditClientForm_Load(object sender, EventArgs e)
        {
            if (_client != null) // Verifique se _client não é nulo
            {
                textBoxName.Text = _client.Name;
                textBoxUsername.Text = _client.Username;
                textBoxEmail.Text = _client.Email;
                textBoxPhone.Text = _client.Phone;
                textBoxAddress.Text = _client.Address;
                textBoxCity.Text = _client.City;
                textBoxRegion.Text = _client.Region;
                textBoxPostalCode.Text = _client.PostalCode;
                textBoxPassword.Text = ""; // Deixa o campo de senha vazio
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Atualizar os dados do cliente com os novos valores
            _client.Name = textBoxName.Text;
            _client.Username = textBoxUsername.Text;
            _client.Email = textBoxEmail.Text;
            _client.Phone = textBoxPhone.Text;
            _client.Address = textBoxAddress.Text;
            _client.City = textBoxCity.Text;
            _client.Region = textBoxRegion.Text;
            _client.PostalCode = textBoxPostalCode.Text;

            // Atualizar a senha somente se um novo valor foi inserido
            if (!string.IsNullOrEmpty(textBoxPassword.Text))
            {
                _client.Password = textBoxPassword.Text;
            }

            // Chamar o método para atualizar o cliente
            Client.UpdateClient(_client); // Atualiza o cliente no arquivo

            // Fechar o formulário
            this.Close();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
