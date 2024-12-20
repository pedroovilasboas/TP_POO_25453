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
                dgvOrders.Columns.Add("ClientName", "Client");
                dgvOrders.Columns.Add("ProductID", "Product ID");
                dgvOrders.Columns.Add("ProductName", "Product");
                dgvOrders.Columns.Add("Quantity", "Quantity");
                dgvOrders.Columns.Add("UnitPrice", "Unit Price");
                dgvOrders.Columns.Add("TotalPrice", "Total Price");
                dgvOrders.Columns.Add("Status", "Status");
                dgvOrders.Columns.Add("OrderDate", "Order Date");

                // Load orders using the Order class
                orders = Order.LoadOrders();

                if (!orders.Any())
                {
                    MessageBox.Show("No orders found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Load products and clients to get names
                var products = Product.LoadProducts();
                var clients = Client.LoadClients();

                // Configure DataGridView for better display
                dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvOrders.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvOrders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvOrders.AllowUserToAddRows = false;

                foreach (var order in orders)
                {
                    var product = products.FirstOrDefault(p => p.ProductID == order.ProductID);
                    var client = clients.FirstOrDefault(c => c.ClientID == order.ClientID);

                    string productName = product?.Name ?? "Unknown Product";
                    string clientName = client?.Name ?? "Unknown Client";

                    var row = new DataGridViewRow();
                    row.CreateCells(dgvOrders);
                    row.Cells[0].Value = order.OrderID;
                    row.Cells[1].Value = order.ClientID;
                    row.Cells[2].Value = clientName;
                    row.Cells[3].Value = order.ProductID;
                    row.Cells[4].Value = productName;
                    row.Cells[5].Value = order.Quantity;
                    row.Cells[6].Value = order.UnitPrice.ToString("C2");
                    row.Cells[7].Value = order.TotalPrice.ToString("C2");
                    row.Cells[8].Value = order.Status;
                    row.Cells[9].Value = order.OrderDate.ToString("yyyy-MM-dd HH:mm:ss");

                    dgvOrders.Rows.Add(row);
                }

                // Adjust column widths
                dgvOrders.Columns["OrderID"].Width = 70;
                dgvOrders.Columns["ClientID"].Width = 70;
                dgvOrders.Columns["ClientName"].Width = 150;
                dgvOrders.Columns["ProductID"].Width = 70;
                dgvOrders.Columns["ProductName"].Width = 150;
                dgvOrders.Columns["Quantity"].Width = 70;
                dgvOrders.Columns["UnitPrice"].Width = 100;
                dgvOrders.Columns["TotalPrice"].Width = 100;
                dgvOrders.Columns["Status"].Width = 80;
                dgvOrders.Columns["OrderDate"].Width = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMarkAsShipped_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int orderID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);
                var order = orders.FirstOrDefault(o => o.OrderID == orderID);

                if (order != null)
                {
                    order.UpdateStatus("Shipped");
                    LoadOrders(); // Reload to show updated status
                    MessageBox.Show("Order status updated to Shipped.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrdersManagementForm_Load(object sender, EventArgs e)
        {
        }
    }
}
