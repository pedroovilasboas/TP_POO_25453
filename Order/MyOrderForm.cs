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
                    .Where(line => int.Parse(line.Split(',')[1]) == clientID)
                    .Select(line =>
                    {
                        var parts = line.Split(',');
                        return new
                        {
                            OrderID = int.Parse(parts[0]),
                            ProductID = int.Parse(parts[2]),
                            Quantity = int.Parse(parts[3]),
                            UnitPrice = decimal.Parse(parts[4]),
                            TotalPrice = decimal.Parse(parts[5]),
                            Status = parts[6]
                        };
                    });

                foreach (var order in orders)
                {
                    dgvMyOrders.Rows.Add(order.OrderID, order.ProductID, order.Quantity, order.UnitPrice, order.TotalPrice, order.Status);
                }
            }
            else
            {
                MessageBox.Show("No orders found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}

