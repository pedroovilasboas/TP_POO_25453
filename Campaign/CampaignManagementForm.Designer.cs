namespace POO_25453_TP
{
    partial class CampaignManagementForm
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
            dgvCampaigns = new DataGridView();
            groupBox1 = new GroupBox();
            cboTarget = new ComboBox();
            label7 = new Label();
            cboDiscountType = new ComboBox();
            label6 = new Label();
            numDiscount = new NumericUpDown();
            label5 = new Label();
            numDuration = new NumericUpDown();
            label4 = new Label();
            dtpStartDate = new DateTimePicker();
            label3 = new Label();
            txtDescription = new TextBox();
            label2 = new Label();
            txtName = new TextBox();
            label1 = new Label();
            btnClose = new Button();
            btnDeleteCampaign = new Button();
            btnAddCampaign = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCampaigns).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            SuspendLayout();
            // 
            // dgvCampaigns
            // 
            dgvCampaigns.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCampaigns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCampaigns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCampaigns.Location = new Point(13, 12);
            dgvCampaigns.Margin = new Padding(4, 3, 4, 3);
            dgvCampaigns.MultiSelect = false;
            dgvCampaigns.Name = "dgvCampaigns";
            dgvCampaigns.ReadOnly = true;
            dgvCampaigns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCampaigns.Size = new Size(1004, 235);
            dgvCampaigns.TabIndex = 12;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(cboTarget);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cboDiscountType);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(numDiscount);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(numDuration);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dtpStartDate);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(14, 269);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(1004, 173);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Campaign Details";
            // 
            // cboTarget
            // 
            cboTarget.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTarget.Location = new Point(467, 85);
            cboTarget.Margin = new Padding(4, 3, 4, 3);
            cboTarget.Name = "cboTarget";
            cboTarget.Size = new Size(174, 23);
            cboTarget.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(350, 89);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 1;
            label7.Text = "Target:";
            // 
            // cboDiscountType
            // 
            cboDiscountType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDiscountType.Location = new Point(467, 55);
            cboDiscountType.Margin = new Padding(4, 3, 4, 3);
            cboDiscountType.Name = "cboDiscountType";
            cboDiscountType.Size = new Size(176, 23);
            cboDiscountType.TabIndex = 7;
            cboDiscountType.SelectedIndexChanged += cboDiscountType_SelectedIndexChanged_1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(350, 59);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 8;
            label6.Text = "Discount Type:";
            // 
            // numDiscount
            // 
            numDiscount.Location = new Point(467, 25);
            numDiscount.Margin = new Padding(4, 3, 4, 3);
            numDiscount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(82, 23);
            numDiscount.TabIndex = 9;
            numDiscount.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(350, 29);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 10;
            label5.Text = "Discount:";
            // 
            // numDuration
            // 
            numDuration.Location = new Point(140, 115);
            numDuration.Margin = new Padding(4, 3, 4, 3);
            numDuration.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            numDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(82, 23);
            numDuration.TabIndex = 11;
            numDuration.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 119);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 12;
            label4.Text = "Duration (Days):";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(140, 85);
            dtpStartDate.Margin = new Padding(4, 3, 4, 3);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(174, 23);
            dtpStartDate.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 89);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 14;
            label3.Text = "Start Date:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(140, 55);
            txtDescription.Margin = new Padding(4, 3, 4, 3);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(174, 23);
            txtDescription.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 59);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 16;
            label2.Text = "Description:";
            // 
            // txtName
            // 
            txtName.Location = new Point(140, 25);
            txtName.Margin = new Padding(4, 3, 4, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(174, 23);
            txtName.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 29);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 18;
            label1.Text = "Name:";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(909, 463);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(97, 29);
            btnClose.TabIndex = 10;
            btnClose.Text = "Close";
            btnClose.Click += btnClose_Click;
            // 
            // btnDeleteCampaign
            // 
            btnDeleteCampaign.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDeleteCampaign.Location = new Point(797, 463);
            btnDeleteCampaign.Margin = new Padding(4, 3, 4, 3);
            btnDeleteCampaign.Name = "btnDeleteCampaign";
            btnDeleteCampaign.Size = new Size(105, 29);
            btnDeleteCampaign.TabIndex = 9;
            btnDeleteCampaign.Text = "Delete";
            btnDeleteCampaign.Click += btnDeleteCampaign_Click;
            // 
            // btnAddCampaign
            // 
            btnAddCampaign.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddCampaign.Location = new Point(685, 463);
            btnAddCampaign.Margin = new Padding(4, 3, 4, 3);
            btnAddCampaign.Name = "btnAddCampaign";
            btnAddCampaign.Size = new Size(105, 29);
            btnAddCampaign.TabIndex = 8;
            btnAddCampaign.Text = "Add Campaign";
            btnAddCampaign.Click += btnAddCampaign_Click;
            // 
            // CampaignManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 590);
            Controls.Add(btnClose);
            Controls.Add(btnDeleteCampaign);
            Controls.Add(btnAddCampaign);
            Controls.Add(groupBox1);
            Controls.Add(dgvCampaigns);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(1047, 629);
            Name = "CampaignManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Campaign Management";
            Load += CampaignManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCampaigns).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvCampaigns;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboDiscountType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTarget;
        private System.Windows.Forms.Button btnAddCampaign;
        private System.Windows.Forms.Button btnDeleteCampaign;
        private System.Windows.Forms.Button btnClose;
    }
}
