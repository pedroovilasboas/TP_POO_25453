namespace POO_25453_TP
{
    partial class AddProductForm
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
            comboBoxBrand = new ComboBox();
            textBoxName = new TextBox();
            textBoxDescription = new TextBox();
            textBoxType = new TextBox();
            textBoxPrice = new TextBox();
            textBoxStock = new TextBox();
            labelBrand = new Label();
            labelName = new Label();
            labelDescription = new Label();
            labelType = new Label();
            labelPrice = new Label();
            labelStock = new Label();
            buttonSave = new Button();
            SuspendLayout();
            // 
            // comboBoxBrand
            // 
            comboBoxBrand.FormattingEnabled = true;
            comboBoxBrand.Location = new Point(70, 50);
            comboBoxBrand.Name = "comboBoxBrand";
            comboBoxBrand.Size = new Size(232, 23);
            comboBoxBrand.TabIndex = 0;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(70, 100);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(232, 23);
            textBoxName.TabIndex = 1;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(70, 150);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(232, 23);
            textBoxDescription.TabIndex = 2;
            // 
            // textBoxType
            // 
            textBoxType.Location = new Point(70, 200);
            textBoxType.Name = "textBoxType";
            textBoxType.Size = new Size(232, 23);
            textBoxType.TabIndex = 3;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(70, 250);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(232, 23);
            textBoxPrice.TabIndex = 4;
            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(70, 300);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.Size = new Size(232, 23);
            textBoxStock.TabIndex = 5;
            // 
            // labelBrand
            // 
            labelBrand.AutoSize = true;
            labelBrand.Location = new Point(70, 30);
            labelBrand.Name = "labelBrand";
            labelBrand.Size = new Size(38, 15);
            labelBrand.TabIndex = 6;
            labelBrand.Text = "Brand";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(70, 80);
            labelName.Name = "labelName";
            labelName.Size = new Size(39, 15);
            labelName.TabIndex = 7;
            labelName.Text = "Name";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(70, 130);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(67, 15);
            labelDescription.TabIndex = 8;
            labelDescription.Text = "Description";
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(70, 180);
            labelType.Name = "labelType";
            labelType.Size = new Size(31, 15);
            labelType.TabIndex = 9;
            labelType.Text = "Type";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(70, 230);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(33, 15);
            labelPrice.TabIndex = 10;
            labelPrice.Text = "Price";
            // 
            // labelStock
            // 
            labelStock.AutoSize = true;
            labelStock.Location = new Point(70, 280);
            labelStock.Name = "labelStock";
            labelStock.Size = new Size(36, 15);
            labelStock.TabIndex = 11;
            labelStock.Text = "Stock";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(131, 350);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 12;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += AddButton_Click;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 451);
            Controls.Add(buttonSave);
            Controls.Add(labelStock);
            Controls.Add(labelPrice);
            Controls.Add(labelType);
            Controls.Add(labelDescription);
            Controls.Add(labelName);
            Controls.Add(labelBrand);
            Controls.Add(textBoxStock);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxType);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxName);
            Controls.Add(comboBoxBrand);
            Name = "AddProductForm";
            Text = "AddProductForm";
            Load += AddProductForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxBrand;
        private TextBox textBoxName;
        private TextBox textBoxDescription;
        private TextBox textBoxType;
        private TextBox textBoxPrice;
        private TextBox textBoxStock;
        private Label labelBrand;
        private Label labelName;
        private Label labelDescription;
        private Label labelType;
        private Label labelPrice;
        private Label labelStock;
        private Button buttonSave;
    }
}
