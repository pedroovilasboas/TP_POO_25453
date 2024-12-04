namespace POO_25453_TP
{
    partial class CartViewForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvCartItems;
        private System.Windows.Forms.Button btnIncreaseQuantity;
        private System.Windows.Forms.Button btnDecreaseQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnRemove;

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
            this.dgvCartItems = new System.Windows.Forms.DataGridView();
            this.btnIncreaseQuantity = new System.Windows.Forms.Button();
            this.btnDecreaseQuantity = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();

            // 
            // dgvCartItems
            // 
            this.dgvCartItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartItems.Columns.Add("ProductID", "Product ID");
            this.dgvCartItems.Columns.Add("ProductName", "Product Name");
            this.dgvCartItems.Columns.Add("Quantity", "Quantity");
            this.dgvCartItems.Columns.Add("Price", "Price per Unit");
            this.dgvCartItems.Columns.Add("TotalPrice", "Total Price");
            this.dgvCartItems.Location = new System.Drawing.Point(12, 12);
            this.dgvCartItems.Name = "dgvCartItems";
            this.dgvCartItems.Size = new System.Drawing.Size(760, 300);
            this.dgvCartItems.TabIndex = 0;
            this.dgvCartItems.SelectionChanged += new System.EventHandler(this.dgvCartItems_SelectionChanged);

            // 
            // btnIncreaseQuantity
            // 
            this.btnIncreaseQuantity.Location = new System.Drawing.Point(250, 330);
            this.btnIncreaseQuantity.Name = "btnIncreaseQuantity";
            this.btnIncreaseQuantity.Size = new System.Drawing.Size(30, 30);
            this.btnIncreaseQuantity.TabIndex = 1;
            this.btnIncreaseQuantity.Text = "+";
            this.btnIncreaseQuantity.UseVisualStyleBackColor = true;
            this.btnIncreaseQuantity.Click += new System.EventHandler(this.btnIncreaseQuantity_Click);

            // 
            // btnDecreaseQuantity
            // 
            this.btnDecreaseQuantity.Location = new System.Drawing.Point(200, 330);
            this.btnDecreaseQuantity.Name = "btnDecreaseQuantity";
            this.btnDecreaseQuantity.Size = new System.Drawing.Size(30, 30);
            this.btnDecreaseQuantity.TabIndex = 2;
            this.btnDecreaseQuantity.Text = "-";
            this.btnDecreaseQuantity.UseVisualStyleBackColor = true;
            this.btnDecreaseQuantity.Click += new System.EventHandler(this.btnDecreaseQuantity_Click);

            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(290, 330);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(50, 23);
            this.txtQuantity.TabIndex = 3;
            this.txtQuantity.Text = "1";
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // btnCheckout
            // 
            this.btnCheckout.Location = new System.Drawing.Point(360, 330);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(75, 30);
            this.btnCheckout.TabIndex = 4;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(450, 330);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 30);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            // 
            // CartViewForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnDecreaseQuantity);
            this.Controls.Add(this.btnIncreaseQuantity);
            this.Controls.Add(this.dgvCartItems);
            this.Name = "CartViewForm";
            this.Text = "Cart";
            this.Load += new System.EventHandler(this.CartViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartItems)).EndInit();
        }
    }
}
