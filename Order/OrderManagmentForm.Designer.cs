namespace POO_25453_TP
{
    partial class OrdersManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnMarkAsShipped;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnMarkAsShipped = new System.Windows.Forms.Button();

            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.Add("OrderID", "Order ID");
            this.dgvOrders.Columns.Add("ClientID", "Client ID");
            this.dgvOrders.Columns.Add("ProductID", "Product ID");
            this.dgvOrders.Columns.Add("Quantity", "Quantity");
            this.dgvOrders.Columns.Add("Status", "Status");
            this.dgvOrders.Location = new System.Drawing.Point(12, 12);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.Size = new System.Drawing.Size(600, 300);
            this.dgvOrders.TabIndex = 0;

            // 
            // btnMarkAsShipped
            // 
            this.btnMarkAsShipped.Location = new System.Drawing.Point(620, 20);
            this.btnMarkAsShipped.Name = "btnMarkAsShipped";
            this.btnMarkAsShipped.Size = new System.Drawing.Size(150, 30);
            this.btnMarkAsShipped.TabIndex = 1;
            this.btnMarkAsShipped.Text = "Mark as Shipped";
            this.btnMarkAsShipped.UseVisualStyleBackColor = true;
            this.btnMarkAsShipped.Click += new System.EventHandler(this.btnMarkAsShipped_Click);

            // 
            // OrdersManagementForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.Controls.Add(this.btnMarkAsShipped);
            this.Controls.Add(this.dgvOrders);
            this.Name = "OrdersManagementForm";
            this.Text = "Orders Management";
        }
    }
}
