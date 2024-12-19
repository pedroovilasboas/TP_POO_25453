namespace POO_25453_TP
{
    partial class AddBrandForm
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
            this.AddButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelBrandId = new System.Windows.Forms.Label();
            this.textBoxBrandId = new System.Windows.Forms.TextBox();
            this.textBoxBrandName = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(150, 200);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(100, 30);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Brand Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // labelBrandId
            // 
            this.labelBrandId.AutoSize = true;
            this.labelBrandId.Location = new System.Drawing.Point(50, 20);
            this.labelBrandId.Name = "labelBrandId";
            this.labelBrandId.Size = new System.Drawing.Size(50, 15);
            this.labelBrandId.TabIndex = 3;
            this.labelBrandId.Text = "Brand ID";
            // 
            // textBoxBrandId
            // 
            this.textBoxBrandId.Location = new System.Drawing.Point(150, 20);
            this.textBoxBrandId.Name = "textBoxBrandId";
            this.textBoxBrandId.ReadOnly = true;
            this.textBoxBrandId.Size = new System.Drawing.Size(200, 23);
            this.textBoxBrandId.TabIndex = 4;
            // 
            // textBoxBrandName
            // 
            this.textBoxBrandName.Location = new System.Drawing.Point(150, 70);
            this.textBoxBrandName.Name = "textBoxBrandName";
            this.textBoxBrandName.Size = new System.Drawing.Size(200, 23);
            this.textBoxBrandName.TabIndex = 5;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(150, 120);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(200, 60);
            this.textBoxDescription.TabIndex = 6;
            // 
            // AddBrandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 260);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxBrandName);
            this.Controls.Add(this.textBoxBrandId);
            this.Controls.Add(this.labelBrandId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddButton);
            this.Name = "AddBrandForm";
            this.Text = "Add Brand";
            this.Load += new System.EventHandler(this.AddBrandForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelBrandId;
        private System.Windows.Forms.TextBox textBoxBrandId;
        private System.Windows.Forms.TextBox textBoxBrandName;
        private System.Windows.Forms.TextBox textBoxDescription;
    }
}
