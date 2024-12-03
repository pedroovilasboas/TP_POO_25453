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
            labelID = new Label();
            textBoxID = new TextBox();
            labelName = new Label();
            textBoxName = new TextBox();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            labelType = new Label();
            textBoxType = new TextBox();
            labelPrice = new Label();
            textBoxPrice = new TextBox();
            labelStock = new Label();
            textBoxStock = new TextBox();
            labelBrand = new Label();
            comboBoxBrand = new ComboBox();
            labelCategory = new Label();
            comboBoxCategory = new ComboBox();
            buttonSave = new Button();
            SuspendLayout();

            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Location = new Point(30, 20);
            labelID.Name = "labelID";
            labelID.Size = new Size(92, 15);
            labelID.Text = "Next Product ID:";

            // 
            // textBoxID
            // 
            textBoxID.Location = new Point(150, 15);
            textBoxID.Name = "textBoxID";
            textBoxID.ReadOnly = true;
            textBoxID.Size = new Size(180, 23);
            textBoxID.TabIndex = 0;
            textBoxID.BackColor = SystemColors.ControlLight;

            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(30, 60);
            labelName.Name = "labelName";
            labelName.Size = new Size(82, 15);
            labelName.Text = "Product Name:";

            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(150, 55);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(180, 23);
            textBoxName.TabIndex = 1;

            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(30, 100);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(72, 15);
            labelDescription.Text = "Description:";

            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(150, 95);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.ScrollBars = ScrollBars.Vertical;
            textBoxDescription.Size = new Size(180, 100);
            textBoxDescription.TabIndex = 2;

            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(30, 210);
            labelType.Name = "labelType";
            labelType.Size = new Size(36, 15);
            labelType.Text = "Type:";

            // 
            // textBoxType
            // 
            textBoxType.Location = new Point(150, 205);
            textBoxType.Name = "textBoxType";
            textBoxType.Size = new Size(180, 23);
            textBoxType.TabIndex = 3;

            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(30, 250);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(36, 15);
            labelPrice.Text = "Price:";

            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(150, 245);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(180, 23);
            textBoxPrice.TabIndex = 4;

            // 
            // labelStock
            // 
            labelStock.AutoSize = true;
            labelStock.Location = new Point(30, 290);
            labelStock.Name = "labelStock";
            labelStock.Size = new Size(82, 15);
            labelStock.Text = "Stock Quantity:";

            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(150, 285);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.Size = new Size(180, 23);
            textBoxStock.TabIndex = 5;

            // 
            // labelBrand
            // 
            labelBrand.AutoSize = true;
            labelBrand.Location = new Point(30, 330);
            labelBrand.Name = "labelBrand";
            labelBrand.Size = new Size(40, 15);
            labelBrand.Text = "Brand:";

            // 
            // comboBoxBrand
            // 
            comboBoxBrand.Location = new Point(150, 325);
            comboBoxBrand.Name = "comboBoxBrand";
            comboBoxBrand.Size = new Size(180, 23);
            comboBoxBrand.TabIndex = 6;

            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new Point(30, 370);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(61, 15);
            labelCategory.Text = "Category:";

            // 
            // comboBoxCategory
            // 
            comboBoxCategory.Location = new Point(150, 365);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(180, 23);
            comboBoxCategory.TabIndex = 7;

            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(150, 410);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(80, 28);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;

            // 
            // AddProductForm
            // 
            ClientSize = new Size(400, 470);
            Controls.Add(labelID);
            Controls.Add(textBoxID);
            Controls.Add(labelName);
            Controls.Add(textBoxName);
            Controls.Add(labelDescription);
            Controls.Add(textBoxDescription);
            Controls.Add(labelType);
            Controls.Add(textBoxType);
            Controls.Add(labelPrice);
            Controls.Add(textBoxPrice);
            Controls.Add(labelStock);
            Controls.Add(textBoxStock);
            Controls.Add(labelBrand);
            Controls.Add(comboBoxBrand);
            Controls.Add(labelCategory);
            Controls.Add(comboBoxCategory);
            Controls.Add(buttonSave);
            Name = "AddProductForm";
            Text = "Add Product";
            Load += AddProductForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelID;
        private TextBox textBoxID;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelDescription;
        private TextBox textBoxDescription;
        private Label labelType;
        private TextBox textBoxType;
        private Label labelPrice;
        private TextBox textBoxPrice;
        private Label labelStock;
        private TextBox textBoxStock;
        private Label labelBrand;
        private ComboBox comboBoxBrand;
        private Label labelCategory;
        private ComboBox comboBoxCategory;
        private Button buttonSave;
    }
}
