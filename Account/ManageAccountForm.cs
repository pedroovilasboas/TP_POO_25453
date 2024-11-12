using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _25453_TP_POO
{
    public partial class ManageAccountForm : Form
    {
        public ManageAccountForm()
        {
            InitializeComponent();
        }

        private void ManageAccountForm_Load(object sender, EventArgs e)
        {

        }
        private void buttonGo_Click(object sender, EventArgs e)
        {
            string query = textBoxSearch.Text;

            var results = Account.SearchAccounts(query);

            // Exibir os resultados
            DisplayResults(results);
        }
        private void DisplayResults(List<Account> results)
        {
            checkedListBoxResults.Items.Clear();
            foreach (var account in results)
            {
                checkedListBoxResults.Items.Add($"{account.Name} ({account.Username})");
            }
        }



        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (checkedListBoxResults.CheckedItems.Count != 1)
            {
                MessageBox.Show("Please select exactly one account to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedAccountInfo = checkedListBoxResults.CheckedItems[0].ToString();
            string selectedUsername = selectedAccountInfo.Substring(selectedAccountInfo.IndexOf('(') + 1).TrimEnd(')');

            var account = Account.LoadAccounts().Find(acc => acc.Username == selectedUsername);

            if (account != null)
            {
                // Passa a conta selecionada para o formulário de edição
                EditAccountForm editForm = new EditAccountForm(account); // Passando a conta selecionada
                editForm.ShowDialog();

                // Atualize a lista após a edição
                string query = textBoxSearch.Text;
                var results = Account.SearchAccounts(query);
                DisplayResults(results);
            }
            else
            {
                MessageBox.Show("Account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkedListBoxResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (checkedListBoxResults.CheckedItems.Count != 1)
            {
                MessageBox.Show("Please select exactly one account to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedAccountInfo = checkedListBoxResults.CheckedItems[0].ToString();
            string selectedUsername = selectedAccountInfo.Substring(selectedAccountInfo.IndexOf('(') + 1).TrimEnd(')');

            // Perguntar ao usuário se ele tem certeza de que deseja excluir a conta
            var confirmResult = MessageBox.Show("Are you sure you want to delete this account?",
                                                 "Confirm Delete",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Chamar o método de exclusão
                Account.DeleteAccount(selectedUsername);

                // Atualizar a lista após a exclusão
                string query = textBoxSearch.Text;
                var results = Account.SearchAccounts(query);
                DisplayResults(results);

                MessageBox.Show("Account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
