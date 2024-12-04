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
            txtSearch = new System.Windows.Forms.TextBox();
            btnSearch = new System.Windows.Forms.Button();
            dgvProducts = new System.Windows.Forms.DataGridView();
            lblQuantity = new System.Windows.Forms.Label();
            txtQuantity = new System.Windows.Forms.TextBox();
            btnAddToCart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(dgvProducts)).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new System.Drawing.Point(12, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(800, 23);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new System.Drawing.Point(820, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(100, 23);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new System.Drawing.Point(12, 50);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.Size = new System.Drawing.Size(1150, 400);
            dgvProducts.TabIndex = 2;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new System.Drawing.Point(12, 470);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new System.Drawing.Size(58, 15);
            lblQuantity.TabIndex = 3;
            lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new System.Drawing.Point(80, 467);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new System.Drawing.Size(100, 23);
            txtQuantity.TabIndex = 4;
            txtQuantity.Text = "1";
            // 
            // btnAddToCart
            // 
            btnAddToCart.Location = new System.Drawing.Point(200, 467);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new System.Drawing.Size(150, 23);
            btnAddToCart.TabIndex = 5;
            btnAddToCart.Text = "Add to Cart";
            btnAddToCart.UseVisualStyleBackColor = true;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // ProductListForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1185, 525);
            Controls.Add(btnAddToCart);
            Controls.Add(txtQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(dgvProducts);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // Remove as bordas e botões
            ControlBox = false; // Remove os botões de controle
            MaximizeBox = false; // Remove o botão de maximizar
            MinimizeBox = false; // Remove o botão de minimizar
            Name = "ProductListForm";
            Text = "Product List";
            Load += ProductListForm_Load;
            ((System.ComponentModel.ISupportInitialize)(dgvProducts)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
