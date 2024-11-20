using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class EditAccountForm : Form
    {
        private Account _account;

        public EditAccountForm(Account account)
        {
            InitializeComponent();
            _account = account; // Armazena a conta passada
        }

        private void EditAccountForm_Load(object sender, EventArgs e)
        {
            if (_account != null) // Verifique se _account não é nulo
            {
                textBoxName.Text = _account.Name;        // Preencher o campo Nome
                textBoxUsername.Text = _account.Username; // Preencher o campo Username
            }
        }

        private void Savebuton_Click(object sender, EventArgs e)
        {
            // Atualizar os dados da conta com os novos valores
            _account.Name = textBoxName.Text;
            _account.Username = textBoxUsername.Text;
            _account.Password = textBoxPassword.Text;   

            

            // Chamar o método para atualizar a conta
            Account.UpdateAccount(_account); // Atualiza a conta no arquivo

            // Fechar o formulário
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}