using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    public partial class MyOrdersForm : Form
    {
        private int clientID;

        public MyOrdersForm(int clientID)
        {
            InitializeComponent();
            this.clientID = clientID;
        }

        private void MyOrdersForm_Load(object sender, EventArgs e)
        {
            LoadClientOrders();
        }

        private void LoadClientOrders()
        {
            // Clear the DataGridView before loading new data
            dgvMyOrders.Rows.Clear();

            // Absolute path to the myorders.txt file
            string myOrdersFile = @"C:\PROGRAM_CS\25453_TP_POO\Order\myorders.txt";

            // Check if the myorders.txt file exists
            if (File.Exists(myOrdersFile))
            {
                // Read all lines from the myorders.txt file
                var orders = File.ReadAllLines(myOrdersFile)
                    .Where(line => line.Split(',')[1] == clientID.ToString()) // Filter by ClientID
                    .Select(line =>
                    {
                        var parts = line.Split(',');
                        return new
                        {
                            OrderID = int.Parse(parts[0]),       // Parse OrderID
                            ProductID = int.Parse(parts[2]),    // Parse ProductID
                            Quantity = int.Parse(parts[3]),     // Parse Quantity
                            UnitPrice = decimal.Parse(parts[4]), // Parse Unit Price
                            TotalPrice = decimal.Parse(parts[5]), // Parse Total Price
                            Status = parts[6]                  // Parse Status
                        };
                    });

                // Add each filtered order to the DataGridView
                foreach (var order in orders)
                {
                    dgvMyOrders.Rows.Add(order.OrderID, order.ProductID, order.Quantity, order.UnitPrice, order.TotalPrice, order.Status);
                }
            }
            else
            {
                MessageBox.Show($"The file {myOrdersFile} does not exist. Please check the directory.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}

