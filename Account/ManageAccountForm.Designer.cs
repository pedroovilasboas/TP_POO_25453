namespace POO_25453_TP
{
    partial class ManageAccountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxSearch = new TextBox();
            buttonGo = new Button();
            Search = new Label();
            checkedListBoxResults = new CheckedListBox();
            buttonEdit = new Button();
            Close = new Button();
            Delete = new Button();
            SuspendLayout();
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(157, 32);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(395, 23);
            textBoxSearch.TabIndex = 7;
            // 
            // buttonGo
            // 
            buttonGo.Location = new Point(558, 31);
            buttonGo.Name = "buttonGo";
            buttonGo.Size = new Size(75, 23);
            buttonGo.TabIndex = 1;
            buttonGo.Text = "Go";
            buttonGo.UseVisualStyleBackColor = true;
            buttonGo.Click += buttonGo_Click;
            // 
            // Search
            // 
            Search.AutoSize = true;
            Search.Location = new Point(109, 40);
            Search.Name = "Search";
            Search.Size = new Size(42, 15);
            Search.TabIndex = 2;
            Search.Text = "Search";
            // 
            // checkedListBoxResults
            // 
            checkedListBoxResults.FormattingEnabled = true;
            checkedListBoxResults.Location = new Point(27, 125);
            checkedListBoxResults.Name = "checkedListBoxResults";
            checkedListBoxResults.Size = new Size(606, 148);
            checkedListBoxResults.TabIndex = 3;
            checkedListBoxResults.SelectedIndexChanged += checkedListBoxResults_SelectedIndexChanged;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(377, 332);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(111, 26);
            buttonEdit.TabIndex = 4;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // Close
            // 
            Close.Location = new Point(522, 332);
            Close.Name = "Close";
            Close.Size = new Size(111, 23);
            Close.TabIndex = 5;
            Close.Text = "Back";
            Close.UseVisualStyleBackColor = true;
            Close.Click += Close_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(238, 332);
            Delete.Name = "Delete";
            Delete.Size = new Size(111, 26);
            Delete.TabIndex = 6;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // ManageAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 388);
            Controls.Add(Delete);
            Controls.Add(Close);
            Controls.Add(buttonEdit);
            Controls.Add(checkedListBoxResults);
            Controls.Add(Search);
            Controls.Add(buttonGo);
            Controls.Add(textBoxSearch);
            Name = "ManageAccountForm";
            Text = "ManageAccountForm";
            Load += ManageAccountForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSearch;
        private Button buttonGo;
        private Label Search;
        private CheckedListBox checkedListBoxResults;
        private Button buttonEdit;
        private Button Close;
        private Button Delete;
    }
}