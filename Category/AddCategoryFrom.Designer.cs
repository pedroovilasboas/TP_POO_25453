namespace _25453_TP_POO
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

        // Initialize the form components
        private void InitializeComponent()
        {
            this.AddButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCategoryId = new System.Windows.Forms.TextBox();
            this.textBoxCategoryName = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // 
            // AddButton
            // 
            // Button to add the category
            this.AddButton.Location = new System.Drawing.Point(159, 200);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);

            // 
            // label1
            // 
            // Label for Category ID
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Category ID";

            // 
            // label2
            // 
            // Label for Category Name
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Category Name";

            // 
            // label3
            // 
            // Label for Description
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Description";

            // 
            // textBoxCategoryId
            // 
            // TextBox for entering the Category ID
            this.textBoxCategoryId.Location = new System.Drawing.Point(80, 50);
            this.textBoxCategoryId.Name = "textBoxCategoryId";
            this.textBoxCategoryId.Size = new System.Drawing.Size(232, 23);
            this.textBoxCategoryId.TabIndex = 4;

            // 
            // textBoxCategoryName
            // 
            // TextBox for entering the Category Name
            this.textBoxCategoryName.Location = new System.Drawing.Point(80, 100);
            this.textBoxCategoryName.Name = "textBoxCategoryName";
            this.textBoxCategoryName.Size = new System.Drawing.Size(232, 23);
            this.textBoxCategoryName.TabIndex = 5;

            // 
            // textBoxDescription
            // 
            // TextBox for entering the Category Description
            this.textBoxDescription.Location = new System.Drawing.Point(80, 150);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(232, 23);
            this.textBoxDescription.TabIndex = 6;

            // 
            // AddCategoryForm
            // 
            // Form settings
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 250);
            this.Controls.Add(this.textBoxCategoryId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCategoryName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AddButton);
            this.Name = "AddCategoryForm";
            this.Text = "Add Category";
            this.Load += new System.EventHandler(this.AddCategoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Form components
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCategoryId;
        private System.Windows.Forms.TextBox textBoxCategoryName;
        private System.Windows.Forms.TextBox textBoxDescription;
    }
}
