partial class CampaignForm
{
    private System.ComponentModel.IContainer components = null;

    private TextBox txtName;
    private TextBox txtDescription;
    private TextBox txtDiscount;
    private TextBox txtTarget;
    private ComboBox cmbScope;
    private DateTimePicker dtpStartDate;
    private DateTimePicker dtpEndDate;
    private Button btnAddCampaign;
    private Button btnRemoveCampaign;
    private ListBox lstCampaigns;

    private void InitializeComponent()
    {
        this.txtName = new TextBox();
        this.txtDescription = new TextBox();
        this.txtDiscount = new TextBox();
        this.txtTarget = new TextBox();
        this.cmbScope = new ComboBox();
        this.dtpStartDate = new DateTimePicker();
        this.dtpEndDate = new DateTimePicker();
        this.btnAddCampaign = new Button();
        this.btnRemoveCampaign = new Button();
        this.lstCampaigns = new ListBox();
        this.SuspendLayout();

        // txtName
        this.txtName.Location = new System.Drawing.Point(20, 20);
        this.txtName.Name = "txtName";
        this.txtName.Size = new System.Drawing.Size(200, 23);
        this.txtName.PlaceholderText = "Campaign Name";

        // txtDescription
        this.txtDescription.Location = new System.Drawing.Point(20, 60);
        this.txtDescription.Name = "txtDescription";
        this.txtDescription.Size = new System.Drawing.Size(200, 23);
        this.txtDescription.PlaceholderText = "Description";

        // txtDiscount
        this.txtDiscount.Location = new System.Drawing.Point(20, 100);
        this.txtDiscount.Name = "txtDiscount";
        this.txtDiscount.Size = new System.Drawing.Size(200, 23);
        this.txtDiscount.PlaceholderText = "Discount (%)";

        // txtTarget
        this.txtTarget.Location = new System.Drawing.Point(20, 140);
        this.txtTarget.Name = "txtTarget";
        this.txtTarget.Size = new System.Drawing.Size(200, 23);
        this.txtTarget.PlaceholderText = "Target (e.g., category, brand, product ID)";

        // cmbScope
        this.cmbScope.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbScope.Items.AddRange(new object[] { "Global", "Category", "Brand", "Product" });
        this.cmbScope.Location = new System.Drawing.Point(20, 180);
        this.cmbScope.Name = "cmbScope";
        this.cmbScope.Size = new System.Drawing.Size(200, 23);

        // dtpStartDate
        this.dtpStartDate.Location = new System.Drawing.Point(20, 220);
        this.dtpStartDate.Name = "dtpStartDate";
        this.dtpStartDate.Size = new System.Drawing.Size(200, 23);

        // dtpEndDate
        this.dtpEndDate.Location = new System.Drawing.Point(20, 260);
        this.dtpEndDate.Name = "dtpEndDate";
        this.dtpEndDate.Size = new System.Drawing.Size(200, 23);

        // btnAddCampaign
        this.btnAddCampaign.Location = new System.Drawing.Point(20, 300);
        this.btnAddCampaign.Name = "btnAddCampaign";
        this.btnAddCampaign.Size = new System.Drawing.Size(200, 30);
        this.btnAddCampaign.Text = "Add Campaign";
        this.btnAddCampaign.Click += new EventHandler(this.btnAddCampaign_Click);

        // btnRemoveCampaign
        this.btnRemoveCampaign.Location = new System.Drawing.Point(20, 340);
        this.btnRemoveCampaign.Name = "btnRemoveCampaign";
        this.btnRemoveCampaign.Size = new System.Drawing.Size(200, 30);
        this.btnRemoveCampaign.Text = "Remove Campaign";
        this.btnRemoveCampaign.Click += new EventHandler(this.btnRemoveCampaign_Click);

        // lstCampaigns
        this.lstCampaigns.Location = new System.Drawing.Point(240, 20);
        this.lstCampaigns.Name = "lstCampaigns";
        this.lstCampaigns.Size = new System.Drawing.Size(300, 350);

        // CampaignForm
        this.ClientSize = new System.Drawing.Size(560, 400);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.txtDescription);
        this.Controls.Add(this.txtDiscount);
        this.Controls.Add(this.txtTarget);
        this.Controls.Add(this.cmbScope);
        this.Controls.Add(this.dtpStartDate);
        this.Controls.Add(this.dtpEndDate);
        this.Controls.Add(this.btnAddCampaign);
        this.Controls.Add(this.btnRemoveCampaign);
        this.Controls.Add(this.lstCampaigns);
        this.Text = "Manage Campaigns";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
