using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _25453_TP_POO
{
    public partial class ManageBrandForm : Form
    {
        public ManageBrandForm()
        {
            InitializeComponent();
        }

        private void ManageBrandForm_Load(object sender, EventArgs e)
        {
            // Load event handler if needed
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            string query = textBoxSearch.Text;
            var results = Brand.SearchBrands(query);
            DisplayResults(results);
        }

        private void DisplayResults(List<Brand> results)
        {
            dataGridViewResults.Columns.Clear();
            dataGridViewResults.Columns.Add("Name", "Name");
            dataGridViewResults.Columns.Add("Description", "Description");

            dataGridViewResults.Rows.Clear();
            foreach (var brand in results)
            {
                dataGridViewResults.Rows.Add(brand.Name, brand.Description);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewResults.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one brand to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedName = dataGridViewResults.SelectedRows[0].Cells["Name"].Value.ToString();
            var brand = Brand.LoadBrands().Find(brd => brd.Name == selectedName);

            if (brand != null)
            {
                EditBrandForm editForm = new EditBrandForm(brand);
                editForm.ShowDialog();

                string query = textBoxSearch.Text;
                var results = Brand.SearchBrands(query);
                DisplayResults(results);
            }
            else
            {
                MessageBox.Show("Brand not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewResults_SelectionChanged(object sender, EventArgs e)
        {
            // SelectionChanged event handler if needed
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
           
        }
    }
}
