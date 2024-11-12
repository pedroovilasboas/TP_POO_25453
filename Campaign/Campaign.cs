using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _25453_TP_POO
{
    public class Campaign
    {
        // Atributos da classe Campaign
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // IDs para definir o escopo da campanha
        public int? ProductId { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }

        // Caminho para o arquivo campaigns.txt para persistência
        private static string campaignsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Campaign\campaigns.txt");

        // Construtor
        public Campaign(int campaignId, string name, string description, float discountPercentage, DateTime startDate, DateTime endDate,
                        int? productId = null, int? brandId = null, int? categoryId = null)
        {
            CampaignId = campaignId;
            Name = name;
            Description = description;
            DiscountPercentage = discountPercentage;
            StartDate = startDate;
            EndDate = endDate;
            ProductId = productId;
            BrandId = brandId;
            CategoryId = categoryId;
        }

        // Método para verificar se a campanha é aplicável a um produto
        public bool IsApplicable(Product product)
        {
            // Verifica se a campanha está ativa
            if (!IsCampaignActive())
                return false;

            // Verifica o escopo da campanha: produto específico, marca ou categoria
            if (ProductId.HasValue && product.ProductId == ProductId.Value)
                return true;
            if (BrandId.HasValue && product.Brand.BrandId == BrandId.Value)
                return true;
            if (CategoryId.HasValue && product.Category.CategoryId == CategoryId.Value)
                return true;

            return false;
        }

        // Método para aplicar a campanha ao produto, se aplicável
        public bool ApplyToProduct(Product product)
        {
            if (IsApplicable(product))
            {
                product.Price *= (1 - (decimal)DiscountPercentage / 100);
                return true;
            }
            return false;
        }

        // Método para verificar se a campanha está ativa
        public bool IsCampaignActive()
        {
            var currentDate = DateTime.Now;
            return currentDate >= StartDate && currentDate <= EndDate;
        }

        // Método para salvar a campanha no arquivo
        public void Save()
        {
            var campaigns = LoadCampaigns();
            campaigns.Add(this);
            SaveCampaigns(campaigns);
        }

        // Método para carregar campanhas a partir do arquivo
        public static List<Campaign> LoadCampaigns()
        {
            var campaigns = new List<Campaign>();

            if (File.Exists(campaignsFile))
            {
                var lines = File.ReadAllLines(campaignsFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length > 8)
                    {
                        int campaignId = int.Parse(parts[0]);
                        string name = parts[1];
                        string description = parts[2];
                        float discountPercentage = float.Parse(parts[3]);
                        DateTime startDate = DateTime.Parse(parts[4]);
                        DateTime endDate = DateTime.Parse(parts[5]);
                        int? productId = string.IsNullOrEmpty(parts[6]) ? (int?)null : int.Parse(parts[6]);
                        int? brandId = string.IsNullOrEmpty(parts[7]) ? (int?)null : int.Parse(parts[7]);
                        int? categoryId = string.IsNullOrEmpty(parts[8]) ? (int?)null : int.Parse(parts[8]);

                        var campaign = new Campaign(campaignId, name, description, discountPercentage, startDate, endDate, productId, brandId, categoryId);
                        campaigns.Add(campaign);
                    }
                }
            }

            return campaigns;
        }

        // Método para salvar uma lista de campanhas no arquivo
        public static void SaveCampaigns(List<Campaign> campaigns)
        {
            using (var writer = new StreamWriter(campaignsFile))
            {
                foreach (var campaign in campaigns)
                {
                    writer.WriteLine($"{campaign.CampaignId},{campaign.Name},{campaign.Description},{campaign.DiscountPercentage},{campaign.StartDate},{campaign.EndDate},{campaign.ProductId},{campaign.BrandId},{campaign.CategoryId}");
                }
            }
        }
    }
}
