using System;
using System.Drawing;
using System.Windows.Forms;

namespace POO_25453_TP
{
    partial class OrdersForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvOrders;
        private Button btnUpdateStatus;
        private ComboBox cmbStatus;
        private Label lblStatus;

        /// <summary>
        /// Inicializa os componentes do formulário.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvOrders = new DataGridView();
            this.btnUpdateStatus = new Button();
            this.cmbStatus = new ComboBox();
            this.lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new Point(14, 14);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new Size(1120, 462);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.SelectionChanged += new EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnUpdateStatus.Location = new Point(1017, 490);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new Size(117, 27);
            this.btnUpdateStatus.TabIndex = 1;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.Click += new EventHandler(this.btnUpdateStatus_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] { "Pending", "Shipped" });
            this.cmbStatus.Location = new Point(869, 492);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new Size(140, 23);
            this.cmbStatus.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new Point(816, 495);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(42, 15);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status:";
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1148, 532);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.dgvOrders);
            this.Name = "OrdersForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Orders Management";
            this.Load += new EventHandler(this.OrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
