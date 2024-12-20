using System;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Formulário para gerenciar pedidos no sistema.
    /// </summary>
    public partial class OrdersForm : Form
    {
        /// <summary>
        /// Inicializa uma nova instância de OrdersForm.
        /// </summary>
        public OrdersForm()
        {
            InitializeComponent();
            LoadOrders();
        }

        /// <summary>
        /// Carrega e exibe todos os pedidos no sistema.
        /// </summary>
        private void LoadOrders()
        {
            var orders = Order.LoadOrders();

            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.Columns.Clear();

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderID",
                HeaderText = "Order ID",
                ReadOnly = true
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ClientID",
                HeaderText = "Client ID",
                ReadOnly = true
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ClientName",
                HeaderText = "Client Name",
                ReadOnly = true
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductID",
                HeaderText = "Product ID",
                ReadOnly = true
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Quantity",
                ReadOnly = true
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Unit Price",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OriginalPrice",
                HeaderText = "Original Price",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalPrice",
                HeaderText = "Total Price",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Status",
                ReadOnly = true
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderDate",
                HeaderText = "Order Date",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm:ss" }
            });

            orders = orders.OrderByDescending(o => o.OrderID).ToList();
            dgvOrders.DataSource = orders;
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var order = (Order)dgvOrders.SelectedRows[0].DataBoundItem;
                cmbStatus.Text = order.Status;
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var order = (Order)dgvOrders.SelectedRows[0].DataBoundItem;
                string newStatus = cmbStatus.Text;

                if (order.Status != newStatus)
                {
                    order.UpdateStatus(newStatus);
                    LoadOrders();
                    MessageBox.Show($"Order {order.OrderID} status updated to {newStatus}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
        }
    }
}
