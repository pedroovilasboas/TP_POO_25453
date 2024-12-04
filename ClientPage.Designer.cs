namespace POO_25453_TP
{
    partial class ClientPage
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem accountToolStripMenuItem;
        private ToolStripMenuItem editAccountToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem productsToolStripMenuItem;
        private ToolStripMenuItem myCartToolStripMenuItem;

        // Clean up resources
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
            menuStrip1 = new MenuStrip();
            accountToolStripMenuItem = new ToolStripMenuItem();
            editAccountToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            productsToolStripMenuItem = new ToolStripMenuItem();
            myCartToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            myOrdersToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { accountToolStripMenuItem, productsToolStripMenuItem, myCartToolStripMenuItem, myOrdersToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1206, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // accountToolStripMenuItem
            // 
            accountToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editAccountToolStripMenuItem, logoutToolStripMenuItem });
            accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            accountToolStripMenuItem.Size = new Size(64, 20);
            accountToolStripMenuItem.Text = "Account";
            // 
            // editAccountToolStripMenuItem
            // 
            editAccountToolStripMenuItem.Name = "editAccountToolStripMenuItem";
            editAccountToolStripMenuItem.Size = new Size(142, 22);
            editAccountToolStripMenuItem.Text = "Edit Account";
            editAccountToolStripMenuItem.Click += editAccountToolStripMenuItem_Click;
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(142, 22);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // productsToolStripMenuItem
            // 
            productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            productsToolStripMenuItem.Size = new Size(66, 20);
            productsToolStripMenuItem.Text = "Products";
            productsToolStripMenuItem.Click += productsToolStripMenuItem_Click;
            // 
            // myCartToolStripMenuItem
            // 
            myCartToolStripMenuItem.Name = "myCartToolStripMenuItem";
            myCartToolStripMenuItem.Size = new Size(61, 20);
            myCartToolStripMenuItem.Text = "My Cart";
            myCartToolStripMenuItem.Click += myCartToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(9, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(1185, 525);
            panel1.TabIndex = 1;
            // 
            // myOrdersToolStripMenuItem
            // 
            myOrdersToolStripMenuItem.Name = "myOrdersToolStripMenuItem";
            myOrdersToolStripMenuItem.Size = new Size(72, 20);
            myOrdersToolStripMenuItem.Text = "My orders";
            myOrdersToolStripMenuItem.Click += myOrdersToolStripMenuItem_Click;
            // 
            // ClientPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1206, 572);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ClientPage";
            Text = "Client Page";
            Load += ClientPage_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel panel1;
        private ToolStripMenuItem myOrdersToolStripMenuItem;
    }
}
