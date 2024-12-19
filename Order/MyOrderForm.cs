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
            try
            {
                // Setup DataGridView columns
                dgvMyOrders.Rows.Clear();
                if (dgvMyOrders.Columns.Count == 0)
                {
                    dgvMyOrders.Columns.Add("OrderID", "Order ID");
                    dgvMyOrders.Columns.Add("ProductID", "Product ID");
                    dgvMyOrders.Columns.Add("Quantity", "Quantity");
                    dgvMyOrders.Columns.Add("UnitPrice", "Unit Price");
                    dgvMyOrders.Columns.Add("TotalPrice", "Total Price");
                    dgvMyOrders.Columns.Add("Status", "Status");
                }

                string myOrdersFile = @"C:\PROGRAM_CS\TP_POO_25453\Order\myorders.txt";
                string orderDir = Path.GetDirectoryName(myOrdersFile);

                // Create directory if it doesn't exist
                if (!Directory.Exists(orderDir))
                {
                    Directory.CreateDirectory(orderDir);
                }

                // Create empty file if it doesn't exist
                if (!File.Exists(myOrdersFile))
                {
                    File.WriteAllText(myOrdersFile, "");
                    MessageBox.Show("You don't have any orders yet.", "No Orders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var fileContent = File.ReadAllLines(myOrdersFile);
                if (fileContent.Length == 0)
                {
                    MessageBox.Show("You don't have any orders yet.", "No Orders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Read orders from the file and filter by client ID
                var orders = fileContent
                    .Where(line => 
                    {
                        var parts = line.Split(',');
                        return parts.Length >= 2 && parts[1] == clientID.ToString();
                    })
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
                    dgvMyOrders.Rows.Add(
                        order.OrderID,
                        order.ProductID,
                        order.Quantity,
                        order.UnitPrice.ToString("C"),
                        order.TotalPrice.ToString("C"),
                        order.Status
                    );
                }

                if (dgvMyOrders.Rows.Count == 0)
                {
                    MessageBox.Show("You don't have any orders yet.", "No Orders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
