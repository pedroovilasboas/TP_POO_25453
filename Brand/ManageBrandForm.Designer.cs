namespace POO_25453_TP
{
    partial class ManageBrandForm
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
            labelSearch = new Label();
            dataGridViewResults = new DataGridView();
            buttonGo = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(143, 51);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(296, 23);
            textBoxSearch.TabIndex = 13;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(81, 59);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(42, 15);
            labelSearch.TabIndex = 12;
            labelSearch.Text = "Search";
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Location = new Point(70, 90);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.Size = new Size(450, 150);
            dataGridViewResults.TabIndex = 11;
            // 
            // buttonGo
            // 
            buttonGo.Location = new Point(445, 50);
            buttonGo.Name = "buttonGo";
            buttonGo.Size = new Size(75, 23);
            buttonGo.TabIndex = 10;
            buttonGo.Text = "Go";
            buttonGo.UseVisualStyleBackColor = true;
            buttonGo.Click += buttonGo_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(70, 340);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(75, 23);
            buttonEdit.TabIndex = 9;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(150, 340);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 8;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(445, 340);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 7;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // ManageBrandForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 400);
            Controls.Add(buttonClose);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(buttonGo);
            Controls.Add(dataGridViewResults);
            Controls.Add(labelSearch);
            Controls.Add(textBoxSearch);
            Name = "ManageBrandForm";
            Text = "Manage Brands";
            Load += ManageBrandForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSearch;
        private Label labelSearch;
        private DataGridView dataGridViewResults;
        private Button buttonGo;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonClose;
    }
}
