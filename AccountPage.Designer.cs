            namespace POO_25453_TP
{
    partial class AccountPage
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
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextMenuStrip2 = new ContextMenuStrip(components);
            contextMenuStrip3 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            accountToolStripMenuItem = new ToolStripMenuItem();
            addAccountToolStripMenuItem = new ToolStripMenuItem();
            manageAccountToolStripMenuItem = new ToolStripMenuItem();
            clientToolStripMenuItem = new ToolStripMenuItem();
            addClientToolStripMenuItem = new ToolStripMenuItem();
            manageClientToolStripMenuItem = new ToolStripMenuItem();
            productToolStripMenuItem = new ToolStripMenuItem();
            addBrandToolStripMenuItem = new ToolStripMenuItem();
            manageBandToolStripMenuItem = new ToolStripMenuItem();
            productToolStripMenuItem1 = new ToolStripMenuItem();
            addProductToolStripMenuItem = new ToolStripMenuItem();
            manageProductToolStripMenuItem = new ToolStripMenuItem();
            categoryToolStripMenuItem = new ToolStripMenuItem();
            addCategoryToolStripMenuItem = new ToolStripMenuItem();
            manageCategoryToolStripMenuItem = new ToolStripMenuItem();
            ordersToolStripMenuItem = new ToolStripMenuItem();
            warrantyToolStripMenuItem = new ToolStripMenuItem();
            campaignToolStripMenuItem = new ToolStripMenuItem();
            manageCampaignsToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();

            menuStrip1.SuspendLayout();
            SuspendLayout();

            // Context Menu Strips
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);

            contextMenuStrip2.ImageScalingSize = new Size(20, 20);
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);

            contextMenuStrip3.ImageScalingSize = new Size(20, 20);
            contextMenuStrip3.Name = "contextMenuStrip3";
            contextMenuStrip3.Size = new Size(61, 4);

            // Menu Strip
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 
                accountToolStripMenuItem, 
                clientToolStripMenuItem, 
                productToolStripMenuItem, 
                productToolStripMenuItem1, 
                categoryToolStripMenuItem, 
                ordersToolStripMenuItem, 
                warrantyToolStripMenuItem,
                campaignToolStripMenuItem
            });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1723, 35);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";

            // Account Menu
            accountToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addAccountToolStripMenuItem, manageAccountToolStripMenuItem });
            accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            accountToolStripMenuItem.Size = new Size(93, 29);
            accountToolStripMenuItem.Text = "Account";

            addAccountToolStripMenuItem.Name = "addAccountToolStripMenuItem";
            addAccountToolStripMenuItem.Size = new Size(248, 34);
            addAccountToolStripMenuItem.Text = "Add Account";
            addAccountToolStripMenuItem.Click += new EventHandler(addAccountToolStripMenuItem_Click);

            manageAccountToolStripMenuItem.Name = "manageAccountToolStripMenuItem";
            manageAccountToolStripMenuItem.Size = new Size(248, 34);
            manageAccountToolStripMenuItem.Text = "Manage Account";
            manageAccountToolStripMenuItem.Click += new EventHandler(manageAccountToolStripMenuItem_Click);

            // Client Menu
            clientToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addClientToolStripMenuItem, manageClientToolStripMenuItem });
            clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            clientToolStripMenuItem.Size = new Size(72, 29);
            clientToolStripMenuItem.Text = "Client";

            addClientToolStripMenuItem.Name = "addClientToolStripMenuItem";
            addClientToolStripMenuItem.Size = new Size(227, 34);
            addClientToolStripMenuItem.Text = "Add Client";
            addClientToolStripMenuItem.Click += new EventHandler(addClientToolStripMenuItem_Click);

            manageClientToolStripMenuItem.Name = "manageClientToolStripMenuItem";
            manageClientToolStripMenuItem.Size = new Size(227, 34);
            manageClientToolStripMenuItem.Text = "Manage Client";
            manageClientToolStripMenuItem.Click += new EventHandler(manageClientToolStripMenuItem_Click);

            // Brand Menu
            productToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addBrandToolStripMenuItem, manageBandToolStripMenuItem });
            productToolStripMenuItem.Name = "productToolStripMenuItem";
            productToolStripMenuItem.Size = new Size(74, 29);
            productToolStripMenuItem.Text = "Brand";

            addBrandToolStripMenuItem.Name = "addBrandToolStripMenuItem";
            addBrandToolStripMenuItem.Size = new Size(223, 34);
            addBrandToolStripMenuItem.Text = "Add Brand";
            addBrandToolStripMenuItem.Click += new EventHandler(addBrandToolStripMenuItem_Click);

            manageBandToolStripMenuItem.Name = "manageBandToolStripMenuItem";
            manageBandToolStripMenuItem.Size = new Size(223, 34);
            manageBandToolStripMenuItem.Text = "Manage Brand";
            manageBandToolStripMenuItem.Click += new EventHandler(manageBandToolStripMenuItem_Click);

            // Product Menu
            productToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { addProductToolStripMenuItem, manageProductToolStripMenuItem });
            productToolStripMenuItem1.Name = "productToolStripMenuItem1";
            productToolStripMenuItem1.Size = new Size(90, 29);
            productToolStripMenuItem1.Text = "Product";

            addProductToolStripMenuItem.Name = "addProductToolStripMenuItem";
            addProductToolStripMenuItem.Size = new Size(245, 34);
            addProductToolStripMenuItem.Text = "Add Product";
            addProductToolStripMenuItem.Click += new EventHandler(addProductToolStripMenuItem_Click);

            manageProductToolStripMenuItem.Name = "manageProductToolStripMenuItem";
            manageProductToolStripMenuItem.Size = new Size(245, 34);
            manageProductToolStripMenuItem.Text = "Manage Product";
            manageProductToolStripMenuItem.Click += new EventHandler(manageProductToolStripMenuItem_Click);

            // Category Menu
            categoryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addCategoryToolStripMenuItem, manageCategoryToolStripMenuItem });
            categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            categoryToolStripMenuItem.Size = new Size(100, 29);
            categoryToolStripMenuItem.Text = "Category";

            addCategoryToolStripMenuItem.Name = "addCategoryToolStripMenuItem";
            addCategoryToolStripMenuItem.Size = new Size(255, 34);
            addCategoryToolStripMenuItem.Text = "Add Category";
            addCategoryToolStripMenuItem.Click += new EventHandler(addCategoryToolStripMenuItem_Click);

            manageCategoryToolStripMenuItem.Name = "manageCategoryToolStripMenuItem";
            manageCategoryToolStripMenuItem.Size = new Size(255, 34);
            manageCategoryToolStripMenuItem.Text = "Manage Category";
            manageCategoryToolStripMenuItem.Click += new EventHandler(manageCategoryToolStripMenuItem_Click);

            // Orders Menu
            ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            ordersToolStripMenuItem.Size = new Size(82, 29);
            ordersToolStripMenuItem.Text = "Orders";
            ordersToolStripMenuItem.Click += new EventHandler(ordersToolStripMenuItem_Click);

            // Warranty Menu
            warrantyToolStripMenuItem.Name = "warrantyToolStripMenuItem";
            warrantyToolStripMenuItem.Size = new Size(99, 29);
            warrantyToolStripMenuItem.Text = "Warranty";

            // Campaign Menu
            campaignToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manageCampaignsToolStripMenuItem });
            campaignToolStripMenuItem.Name = "campaignToolStripMenuItem";
            campaignToolStripMenuItem.Size = new Size(109, 29);
            campaignToolStripMenuItem.Text = "Campaign";

            manageCampaignsToolStripMenuItem.Name = "manageCampaignsToolStripMenuItem";
            manageCampaignsToolStripMenuItem.Size = new Size(255, 34);
            manageCampaignsToolStripMenuItem.Text = "Manage Campaigns";
            manageCampaignsToolStripMenuItem.Click += new EventHandler(manageCampaignsToolStripMenuItem_Click);

            // Panel
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(1723, 918);
            panel1.TabIndex = 4;

            // Form
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1723, 953);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            Name = "AccountPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Account Page";
            WindowState = FormWindowState.Maximized;

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private ContextMenuStrip contextMenuStrip3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem accountToolStripMenuItem;
        private ToolStripMenuItem addAccountToolStripMenuItem;
        private ToolStripMenuItem manageAccountToolStripMenuItem;
        private ToolStripMenuItem clientToolStripMenuItem;
        private ToolStripMenuItem addClientToolStripMenuItem;
        private ToolStripMenuItem manageClientToolStripMenuItem;
        private ToolStripMenuItem productToolStripMenuItem;
        private ToolStripMenuItem addBrandToolStripMenuItem;
        private ToolStripMenuItem manageBandToolStripMenuItem;
        private ToolStripMenuItem productToolStripMenuItem1;
        private ToolStripMenuItem addProductToolStripMenuItem;
        private ToolStripMenuItem manageProductToolStripMenuItem;
        private ToolStripMenuItem categoryToolStripMenuItem;
        private ToolStripMenuItem addCategoryToolStripMenuItem;
        private ToolStripMenuItem manageCategoryToolStripMenuItem;
        private ToolStripMenuItem ordersToolStripMenuItem;
        private ToolStripMenuItem warrantyToolStripMenuItem;
        private ToolStripMenuItem campaignToolStripMenuItem;
        private ToolStripMenuItem manageCampaignsToolStripMenuItem;
        private Panel panel1;
    }
}