namespace _25453_TP_POO
{
    public partial class Landpage : Form
    {
        public Landpage()
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



        private void Landpage_Load(object sender, EventArgs e)
        {
            menuStrip1.Visible = true;
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

        private void addBrandToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddBrandForm addBrandForm = new AddBrandForm();
            addBrandForm.ShowDialog();
        }

        private void manageBrandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageBrandForm manageBrandForm = new ManageBrandForm();
            manageBrandForm.ShowDialog();
        }

        private void brandToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.menuStrip1.Items.Add(this.brandToolStripMenuItem);
        }
    }
}