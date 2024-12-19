namespace POO_25453_TP
{
    partial class MyOrdersForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvMyOrders;

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
            this.dgvMyOrders = new System.Windows.Forms.DataGridView();

            // 
            // dgvMyOrders
            // 
            this.dgvMyOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Rename the columns to match the names used in the code
            this.dgvMyOrders.Columns.Add("OrderID", "Order ID");
            this.dgvMyOrders.Columns.Add("ProductID", "Product ID");
            this.dgvMyOrders.Columns.Add("Quantity", "Quantity");
            this.dgvMyOrders.Columns.Add("UnitPrice", "Unit Price");
            this.dgvMyOrders.Columns.Add("TotalPrice", "Total Price");
            this.dgvMyOrders.Columns.Add("Status", "Status");

            this.dgvMyOrders.Location = new System.Drawing.Point(12, 12);
            this.dgvMyOrders.Name = "dgvMyOrders";
            this.dgvMyOrders.Size = new System.Drawing.Size(760, 400); // Adjust size for new columns
            this.dgvMyOrders.TabIndex = 0;

            // 
            // MyOrdersForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450); // Adjust size for the new layout
            this.Controls.Add(this.dgvMyOrders);
            this.Name = "MyOrdersForm";
            this.Text = "My Orders";
            this.Load += new System.EventHandler(this.MyOrdersForm_Load);
        }
    }
}
