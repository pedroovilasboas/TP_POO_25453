namespace POO_25453_TP
{
    partial class AddCategoryForm
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
            AddButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxCategoryId = new TextBox();
            textBoxCategoryName = new TextBox();
            textBoxDescription = new TextBox();
            SuspendLayout();
            // 
            // AddButton
            // 
            AddButton.Location = new Point(150, 180);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 1;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 2;
            label1.Text = "Category ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 60);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 3;
            label2.Text = "Category Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 100);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 5;
            label3.Text = "Description";
            // 
            // textBoxCategoryId
            // 
            textBoxCategoryId.Location = new Point(150, 20);
            textBoxCategoryId.Name = "textBoxCategoryId";
            textBoxCategoryId.ReadOnly = true;
            textBoxCategoryId.Size = new Size(200, 23);
            textBoxCategoryId.TabIndex = 0;
            // 
            // textBoxCategoryName
            // 
            textBoxCategoryName.Location = new Point(150, 60);
            textBoxCategoryName.Name = "textBoxCategoryName";
            textBoxCategoryName.Size = new Size(200, 23);
            textBoxCategoryName.TabIndex = 4;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(150, 100);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(200, 60);
            textBoxDescription.TabIndex = 6;
            // 
            // AddCategoryForm
            // 
            ClientSize = new Size(400, 250);
            Controls.Add(AddButton);
            Controls.Add(label1);
            Controls.Add(textBoxCategoryId);
            Controls.Add(label2);
            Controls.Add(textBoxCategoryName);
            Controls.Add(label3);
            Controls.Add(textBoxDescription);
            Name = "AddCategoryForm";
            Text = "Add Category";
            Load += AddCategoryForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCategoryId;
        private System.Windows.Forms.TextBox textBoxCategoryName;
        private System.Windows.Forms.TextBox textBoxDescription;
    }
}
