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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

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
            dgvCartItems = new System.Windows.Forms.DataGridView();
            dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            btnIncreaseQuantity = new System.Windows.Forms.Button();
            btnDecreaseQuantity = new System.Windows.Forms.Button();
            txtQuantity = new System.Windows.Forms.TextBox();
            btnCheckout = new System.Windows.Forms.Button();
            btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(dgvCartItems)).BeginInit();
            SuspendLayout();
            
            // dgvCartItems
            dgvCartItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCartItems.Location = new System.Drawing.Point(12, 12);
            dgvCartItems.Name = "dgvCartItems";
            dgvCartItems.Size = new System.Drawing.Size(760, 300);
            dgvCartItems.TabIndex = 0;
            dgvCartItems.SelectionChanged += new System.EventHandler(dgvCartItems_SelectionChanged);
            
            // btnIncreaseQuantity
            btnIncreaseQuantity.Location = new System.Drawing.Point(12, 318);
            btnIncreaseQuantity.Name = "btnIncreaseQuantity";
            btnIncreaseQuantity.Size = new System.Drawing.Size(75, 23);
            btnIncreaseQuantity.TabIndex = 1;
            btnIncreaseQuantity.Text = "+";
            btnIncreaseQuantity.Click += new System.EventHandler(btnIncreaseQuantity_Click);
            
            // btnDecreaseQuantity
            btnDecreaseQuantity.Location = new System.Drawing.Point(93, 318);
            btnDecreaseQuantity.Name = "btnDecreaseQuantity";
            btnDecreaseQuantity.Size = new System.Drawing.Size(75, 23);
            btnDecreaseQuantity.TabIndex = 2;
            btnDecreaseQuantity.Text = "-";
            btnDecreaseQuantity.Click += new System.EventHandler(btnDecreaseQuantity_Click);
            
            // txtQuantity
            txtQuantity.Location = new System.Drawing.Point(174, 320);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new System.Drawing.Size(100, 20);
            txtQuantity.TabIndex = 3;
            txtQuantity.TextChanged += new System.EventHandler(txtQuantity_TextChanged);
            
            // btnCheckout
            btnCheckout.Location = new System.Drawing.Point(697, 318);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new System.Drawing.Size(75, 23);
            btnCheckout.TabIndex = 4;
            btnCheckout.Text = "Checkout";
            btnCheckout.Click += new System.EventHandler(btnCheckout_Click);
            
            // btnRemove
            btnRemove.Location = new System.Drawing.Point(616, 318);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(75, 23);
            btnRemove.TabIndex = 5;
            btnRemove.Text = "Remove";
            btnRemove.Click += new System.EventHandler(btnRemove_Click);
            
            // CartViewForm
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 361);
            Controls.Add(btnRemove);
            Controls.Add(btnCheckout);
            Controls.Add(txtQuantity);
            Controls.Add(btnDecreaseQuantity);
            Controls.Add(btnIncreaseQuantity);
            Controls.Add(dgvCartItems);
            Name = "CartViewForm";
            Text = "Shopping Cart";
            Load += new System.EventHandler(CartViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(dgvCartItems)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
