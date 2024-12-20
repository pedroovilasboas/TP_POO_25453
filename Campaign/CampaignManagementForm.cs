using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POO_25453_TP
{
    /// <summary>
    /// Form for managing promotional campaigns.
    /// Provides functionality for creating, viewing, and deleting campaigns,
    /// with support for different discount types and targets.
    /// </summary>
    public partial class CampaignManagementForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the CampaignManagementForm.
        /// Loads existing campaigns and initializes the discount type combo box.
        /// </summary>
        public CampaignManagementForm()
        {
            InitializeComponent();
            LoadCampaigns();
            
            // Initialize the discount type combo box with enum values
            cboDiscountType.Items.Clear();
            foreach (DiscountType type in Enum.GetValues(typeof(DiscountType)))
            {
                cboDiscountType.Items.Add(type);
            }
            if (cboDiscountType.Items.Count > 0)
                cboDiscountType.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the form load event. Refreshes the campaign list display.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void CampaignManagementForm_Load(object sender, EventArgs e)
        {
            RefreshCampaignList();
        }

        /// <summary>
        /// Refreshes the campaign list by reloading all campaigns from storage.
        /// </summary>
        private void RefreshCampaignList()
        {
            var campaigns = Campaign.LoadCampaigns();
            DisplayResults(campaigns);
        }

        /// <summary>
        /// Displays the list of campaigns in the data grid view.
        /// Shows campaign details including status and target information.
        /// </summary>
        /// <param name="campaigns">List of campaigns to display.</param>
        private void DisplayResults(List<Campaign> campaigns)
        {
            dgvCampaigns.Rows.Clear();
            dgvCampaigns.Columns.Clear();

            // Set up columns
            dgvCampaigns.Columns.Add("CampaignID", "ID");
            dgvCampaigns.Columns.Add("Name", "Name");
            dgvCampaigns.Columns.Add("Description", "Description");
            dgvCampaigns.Columns.Add("StartDate", "Start Date");
            dgvCampaigns.Columns.Add("EndDate", "End Date");
            dgvCampaigns.Columns.Add("Discount", "Discount %");
            dgvCampaigns.Columns.Add("Type", "Type");
            dgvCampaigns.Columns.Add("Target", "Target");
            dgvCampaigns.Columns.Add("Status", "Status");

            foreach (var campaign in campaigns)
            {
                string status = campaign.EndDate >= DateTime.Now ? "Active" : "Expired";
                string target = campaign.DiscountType == DiscountType.General ? "All Products" : campaign.TargetID;

                dgvCampaigns.Rows.Add(
                    campaign.CampaignID,
                    campaign.Name,
                    campaign.Description,
                    campaign.StartDate.ToShortDateString(),
                    campaign.EndDate.ToShortDateString(),
                    $"{campaign.DiscountPercentage}%",
                    campaign.DiscountType.ToString(),
                    target,
                    status
                );
            }
        }

        /// <summary>
        /// Sets up the discount type combo box with available discount types.
        /// </summary>
        private void SetupDiscountTypes()
        {
            cboDiscountType.Items.Clear();
            cboDiscountType.Items.AddRange(Enum.GetNames(typeof(DiscountType)));
            cboDiscountType.SelectedIndex = 0;
            UpdateTargetComboBox();
        }

        /// <summary>
        /// Updates the target combo box based on the selected discount type.
        /// Populates with appropriate options (products, brands, or categories).
        /// </summary>
        private void UpdateTargetComboBox()
        {
            cboTarget.Items.Clear();
            var selectedType = (DiscountType)Enum.Parse(typeof(DiscountType), cboDiscountType.SelectedItem.ToString());

            switch (selectedType)
            {
                case DiscountType.Product:
                    cboTarget.Items.AddRange(Product.LoadProducts().Select(p => p.Name).ToArray());
                    break;
                case DiscountType.Brand:
                    cboTarget.Items.AddRange(Brand.LoadBrands().Select(b => b.Name).ToArray());
                    break;
                case DiscountType.Category:
                    cboTarget.Items.AddRange(Category.LoadCategories().Select(c => c.Name).ToArray());
                    break;
                case DiscountType.General:
                    cboTarget.Items.Add("All Products");
                    break;
            }

            if (cboTarget.Items.Count > 0)
                cboTarget.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the discount type selection change event.
        /// Updates the target combo box accordingly.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void cboDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTargetComboBox();
        }

        /// <summary>
        /// Handles the discount type selection change event.
        /// Updates the target combo box and its enabled state based on the selected type.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void cboDiscountType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cboTarget.Items.Clear();

            if (cboDiscountType.SelectedItem == null)
                return;

            switch ((DiscountType)cboDiscountType.SelectedItem)
            {
                case DiscountType.General:
                    cboTarget.Items.Add("General");
                    cboTarget.SelectedIndex = 0;
                    cboTarget.Enabled = false;
                    break;
                case DiscountType.Product:
                    cboTarget.Enabled = true;
                    var products = Product.LoadProducts();
                    foreach (var product in products)
                    {
                        cboTarget.Items.Add(product.Name);
                    }
                    break;
                case DiscountType.Brand:
                    cboTarget.Enabled = true;
                    var brands = Brand.LoadBrands();
                    foreach (var brand in brands)
                    {
                        cboTarget.Items.Add(brand.Name);
                    }
                    break;
                case DiscountType.Category:
                    cboTarget.Enabled = true;
                    var categories = Category.LoadCategories();
                    foreach (var category in categories)
                    {
                        cboTarget.Items.Add(category.Name);
                    }
                    break;
            }

            if (cboTarget.Items.Count > 0 && cboTarget.Enabled)
            {
                cboTarget.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Handles the add campaign button click event.
        /// Creates and saves a new campaign with the entered information.
        /// Shows appropriate success or error messages.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnAddCampaign_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please enter a campaign name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var campaign = new Campaign(
                    txtName.Text.Trim(),
                    txtDescription.Text.Trim(),
                    dtpStartDate.Value,
                    dtpStartDate.Value.AddDays((double)numDuration.Value),
                    numDiscount.Value,
                    (DiscountType)Enum.Parse(typeof(DiscountType), cboDiscountType.SelectedItem.ToString()),
                    cboDiscountType.SelectedItem.ToString() == "General" ? null : cboTarget.SelectedItem.ToString()
                );

                campaign.Save();
                RefreshCampaignList();
                ClearInputs();
                MessageBox.Show("Campaign added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding campaign: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the delete campaign button click event.
        /// Deletes the selected campaign after confirmation.
        /// Shows appropriate success or error messages.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnDeleteCampaign_Click(object sender, EventArgs e)
        {
            if (dgvCampaigns.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a campaign to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this campaign?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var campaigns = Campaign.LoadCampaigns();
                    int campaignId = int.Parse(dgvCampaigns.SelectedRows[0].Cells["CampaignID"].Value.ToString());
                    var campaign = campaigns.FirstOrDefault(c => c.CampaignID == campaignId);

                    if (campaign != null)
                    {
                        campaigns.Remove(campaign);
                        Campaign.SaveCampaigns(campaigns);
                        RefreshCampaignList();
                        MessageBox.Show("Campaign deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting campaign: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles the close button click event. Closes the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Clears all input fields and resets them to default values.
        /// </summary>
        private void ClearInputs()
        {
            txtName.Clear();
            txtDescription.Clear();
            dtpStartDate.Value = DateTime.Now;
            numDuration.Value = 1;
            numDiscount.Value = 10;
            cboDiscountType.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads all campaigns from storage and displays them in the grid.
        /// </summary>
        private void LoadCampaigns()
        {
            var campaigns = Campaign.LoadCampaigns();
            DisplayResults(campaigns);
        }
    }
}
