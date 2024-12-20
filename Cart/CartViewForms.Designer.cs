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
            dgvCartItems = new DataGridView();
            btnIncreaseQuantity = new Button();
            btnDecreaseQuantity = new Button();
            txtQuantity = new TextBox();
            btnCheckout = new Button();
            btnRemove = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvCartItems).BeginInit();
            SuspendLayout();
            // 
            // dgvCartItems
            // 
            dgvCartItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCartItems.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvCartItems.Location = new Point(12, 12);
            dgvCartItems.Name = "dgvCartItems";
            dgvCartItems.Size = new Size(760, 300);
            dgvCartItems.TabIndex = 0;
            dgvCartItems.CellContentClick += dgvCartItems_CellContentClick;
            dgvCartItems.SelectionChanged += dgvCartItems_SelectionChanged;
            // 
            // btnIncreaseQuantity
            // 
            btnIncreaseQuantity.Location = new Point(250, 330);
            btnIncreaseQuantity.Name = "btnIncreaseQuantity";
            btnIncreaseQuantity.Size = new Size(30, 30);
            btnIncreaseQuantity.TabIndex = 1;
            btnIncreaseQuantity.Text = "+";
            btnIncreaseQuantity.UseVisualStyleBackColor = true;
            btnIncreaseQuantity.Click += btnIncreaseQuantity_Click;
            // 
            // btnDecreaseQuantity
            // 
            btnDecreaseQuantity.Location = new Point(200, 330);
            btnDecreaseQuantity.Name = "btnDecreaseQuantity";
            btnDecreaseQuantity.Size = new Size(30, 30);
            btnDecreaseQuantity.TabIndex = 2;
            btnDecreaseQuantity.Text = "-";
            btnDecreaseQuantity.UseVisualStyleBackColor = true;
            btnDecreaseQuantity.Click += btnDecreaseQuantity_Click;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(290, 330);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(50, 23);
            txtQuantity.TabIndex = 3;
            txtQuantity.Text = "1";
            txtQuantity.TextAlign = HorizontalAlignment.Center;
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(360, 330);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(75, 30);
            btnCheckout.TabIndex = 4;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(450, 330);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 30);
            btnRemove.TabIndex = 5;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Product ID";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Product Name";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Quantity";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Price per Unit";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Total Price";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // CartViewForm
            // 
            ClientSize = new Size(800, 400);
            Controls.Add(btnRemove);
            Controls.Add(btnCheckout);
            Controls.Add(txtQuantity);
            Controls.Add(btnDecreaseQuantity);
            Controls.Add(btnIncreaseQuantity);
            Controls.Add(dgvCartItems);
            Name = "CartViewForm";
            Text = "Cart";
            Load += CartViewForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCartItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}
