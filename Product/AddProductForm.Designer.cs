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
            textBoxName = new TextBox();
            textBoxDescription = new TextBox();
            textBoxType = new TextBox();
            textBoxPrice = new TextBox();
            textBoxStock = new TextBox();
            comboBoxBrand = new ComboBox();
            comboBoxCategory = new ComboBox();
            buttonSave = new Button();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(30, 30);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Product Name";
            textBoxName.Size = new Size(300, 27);
            textBoxName.TabIndex = 0;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(30, 70);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.PlaceholderText = "Description";
            textBoxDescription.Size = new Size(300, 27);
            textBoxDescription.TabIndex = 1;
            // 
            // textBoxType
            // 
            textBoxType.Location = new Point(30, 110);
            textBoxType.Name = "textBoxType";
            textBoxType.PlaceholderText = "Type";
            textBoxType.Size = new Size(300, 27);
            textBoxType.TabIndex = 2;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(30, 150);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.PlaceholderText = "Price";
            textBoxPrice.Size = new Size(300, 27);
            textBoxPrice.TabIndex = 3;
            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(30, 190);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.PlaceholderText = "Stock Quantity";
            textBoxStock.Size = new Size(300, 27);
            textBoxStock.TabIndex = 4;
            // 
            // comboBoxBrand
            // 
            comboBoxBrand.Location = new Point(30, 230);
            comboBoxBrand.Name = "comboBoxBrand";
            comboBoxBrand.Size = new Size(300, 28);
            comboBoxBrand.TabIndex = 5;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.Location = new Point(30, 270);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(300, 28);
            comboBoxCategory.TabIndex = 6;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(30, 320);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(80, 28);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // AddProductForm
            // 
            ClientSize = new Size(400, 400);
            Controls.Add(textBoxName);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxType);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxStock);
            Controls.Add(comboBoxBrand);
            Controls.Add(comboBoxCategory);
            Controls.Add(buttonSave);
            Name = "AddProductForm";
            Text = "Add Product";
            Load += AddProductForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxStock;
        private System.Windows.Forms.ComboBox comboBoxBrand;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Button buttonSave;
    }
}
