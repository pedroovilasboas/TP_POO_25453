namespace POO_25453_TP
{
    partial class ManageCategoryForm
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
            buttonGo = new Button();
            textBoxSearch = new TextBox();
            dataGridViewResults = new DataGridView();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // buttonGo
            // 
            buttonGo.Location = new Point(800, 30);
            buttonGo.Name = "buttonGo";
            buttonGo.Size = new Size(75, 23);
            buttonGo.TabIndex = 0;
            buttonGo.Text = "Search";
            buttonGo.UseVisualStyleBackColor = true;
            buttonGo.Click += buttonGo_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(30, 30);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(750, 23);
            textBoxSearch.TabIndex = 1;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.AllowUserToDeleteRows = false;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Location = new Point(30, 70);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.RowHeadersWidth = 51;
            dataGridViewResults.Size = new Size(845, 380);
            dataGridViewResults.TabIndex = 2;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(30, 470);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(75, 23);
            buttonEdit.TabIndex = 3;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(120, 470);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 4;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(800, 470);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 5;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // ManageCategoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 540);
            Controls.Add(buttonClose);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(dataGridViewResults);
            Controls.Add(textBoxSearch);
            Controls.Add(buttonGo);
            Name = "ManageCategoryForm";
            Text = "Manage Categories";
            Load += ManageCategoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonGo;
        private TextBox textBoxSearch;
        private DataGridView dataGridViewResults;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonClose;
    }
}
