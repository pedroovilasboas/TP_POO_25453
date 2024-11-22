using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent(); // Garante que o arquivo Designer seja carregado
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            // Adicione a lógica do botão Login aqui
            MessageBox.Show("Login button clicked");
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            // Fecha o formulário
            this.Close();
        }
    }
}
