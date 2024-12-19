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
            try
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
                string ordersFile = @"C:\PROGRAM_CS\TP_POO_25453\Order\orders.txt";
                string ordersDirectory = Path.GetDirectoryName(ordersFile);

                // Create directory if it doesn't exist
                if (!Directory.Exists(ordersDirectory))
                {
                    Directory.CreateDirectory(ordersDirectory);
                }

                // Create empty orders file if it doesn't exist
                if (!File.Exists(ordersFile))
                {
                    File.WriteAllText(ordersFile, ""); // Create empty file
                    MessageBox.Show("No orders found. The orders list is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var fileContent = File.ReadAllLines(ordersFile);
                if (fileContent.Length == 0)
                {
                    MessageBox.Show("No orders found. The orders list is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var line in fileContent)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 7) // Make sure we have all required fields
                    {
                        try
                        {
                            dgvOrders.Rows.Add(
                                int.Parse(parts[0]), // OrderID
                                int.Parse(parts[1]), // ClientID
                                int.Parse(parts[2]), // ProductID
                                int.Parse(parts[3]), // Quantity
                                decimal.Parse(parts[4]), // UnitPrice
                                decimal.Parse(parts[5]), // TotalPrice
                                parts[6] // Status
                            );
                        }
                        catch (Exception ex)
                        {
                            // Log invalid line but continue processing others
                            Console.WriteLine($"Error processing order line: {line}. Error: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMarkAsShipped_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvOrders.SelectedRows[0];
                    int orderId = int.Parse(selectedRow.Cells["OrderID"].Value.ToString());

                    // Correct file paths
                    string ordersFile = @"C:\PROGRAM_CS\TP_POO_25453\Order\orders.txt";
                    string myOrdersFile = @"C:\PROGRAM_CS\TP_POO_25453\Order\myorders.txt";

                    // Create directories if they don't exist
                    Directory.CreateDirectory(Path.GetDirectoryName(ordersFile));
                    Directory.CreateDirectory(Path.GetDirectoryName(myOrdersFile));

                    // Create files if they don't exist
                    if (!File.Exists(ordersFile))
                    {
                        File.WriteAllText(ordersFile, "");
                    }
                    if (!File.Exists(myOrdersFile))
                    {
                        File.WriteAllText(myOrdersFile, "");
                    }

                    var orders = File.Exists(ordersFile) ? File.ReadAllLines(ordersFile).ToList() : new List<string>();
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
                    MessageBox.Show("Please select an order to update.", "No Order Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrdersManagementForm_Load(object sender, EventArgs e)
        {
        }
    }
}
