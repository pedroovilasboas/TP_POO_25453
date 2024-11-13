using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _25453_TP_POO
{
    public class Campaign
    {
        // Campaign class attributes
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // IDs to define campaign scope
        public int? ProductId { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }

        // File path for campaigns.txt for persistence
        private static string campaignsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\25453_TP_POO\Campaign\campaigns.txt");

        // Constructor
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

        // Method to check if the campaign is applicable to a product
        public bool IsApplicable(Product product)
        {
            // Checks if the campaign is active
            if (!IsCampaignActive())
                return false;

            // Checks campaign scope: specific product, brand, or category
            if (ProductId.HasValue && product.ProductId == ProductId.Value)
                return true;
            if (BrandId.HasValue && product.Brand.BrandId == BrandId.Value)
                return true;
            if (CategoryId.HasValue && product.Category.CategoryId == CategoryId.Value)
                return true;

            return false;
        }

        // Method to apply the campaign discount to a product if applicable
        public bool ApplyToProduct(Product product)
        {
            if (IsApplicable(product))
            {
                product.Price *= (1 - (decimal)DiscountPercentage / 100);
                return true;
            }
            return false;
        }

        // Method to check if the campaign is currently active
        public bool IsCampaignActive()
        {
            var currentDate = DateTime.Now;
            return currentDate >= StartDate && currentDate <= EndDate;
        }

        // Method to save the campaign to file
        public void Save()
        {
            var campaigns = LoadCampaigns();
            campaigns.Add(this);
            SaveCampaigns(campaigns);
        }

        // Method to load all campaigns from file
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

        // Method to save a list of campaigns to file
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
