using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace POO_25453_TP
{
    public partial class ClientPage : Form
    {
        private Client currentClient;
        private Cart cart = new Cart();


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


            var editClientForm = new EditClientForm(currentClient, true); // Pass true for client editing
            editClientForm.Owner = this;
            editClientForm.ShowDialog();
        }


        private void LoadFormIntoPanel(Form form)
        {
            // Clear the panel before adding the new form
            panel2.Controls.Clear();

            // Set the form as a child of the panel
            form.TopLevel = form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel2.Controls.Add(form);
            form.Show();
        }



        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Passa o mesmo carrinho para o ProductListForm
            ProductListForm productListForm = new ProductListForm(cart);
            LoadFormIntoPanel(productListForm);
        }

        private void myCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Passa o mesmo carrinho para o CartViewForm
            CartViewForm cartViewForm = new CartViewForm(cart);
            LoadFormIntoPanel(cartViewForm);
        }

        
    }
}   