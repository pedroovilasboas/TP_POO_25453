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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            textBoxStock = new TextBox();
            buttonUpdate = new Button();
            SuspendLayout();
            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(30, 30);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.PlaceholderText = "New Stock Quantity";
            textBoxStock.Size = new Size(200, 27);
            textBoxStock.TabIndex = 0;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(30, 70);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 1;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // UpdateStockForm
            // 
            ClientSize = new Size(280, 150);
            Controls.Add(textBoxStock);
            Controls.Add(buttonUpdate);
            Name = "UpdateStockForm";
            Text = "Update Stock";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStock;
        private System.Windows.Forms.Button buttonUpdate;
    }
}
