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
            // Clear the DataGridView before loading new data
            dgvOrders.Rows.Clear();

            // Absolute path to the orders.txt file
            string ordersFile = @"C:\PROGRAM_CS\25453_TP_POO\Order\orders.txt";

            // Check if the file exists
            if (File.Exists(ordersFile))
            {
                // Read all lines from the orders file
                var orders = File.ReadAllLines(ordersFile)
                    .Select(line =>
                    {
                        var parts = line.Split(',');
                        return new
                        {
                            OrderID = int.Parse(parts[0]),       // Parse OrderID
                            ClientID = int.Parse(parts[1]),     // Parse ClientID
                            ProductID = int.Parse(parts[2]),    // Parse ProductID
                            Quantity = int.Parse(parts[3]),     // Parse Quantity
                            UnitPrice = decimal.Parse(parts[4]), // Parse Unit Price
                            TotalPrice = decimal.Parse(parts[5]), // Parse Total Price
                            Status = parts[6]                  // Parse Status
                        };
                    });

                // Add each order to the DataGridView
                foreach (var order in orders)
                {
                    dgvOrders.Rows.Add(order.OrderID, order.ClientID, order.ProductID, order.Quantity, order.UnitPrice, order.TotalPrice, order.Status);
                }
            }
            else
            {
                MessageBox.Show($"The file {ordersFile} does not exist. Please check the directory.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void btnMarkAsShipped_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var selectedRow = dgvOrders.SelectedRows[0];
                int orderId = int.Parse(selectedRow.Cells["OrderID"].Value.ToString());

                // Absolute path to the orders.txt file
                string ordersFile = @"C:\PROGRAM_CS\25453_TP_POO\Order\orders.txt";

                // Check if the orders file exists
                if (File.Exists(ordersFile))
                {
                    // Read all lines from the orders file
                    var orders = File.ReadAllLines(ordersFile).ToList();

                    for (int i = 0; i < orders.Count; i++)
                    {
                        var parts = orders[i].Split(',');

                        if (int.Parse(parts[0]) == orderId) // Match OrderID
                        {
                            if (parts[6] == "Pending") // Check if the order is pending
                            {
                                parts[6] = "Shipped"; // Update status to 'Shipped'
                                orders[i] = string.Join(",", parts); // Update the order line
                                File.WriteAllLines(ordersFile, orders); // Save the updated orders to the file
                                LoadOrders(); // Refresh the DataGridView
                                MessageBox.Show($"Order {orderId} marked as 'Shipped'.", "Order Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("The selected order is already shipped.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"The file {ordersFile} does not exist. Please check the directory.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select an order to update.", "No Order Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
