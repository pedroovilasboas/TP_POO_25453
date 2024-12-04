namespace POO_25453_TP
{
    partial class ProductListForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnIncreaseQuantity;
        private System.Windows.Forms.Button btnDecreaseQuantity;

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
 

            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvProducts = new DataGridView();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            btnAddToCart = new Button();
            btnIncreaseQuantity = new Button();
            btnDecreaseQuantity = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();

            btnIncreaseQuantity.Click += new System.EventHandler(this.btnIncreaseQuantity_Click);
            btnDecreaseQuantity.Click += new System.EventHandler(this.btnDecreaseQuantity_Click);
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(800, 23);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(820, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(12, 50);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(1160, 400);
            dgvProducts.TabIndex = 3;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(12, 470);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(56, 15);
            lblQuantity.TabIndex = 4;
            lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(80, 467);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(50, 23);
            txtQuantity.TabIndex = 5;
            txtQuantity.Text = "1";
            // 
            // btnDecreaseQuantity
            // 
            btnDecreaseQuantity.Location = new Point(140, 467);
            btnDecreaseQuantity.Name = "btnDecreaseQuantity";
            btnDecreaseQuantity.Size = new Size(34, 23);
            btnDecreaseQuantity.TabIndex = 6;
            btnDecreaseQuantity.Text = "-";
            btnDecreaseQuantity.UseVisualStyleBackColor = true;
            // 
            // btnIncreaseQuantity
            // 
            btnIncreaseQuantity.Location = new Point(180, 467);
            btnIncreaseQuantity.Name = "btnIncreaseQuantity";
            btnIncreaseQuantity.Size = new Size(34, 23);
            btnIncreaseQuantity.TabIndex = 7;
            btnIncreaseQuantity.Text = "+";
            btnIncreaseQuantity.UseVisualStyleBackColor = true;
            // 
            // btnAddToCart
            // 
            btnAddToCart.Location = new Point(230, 465);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(100, 23);
            btnAddToCart.TabIndex = 8;
            btnAddToCart.Text = "Add to Cart";
            btnAddToCart.UseVisualStyleBackColor = true;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // ProductListForm
            // 
            ClientSize = new Size(1185, 525);
            Controls.Add(btnAddToCart);
            Controls.Add(btnIncreaseQuantity);
            Controls.Add(btnDecreaseQuantity);
            Controls.Add(txtQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(dgvProducts);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProductListForm";
            Text = "Product List";
            Load += ProductListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
