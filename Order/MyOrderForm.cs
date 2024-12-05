using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class MyOrdersForm : Form
    {
        private int clientID;

        // Constructor to initialize the form with a specific client ID
        public MyOrdersForm(int clientID)
        {
            InitializeComponent();
            this.clientID = clientID;
        }

        // Event triggered when the form loads
        private void MyOrdersForm_Load(object sender, EventArgs e)
        {
            LoadClientOrders(); // Load orders for the specific client
        }

        // Load and display orders for the current client from a file
        private void LoadClientOrders()
        {
            dgvMyOrders.Rows.Clear();

            string myOrdersFile = @"C:\PROGRAM_CS\25453_TP_POO\Order\myorders.txt";

            if (File.Exists(myOrdersFile))
            {
                // Read orders from the file and filter by client ID
                var orders = File.ReadAllLines(myOrdersFile)
                    .Where(line => line.Split(',')[1] == clientID.ToString()) // Filter by ClientID
                    .Select(line =>
                    {
                        var parts = line.Split(',');

                        return new
                        {
                            OrderID = int.Parse(parts[0]),
                            ProductID = int.Parse(parts[2]),
                            Quantity = int.Parse(parts[3]),
                            UnitPrice = int.Parse(parts[4]),
                            TotalPrice = int.Parse(parts[5]), 
                            Status = parts[6]
                        };
                    });

                // Add each order to the DataGridView
                foreach (var order in orders)
                {
                    dgvMyOrders.Rows.Add( order.OrderID, order.ProductID, order.Quantity, order.UnitPrice.ToString(), order.TotalPrice.ToString(), order.Status );
                }
            }
            else
            {
                // Show a warning if the file does not exist
                MessageBox.Show($"The file {myOrdersFile} does not exist. Please check the directory.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

