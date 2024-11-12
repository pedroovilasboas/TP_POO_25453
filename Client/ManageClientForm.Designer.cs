namespace _25453_TP_POO
{
    partial class ManageClientForm
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
            buttonGo.Location = new Point(914, 40);
            buttonGo.Margin = new Padding(3, 4, 3, 4);
            buttonGo.Name = "buttonGo";
            buttonGo.Size = new Size(86, 31);
            buttonGo.TabIndex = 0;
            buttonGo.Text = "Go";
            buttonGo.UseVisualStyleBackColor = true;
            buttonGo.Click += buttonGo_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(34, 40);
            textBoxSearch.Margin = new Padding(3, 4, 3, 4);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(857, 27);
            textBoxSearch.TabIndex = 1;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.AllowUserToDeleteRows = false;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Location = new Point(34, 93);
            dataGridViewResults.Margin = new Padding(3, 4, 3, 4);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.RowHeadersWidth = 51;
            dataGridViewResults.RowTemplate.Height = 25;
            dataGridViewResults.Size = new Size(966, 507);
            dataGridViewResults.TabIndex = 2;
            dataGridViewResults.CellContentClick += dataGridViewResults_CellContentClick;
            dataGridViewResults.SelectionChanged += dataGridViewResults_SelectionChanged;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(34, 627);
            buttonEdit.Margin = new Padding(3, 4, 3, 4);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(86, 31);
            buttonEdit.TabIndex = 3;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(137, 627);
            buttonDelete.Margin = new Padding(3, 4, 3, 4);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(86, 31);
            buttonDelete.TabIndex = 4;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += Delete_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(914, 627);
            buttonClose.Margin = new Padding(3, 4, 3, 4);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(86, 31);
            buttonClose.TabIndex = 5;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += Close_Click;
            // 
            // ManageClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 720);
            Controls.Add(buttonClose);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(dataGridViewResults);
            Controls.Add(textBoxSearch);
            Controls.Add(buttonGo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ManageClientForm";
            Text = "Manage Clients";
            Load += ManageClientForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonClose;
    }
}
