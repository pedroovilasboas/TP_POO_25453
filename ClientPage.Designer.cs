namespace POO_25453_TP
{
    partial class ClientPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            myAccountToolStripMenuItem = new ToolStripMenuItem();
            editAccountToolStripMenuItem = new ToolStripMenuItem();
            myOrderToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            productsToolStripMenuItem = new ToolStripMenuItem();
            campaignToolStripMenuItem = new ToolStripMenuItem();
            myCartToolStripMenuItem = new ToolStripMenuItem();
            panel2 = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { myAccountToolStripMenuItem, productsToolStripMenuItem, campaignToolStripMenuItem, myCartToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1206, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // myAccountToolStripMenuItem
            // 
            myAccountToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editAccountToolStripMenuItem, myOrderToolStripMenuItem, logoutToolStripMenuItem });
            myAccountToolStripMenuItem.Name = "myAccountToolStripMenuItem";
            myAccountToolStripMenuItem.Size = new Size(84, 20);
            myAccountToolStripMenuItem.Text = "My Account";
            // 
            // editAccountToolStripMenuItem
            // 
            editAccountToolStripMenuItem.Name = "editAccountToolStripMenuItem";
            editAccountToolStripMenuItem.Size = new Size(142, 22);
            editAccountToolStripMenuItem.Text = "Edit Account";
            editAccountToolStripMenuItem.Click += editAccountToolStripMenuItem_Click;
            // 
            // myOrderToolStripMenuItem
            // 
            myOrderToolStripMenuItem.Name = "myOrderToolStripMenuItem";
            myOrderToolStripMenuItem.Size = new Size(142, 22);
            myOrderToolStripMenuItem.Text = "My orders";
            myOrderToolStripMenuItem.Click += myOrderToolStripMenuItem_Click;
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
            // campaignToolStripMenuItem
            // 
            campaignToolStripMenuItem.Name = "campaignToolStripMenuItem";
            campaignToolStripMenuItem.Size = new Size(74, 20);
            campaignToolStripMenuItem.Text = "Campaign";
            // 
            // myCartToolStripMenuItem
            // 
            myCartToolStripMenuItem.Name = "myCartToolStripMenuItem";
            myCartToolStripMenuItem.Size = new Size(61, 20);
            myCartToolStripMenuItem.Text = "My Cart";
            // 
            // panel2
            // 
            panel2.Location = new Point(12, 27);
            panel2.Name = "panel2";
            panel2.Size = new Size(1185, 525);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // ClientPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1206, 572);
            Controls.Add(panel2);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ClientPage";
            Text = "ClientPage";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem myAccountToolStripMenuItem;
        private ToolStripMenuItem editAccountToolStripMenuItem;
        private ToolStripMenuItem myOrderToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem productsToolStripMenuItem;
        private ToolStripMenuItem campaignToolStripMenuItem;
        private ToolStripMenuItem myCartToolStripMenuItem;
        private Panel panel2;
    }
}