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
            dgvMyOrders.Rows.Clear();

            string myOrdersFile = @"C:\PROGRAM_CS\25453_TP_POO\Order\myorders.txt";

            if (File.Exists(myOrdersFile))
            {
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
                            UnitPrice = int.Parse(parts[4]), // Read as integer
                            TotalPrice = int.Parse(parts[5]), // Read as integer
                            Status = parts[6]
                        };
                    });

                foreach (var order in orders)
                {
                    dgvMyOrders.Rows.Add(
                        order.OrderID,
                        order.ProductID,
                        order.Quantity,
                        order.UnitPrice.ToString(), // Display as integer
                        order.TotalPrice.ToString(), // Display as integer
                        order.Status
                    );
                }
            }
            else
            {
                MessageBox.Show($"The file {myOrdersFile} does not exist. Please check the directory.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



    }
}

