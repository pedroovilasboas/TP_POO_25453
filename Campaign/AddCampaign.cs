using System;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class CampaignForm : Form
{
    private List<Campaign> campaigns = new List<Campaign>();

    public CampaignForm()
    {
        InitializeComponent();
    }

    private void btnAddCampaign_Click(object sender, EventArgs e)
    {
        try
        {
            // Criar uma nova campanha com os dados fornecidos
            var campaign = new Campaign
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                DiscountPercentage = decimal.Parse(txtDiscount.Text),
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value,
                Scope = cmbScope.SelectedItem.ToString(),
                Target = txtTarget.Text
            };

            // Adicionar a campanha à lista
            campaigns.Add(campaign);

            // Atualizar a lista de campanhas no formulário
            UpdateCampaignList();
            ClearFields();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRemoveCampaign_Click(object sender, EventArgs e)
    {
        if (lstCampaigns.SelectedIndex != -1)
        {
            // Remover a campanha selecionada
            campaigns.RemoveAt(lstCampaigns.SelectedIndex);
            UpdateCampaignList();
        }
        else
        {
            MessageBox.Show("Please select a campaign to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void UpdateCampaignList()
    {
        // Atualizar a lista de campanhas exibida no ListBox
        lstCampaigns.Items.Clear();
        foreach (var campaign in campaigns)
        {
            lstCampaigns.Items.Add(campaign.ToString());
        }
    }

    private void ClearFields()
    {
        // Limpar os campos do formulário
        txtName.Clear();
        txtDescription.Clear();
        txtDiscount.Clear();
        txtTarget.Clear();
        cmbScope.SelectedIndex = -1;
        dtpStartDate.Value = DateTime.Now;
        dtpEndDate.Value = DateTime.Now;
    }
}
