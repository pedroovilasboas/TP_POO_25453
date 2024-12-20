using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    partial class MyOrdersForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvMyOrders;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonClose;

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
            this.dgvMyOrders = new System.Windows.Forms.DataGridView();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(12, 12);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PlaceholderText = "Search orders...";
            this.textBoxSearch.Size = new System.Drawing.Size(200, 20);
            this.textBoxSearch.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(218, 12);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(299, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // dgvMyOrders
            // 
            this.dgvMyOrders.AllowUserToAddRows = false;
            this.dgvMyOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyOrders.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvMyOrders.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvMyOrders.Location = new System.Drawing.Point(12, 41);
            this.dgvMyOrders.Name = "dgvMyOrders";
            this.dgvMyOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyOrders.MultiSelect = false;
            this.dgvMyOrders.ReadOnly = true;
            this.dgvMyOrders.AllowUserToDeleteRows = false;
            this.dgvMyOrders.AllowUserToOrderColumns = true;
            this.dgvMyOrders.Size = new System.Drawing.Size(776, 397);
            this.dgvMyOrders.TabIndex = 3;
            // 
            // MyOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMyOrders);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonClose);
            this.Name = "MyOrdersForm";
            this.Text = "My Orders";
            this.Load += new System.EventHandler(this.MyOrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
