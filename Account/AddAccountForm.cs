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
    public partial class AddAccountForm : Form
    {

        public AddAccountForm()
        {
            InitializeComponent();
        }



        private void AddAccountForm_Load(object sender, EventArgs e)
        {

        }

        private void Addbuton_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;




            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Account newAccount = new Account(username, password);
            newAccount.Save();

            Account account = new Account("testeUser", "testePassword");
            account.Save();





            MessageBox.Show("Account added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }



       
    }



}

