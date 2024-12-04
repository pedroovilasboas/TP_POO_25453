namespace POO_25453_TP
{
    partial class CartViewForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvCartItems;
        private System.Windows.Forms.Button btnIncreaseQuantity;
        private System.Windows.Forms.Button btnDecreaseQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnDelete;

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
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCartItems
            // 
            this.dgvCartItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartItems.Location = new System.Drawing.Point(12, 12);
            this.dgvCartItems.Name = "dgvCartItems";
            this.dgvCartItems.Size = new System.Drawing.Size(760, 300);
            this.dgvCartItems.TabIndex = 0;
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
            // lblQuantity
            // 
            this.lblQuantity.BackColor = System.Drawing.Color.Black;
            this.lblQuantity.ForeColor = System.Drawing.Color.White;
            this.lblQuantity.Location = new System.Drawing.Point(290, 330);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(50, 30);
            this.lblQuantity.TabIndex = 3;
            this.lblQuantity.Text = "0";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(450, 330);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // CartViewForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.btnDecreaseQuantity);
            this.Controls.Add(this.btnIncreaseQuantity);
            this.Controls.Add(this.dgvCartItems);
            this.Name = "CartViewForm";
            this.Text = "Cart";
            this.Load += new System.EventHandler(this.CartViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartItems)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
