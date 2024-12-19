namespace POO_25453_TP
{
    partial class UpdateStockForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelCurrentStock = new System.Windows.Forms.Label();
            this.textBoxStock = new System.Windows.Forms.TextBox();
            this.labelAddStock = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // labelProductName
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(30, 30);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(90, 15);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "Product Name:";

            // labelCurrentStock
            this.labelCurrentStock.AutoSize = true;
            this.labelCurrentStock.Location = new System.Drawing.Point(30, 70);
            this.labelCurrentStock.Name = "labelCurrentStock";
            this.labelCurrentStock.Size = new System.Drawing.Size(85, 15);
            this.labelCurrentStock.TabIndex = 1;
            this.labelCurrentStock.Text = "Current Stock:";

            // textBoxStock
            this.textBoxStock.Location = new System.Drawing.Point(30, 140);
            this.textBoxStock.Name = "textBoxStock";
            this.textBoxStock.PlaceholderText = "Enter additional stock";
            this.textBoxStock.Size = new System.Drawing.Size(200, 23);
            this.textBoxStock.TabIndex = 2;

            // labelAddStock
            this.labelAddStock.AutoSize = true;
            this.labelAddStock.Location = new System.Drawing.Point(30, 120);
            this.labelAddStock.Name = "labelAddStock";
            this.labelAddStock.Size = new System.Drawing.Size(106, 15);
            this.labelAddStock.TabIndex = 3;
            this.labelAddStock.Text = "Additional Stock:";

            // buttonUpdate
            this.buttonUpdate.Location = new System.Drawing.Point(30, 190);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);

            // buttonClose
            this.buttonClose.Location = new System.Drawing.Point(155, 190);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;

            // UpdateStockForm
            this.ClientSize = new System.Drawing.Size(284, 251);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.labelAddStock);
            this.Controls.Add(this.textBoxStock);
            this.Controls.Add(this.labelCurrentStock);
            this.Controls.Add(this.labelProductName);
            this.Name = "UpdateStockForm";
            this.Text = "Update Stock";
            this.Load += new System.EventHandler(this.UpdateStockForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelCurrentStock;
        private System.Windows.Forms.TextBox textBoxStock;
        private System.Windows.Forms.Label labelAddStock;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonClose;
    }
}
