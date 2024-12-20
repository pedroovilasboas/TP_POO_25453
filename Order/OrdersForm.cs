using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace POO_25453_TP
{
    public partial class OrdersForm : Form
    {
        private DataGridView dgvOrders;
        private Button btnUpdateStatus;
        private ComboBox cmbStatus;
        private Label lblStatus;

        public OrdersForm()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void InitializeComponent()
        {
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();

            // 
            // dgvOrders
            // 
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(12, 12);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(960, 400);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);

            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateStatus.Location = new System.Drawing.Point(872, 425);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(100, 23);
            this.btnUpdateStatus.TabIndex = 1;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);

            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] { "Pending", "Shipped" });
            this.cmbStatus.Location = new System.Drawing.Point(745, 426);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 2;

            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(699, 429);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status:";

            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.dgvOrders);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "OrdersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orders Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void LoadOrders()
        {
            var orders = Order.LoadOrders();
            
            // Configurar as colunas do DataGridView
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

            // Ordenar por OrderID decrescente (mais recentes primeiro)
            orders = orders.OrderByDescending(o => o.OrderID).ToList();
            
            dgvOrders.DataSource = orders;

            // Ajustar o tamanho das colunas
            foreach (DataGridViewColumn col in dgvOrders.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
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
                    LoadOrders(); // Recarregar para mostrar as alterações
                    MessageBox.Show($"Order {order.OrderID} status updated to {newStatus}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
