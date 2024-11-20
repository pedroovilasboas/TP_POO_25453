namespace POO_25453_TP
{
    partial class EditBrandForm
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
            textBoxName = new TextBox();
            labelEditName = new Label();
            textBoxDescription = new TextBox();
            labelEditDescription = new Label();
            SaveButton = new Button();
            buttonClose = new Button();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(70, 74);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(232, 23);
            textBoxName.TabIndex = 13;
            // 
            // labelEditName
            // 
            labelEditName.AutoSize = true;
            labelEditName.Location = new Point(72, 45);
            labelEditName.Name = "labelEditName";
            labelEditName.Size = new Size(62, 15);
            labelEditName.TabIndex = 12;
            labelEditName.Text = "Edit Name";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(70, 161);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(232, 23);
            textBoxDescription.TabIndex = 11;
            // 
            // labelEditDescription
            // 
            labelEditDescription.AutoSize = true;
            labelEditDescription.Location = new Point(70, 133);
            labelEditDescription.Name = "labelEditDescription";
            labelEditDescription.Size = new Size(90, 15);
            labelEditDescription.TabIndex = 9;
            labelEditDescription.Text = "Edit Description";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(131, 246);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 7;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(227, 246);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 14;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // EditBrandForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 304);
            Controls.Add(buttonClose);
            Controls.Add(textBoxName);
            Controls.Add(labelEditName);
            Controls.Add(textBoxDescription);
            Controls.Add(labelEditDescription);
            Controls.Add(SaveButton);
            Name = "EditBrandForm";
            Text = "EditBrandForm";
            Load += EditBrandForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private Label labelEditName;
        private TextBox textBoxDescription;
        private Label labelEditDescription;
        private Button SaveButton;
        private Button buttonClose;
    }
}
