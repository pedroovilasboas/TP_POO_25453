namespace POO_25453_TP
{
    partial class ManageProductForm
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
            textBoxSearch = new TextBox();
            buttonSearch = new Button();
            dataGridViewResults = new DataGridView();
            buttonStock = new Button();
            buttonEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(30, 10);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Search Products";
            textBoxSearch.Size = new Size(600, 23);
            textBoxSearch.TabIndex = 0;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(636, 10);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(108, 35);
            buttonSearch.TabIndex = 1;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.AllowUserToDeleteRows = false;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Location = new Point(30, 54);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.RowHeadersWidth = 51;
            dataGridViewResults.Size = new Size(750, 350);
            dataGridViewResults.TabIndex = 2;
            // 
            // buttonStock
            // 
            buttonStock.Location = new Point(30, 420);
            buttonStock.Name = "buttonStock";
            buttonStock.Size = new Size(108, 35);
            buttonStock.TabIndex = 3;
            buttonStock.Text = "Stock";
            buttonStock.UseVisualStyleBackColor = true;
            buttonStock.Click += buttonStock_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(164, 420);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(108, 35);
            buttonEdit.TabIndex = 4;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click_1;
            // 
            // ManageProductForm
            // 
            ClientSize = new Size(820, 480);
            Controls.Add(textBoxSearch);
            Controls.Add(buttonSearch);
            Controls.Add(dataGridViewResults);
            Controls.Add(buttonStock);
            Controls.Add(buttonEdit);
            Name = "ManageProductForm";
            Text = "Manage Products";
            Load += ManageProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.Button buttonStock;
        private System.Windows.Forms.Button buttonEdit; // Declare buttonEdit
    }
}
