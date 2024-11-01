namespace _25453_TP_POO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addAccountToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddAccountForm addAccountForm = new AddAccountForm();
            addAccountForm.ShowDialog();
        }

        private void manageAccountToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ManageAccountForm manageAccountForm = new ManageAccountForm();
            manageAccountForm.ShowDialog();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClientForm addClientForm = new AddClientForm();
            addClientForm.ShowDialog();
        }

        private void manageClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageClientForm manageClientForm = new ManageClientForm();
            manageClientForm.ShowDialog();
        }
    }
}
