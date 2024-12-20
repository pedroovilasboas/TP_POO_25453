using System;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for displaying and managing a client's orders.
    /// Provides functionality to view order history and search through orders
    /// with details such as products, quantities, prices, and status.
    /// </summary>
    public partial class MyOrdersForm : Form
    {
        private readonly int clientID;

        /// <summary>
        /// Initializes a new instance of the MyOrdersForm.
        /// </summary>
        /// <param name="clientID">The ID of the client whose orders will be displayed.</param>
        public MyOrdersForm(int clientID)
        {
            InitializeComponent();
            this.clientID = clientID;
            SetupDataGridView();
        }

        /// <summary>
        /// Sets up the data grid view columns with appropriate headers and widths
        /// for displaying order information.
        /// </summary>
        private void SetupDataGridView()
        {
            dgvMyOrders.Columns.Clear();
            dgvMyOrders.Columns.Add("OrderID", "Order ID");
            dgvMyOrders.Columns.Add("ProductID", "Product ID");
            dgvMyOrders.Columns.Add("ProductName", "Product");
            dgvMyOrders.Columns.Add("Quantity", "Quantity");
            dgvMyOrders.Columns.Add("UnitPrice", "Unit Price");
            dgvMyOrders.Columns.Add("TotalPrice", "Total Price");
            dgvMyOrders.Columns.Add("Status", "Status");
            dgvMyOrders.Columns.Add("OrderDate", "Order Date");

            dgvMyOrders.Columns["OrderID"].Width = 70;
            dgvMyOrders.Columns["ProductID"].Width = 70;
            dgvMyOrders.Columns["ProductName"].Width = 150;
            dgvMyOrders.Columns["Quantity"].Width = 70;
            dgvMyOrders.Columns["UnitPrice"].Width = 100;
            dgvMyOrders.Columns["TotalPrice"].Width = 100;
            dgvMyOrders.Columns["Status"].Width = 80;
            dgvMyOrders.Columns["OrderDate"].Width = 150;
        }

        /// <summary>
        /// Displays the list of orders in the data grid view.
        /// Shows order details including product information, quantities, prices,
        /// status, and dates.
        /// </summary>
        /// <param name="orders">List of orders to display.</param>
        private void DisplayResults(System.Collections.Generic.List<Order> orders)
        {
            try
            {
                dgvMyOrders.Rows.Clear();

                if (!orders.Any())
                {
                    MessageBox.Show("No orders found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var products = Product.LoadProducts();

                foreach (var order in orders)
                {
                    var product = products.FirstOrDefault(p => p.ProductID == order.ProductID);
                    string productName = product?.Name ?? "Unknown Product";

                    dgvMyOrders.Rows.Add(
                        order.OrderID,
                        order.ProductID,
                        productName,
                        order.Quantity,
                        order.UnitPrice.ToString("C2"),
                        order.TotalPrice.ToString("C2"),
                        order.Status,
                        order.OrderDate.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the search button click event.
        /// Filters orders based on the search query, matching against order ID,
        /// status, or date.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = textBoxSearch.Text.Trim();
            var orders = Order.LoadClientOrders(clientID);

            if (!string.IsNullOrEmpty(searchQuery))
            {
                orders = orders.Where(o => 
                    o.OrderID.ToString().Contains(searchQuery) ||
                    o.Status.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    o.OrderDate.ToString("yyyy-MM-dd").Contains(searchQuery)
                ).ToList();
            }

            DisplayResults(orders);
        }

        /// <summary>
        /// Handles the close button click event. Closes the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the form load event. Loads and displays all orders
        /// for the client.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void MyOrdersForm_Load(object sender, EventArgs e)
        {
            ButtonSearch_Click(sender, e); // Load all orders initially
        }
    }
}
