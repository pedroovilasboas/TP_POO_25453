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
            dgvOrders = new DataGridView();
            btnMarkAsShipped = new Button();

            // 
            // dgvOrders
            // 
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Rename the columns to match the names used in the code
            dgvOrders.Columns.Add("OrderID", "Order ID");
            dgvOrders.Columns.Add("ClientID", "Client ID");
            dgvOrders.Columns.Add("ProductID", "Product ID");
            dgvOrders.Columns.Add("Quantity", "Quantity");
            dgvOrders.Columns.Add("UnitPrice", "Unit Price");
            dgvOrders.Columns.Add("TotalPrice", "Total Price");
            dgvOrders.Columns.Add("Status", "Status");

            dgvOrders.Location = new Point(14, 20);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.Size = new Size(759, 269);
            dgvOrders.TabIndex = 0;

            // 
            // btnMarkAsShipped
            // 
            btnMarkAsShipped.Location = new Point(815, 20);
            btnMarkAsShipped.Name = "btnMarkAsShipped";
            btnMarkAsShipped.Size = new Size(150, 30);
            btnMarkAsShipped.TabIndex = 1;
            btnMarkAsShipped.Text = "Mark as Shipped";
            btnMarkAsShipped.UseVisualStyleBackColor = true;
            btnMarkAsShipped.Click += btnMarkAsShipped_Click;

            // 
            // OrdersManagementForm
            // 
            ClientSize = new Size(998, 430);
            Controls.Add(btnMarkAsShipped);
            Controls.Add(dgvOrders);
            Name = "OrdersManagementForm";
            Text = "Orders Management";
        }
    }
}
