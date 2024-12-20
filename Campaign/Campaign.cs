using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace POO_25453_TP
{
    public enum DiscountType
    {
        General,
        Product,
        Brand,
        Category
    }

    public class Campaign
    {
        // Properties
        public int CampaignID { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DiscountType DiscountType { get; set; }
        public string TargetID { get; set; }

        // File path for storing campaigns
        private static string campaignsFile = @"C:\PROGRAM_CS\TP_POO_25453\Campaign\campaigns.txt";
        private static int lastCampaignID = 0;

        // Constructor for existing campaign (loaded from file)
        public Campaign(int campaignId, string name, string description, DateTime startDate, 
                      DateTime endDate, decimal discountPercentage, DiscountType discountType, string targetId)
        {
            CampaignID = campaignId;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            DiscountPercentage = discountPercentage;
            DiscountType = discountType;
            TargetID = targetId;
        }

        // Constructor for new campaign
        public Campaign(string name, string description, DateTime startDate, DateTime endDate, 
                      decimal discountPercentage, DiscountType discountType, string targetId = null)
        {
            CampaignID = ++lastCampaignID;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            DiscountPercentage = discountPercentage;
            DiscountType = discountType;
            TargetID = targetId;
        }

        // Method to save the campaign
        public void Save()
        {
            var campaigns = LoadCampaigns();
            campaigns.Add(this);
            SaveCampaigns(campaigns);
        }

        // Method to load all campaigns
        public static List<Campaign> LoadCampaigns()
        {
            var campaigns = new List<Campaign>();
            if (!File.Exists(campaignsFile)) return campaigns;

            var lines = File.ReadAllLines(campaignsFile);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length != 8) continue;

                campaigns.Add(new Campaign(
                    int.Parse(parts[0]),
                    parts[1],
                    parts[2],
                    DateTime.Parse(parts[3]),
                    DateTime.Parse(parts[4]),
                    decimal.Parse(parts[5]),
                    (DiscountType)Enum.Parse(typeof(DiscountType), parts[6]),
                    parts[7] == "null" ? null : parts[7]
                ));
            }

            if (campaigns.Any())
            {
                lastCampaignID = campaigns.Max(c => c.CampaignID);
            }
            else
            {
                lastCampaignID = 0;
            }

            return campaigns;
        }

        // Method to save all campaigns
        public static void SaveCampaigns(List<Campaign> campaigns)
        {
            var lines = campaigns.Select(c => string.Join(";",
                c.CampaignID,
                c.Name,
                c.Description,
                c.StartDate.ToString("yyyy-MM-dd"),
                c.EndDate.ToString("yyyy-MM-dd"),
                c.DiscountPercentage,
                c.DiscountType,
                c.TargetID ?? "null"
            ));

            string directory = Path.GetDirectoryName(campaignsFile);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllLines(campaignsFile, lines);
        }

        // Method to get discounted price for a product
        public static decimal GetDiscountedPrice(Product product)
        {
            var campaigns = LoadCampaigns()
                .Where(c => c.StartDate <= DateTime.Now && c.EndDate >= DateTime.Now)
                .ToList();

            decimal maxDiscount = 0;
            foreach (var campaign in campaigns)
            {
                if (campaign.IsApplicable(product))
                {
                    maxDiscount = Math.Max(maxDiscount, campaign.DiscountPercentage);
                }
            }

            return product.Price * (1 - maxDiscount / 100);
        }

        // Method to check if campaign is applicable to a product
        public bool IsApplicable(Product product)
        {
            if (DateTime.Now < StartDate || DateTime.Now > EndDate)
                return false;

            if (DiscountType == DiscountType.General)
                return true;

            switch (DiscountType)
            {
                case DiscountType.Product:
                    return product.Name == TargetID;
                case DiscountType.Brand:
                    return product.Brand?.Name == TargetID;
                case DiscountType.Category:
                    return product.Category?.Name == TargetID;
                default:
                    return false;
            }
        }
    }
}
