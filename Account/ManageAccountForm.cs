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

        private void editButton_Click(object sender, EventArgs e)
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
                // Abre um formulário de edição com as informações do usuário selecionado
                EditAccountForm editForm = new EditAccountForm();
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

       
    }
}
