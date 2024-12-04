using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace POO_25453_TP
{
    public partial class OrdersManagementForm : Form
    {
        private List<Order> orders;

        public OrdersManagementForm()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            dgvOrders.Rows.Clear();

            string ordersFile = @"C:\PROGRAM_CS\25453_TP_POO\Data\orders.txt";

            if (File.Exists(ordersFile))
            {
                var orders = File.ReadAllLines(ordersFile)
                    .Select(line =>
                    {
                        var parts = line.Split(',');
                        return new
                        {
                            OrderID = int.Parse(parts[0]),
                            ClientID = int.Parse(parts[1]),
                            ProductID = int.Parse(parts[2]),
                            Quantity = int.Parse(parts[3]),
                            UnitPrice = decimal.Parse(parts[4]),
                            TotalPrice = decimal.Parse(parts[5]),
                            Status = parts[6]
                        };
                    });

                foreach (var order in orders)
                {
                    dgvOrders.Rows.Add(order.OrderID, order.ClientID, order.ProductID, order.Quantity, order.UnitPrice, order.TotalPrice, order.Status);
                }
            }
        }


        private void btnMarkAsShipped_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var selectedRow = dgvOrders.SelectedRows[0];
                int orderId = int.Parse(selectedRow.Cells["OrderID"].Value.ToString());

                var order = orders.FirstOrDefault(o => o.OrderID == orderId);
                if (order != null && order.Status == "Para Envio")
                {
                    order.Status = "Enviado";
                    Order.SaveOrders(orders); // Save updated orders to file
                    LoadOrders(); // Refresh the DataGridView
                    MessageBox.Show($"Order {orderId} marked as 'Enviado'.", "Order Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The selected order is already shipped.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select an order to update.", "No Order Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OrdersManagementForm_Load(object sender, EventArgs e)
        {

        }
    }
}
