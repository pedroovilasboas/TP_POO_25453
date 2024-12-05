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
            dgvOrders.Columns.Clear(); // Clear existing columns

            // Add columns with the correct names
            dgvOrders.Columns.Add("OrderID", "Order ID");
            dgvOrders.Columns.Add("ClientID", "Client ID");
            dgvOrders.Columns.Add("ProductID", "Product ID");
            dgvOrders.Columns.Add("Quantity", "Quantity");
            dgvOrders.Columns.Add("UnitPrice", "Unit Price");
            dgvOrders.Columns.Add("TotalPrice", "Total Price");
            dgvOrders.Columns.Add("Status", "Status");

            // Load order data
            string ordersFile = @"C:\PROGRAM_CS\25453_TP_POO\Order\orders.txt";

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
                            UnitPrice = int.Parse(parts[4]),
                            TotalPrice = int.Parse(parts[5]),
                            Status = parts[6]
                        };
                    });

                foreach (var order in orders)
                {
                    dgvOrders.Rows.Add(
                        order.OrderID,
                        order.ClientID,
                        order.ProductID,
                        order.Quantity,
                        order.UnitPrice,
                        order.TotalPrice,
                        order.Status
                    );
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

                // Absolute paths for the files
                string ordersFile = @"C:\PROGRAM_CS\25453_TP_POO\Order\orders.txt";
                string myOrdersFile = @"C:\PROGRAM_CS\25453_TP_POO\Order\myorders.txt";

                if (File.Exists(ordersFile))
                {
                    var orders = File.ReadAllLines(ordersFile).ToList();
                    bool orderUpdated = false;

                    // Update status in orders.txt
                    for (int i = 0; i < orders.Count; i++)
                    {
                        var parts = orders[i].Split(',');

                        if (int.Parse(parts[0]) == orderId) // Find the order by ID
                        {
                            if (parts[6] == "Pending") // Check if the status is "Pending"
                            {
                                parts[6] = "Shipped"; // Update status to "Shipped"
                                orders[i] = string.Join(",", parts); // Update the line in the file
                                orderUpdated = true;
                            }
                        }
                    }

                    // Save changes to orders.txt
                    if (orderUpdated)
                    {
                        File.WriteAllLines(ordersFile, orders);

                        // Update status in myorders.txt
                        if (File.Exists(myOrdersFile))
                        {
                            var myOrders = File.ReadAllLines(myOrdersFile).ToList();

                            for (int i = 0; i < myOrders.Count; i++)
                            {
                                var parts = myOrders[i].Split(',');

                                if (int.Parse(parts[0]) == orderId) // Find the order by ID
                                {
                                    parts[6] = "Shipped"; // Update status to "Shipped"
                                    myOrders[i] = string.Join(",", parts); // Update the line in the file
                                }
                            }

                            // Save changes to myorders.txt
                            File.WriteAllLines(myOrdersFile, myOrders);
                        }

                        LoadOrders(); // Reload orders in the admin interface
                        MessageBox.Show($"Order {orderId} marked as 'Shipped'.", "Order Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("The selected order is already shipped.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void OrdersManagementForm_Load(object sender, EventArgs e)
        {
        }
    }
}
