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

        private void deleteAccountToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DeleteAccountForm deleteAccountForm = new DeleteAccountForm();
            deleteAccountForm.ShowDialog();
        }
    }
}
