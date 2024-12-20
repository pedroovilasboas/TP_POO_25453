using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace POO_25453_TP
{
    /// <summary>
    /// Defines the types of discounts that can be applied in a campaign
    /// </summary>
    public enum DiscountType
    {
        /// <summary>
        /// Discount applies to all products
        /// </summary>
        General,

        /// <summary>
        /// Discount applies to a specific product
        /// </summary>
        Product,

        /// <summary>
        /// Discount applies to all products of a specific brand
        /// </summary>
        Brand,

        /// <summary>
        /// Discount applies to all products in a specific category
        /// </summary>
        Category
    }

    /// <summary>
    /// Represents a promotional campaign in the e-commerce system.
    /// Manages discount offers and their application to products.
    /// </summary>
    public class Campaign
    {
        /// <summary>
        /// Unique identifier for the campaign
        /// </summary>
        public int CampaignID { get; private set; }

        /// <summary>
        /// Name of the campaign
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Detailed description of the campaign
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date when the campaign becomes active
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Date when the campaign expires
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Discount percentage to be applied
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Type of discount (General, Product, Brand, or Category)
        /// </summary>
        public DiscountType DiscountType { get; set; }

        /// <summary>
        /// Target identifier based on discount type (product name, brand name, or category name)
        /// </summary>
        public string TargetID { get; set; }

        /// <summary>
        /// File path for storing campaign data
        /// </summary>
        private static string campaignsFile = @"C:\PROGRAM_CS\TP_POO_25453\Campaign\campaigns.txt";

        /// <summary>
        /// Tracks the last used campaign ID for auto-increment
        /// </summary>
        private static int lastCampaignID = 0;

        /// <summary>
        /// Constructor for existing campaigns loaded from storage
        /// </summary>
        /// <param name="campaignId">Existing campaign ID</param>
        /// <param name="name">Campaign name</param>
        /// <param name="description">Campaign description</param>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <param name="discountPercentage">Discount percentage</param>
        /// <param name="discountType">Type of discount</param>
        /// <param name="targetId">Target identifier</param>
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

        /// <summary>
        /// Constructor for creating new campaigns
        /// Automatically generates a new campaign ID
        /// </summary>
        /// <param name="name">Campaign name</param>
        /// <param name="description">Campaign description</param>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <param name="discountPercentage">Discount percentage</param>
        /// <param name="discountType">Type of discount</param>
        /// <param name="targetId">Target identifier (optional)</param>
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

        /// <summary>
        /// Saves the current campaign to storage
        /// </summary>
        public void Save()
        {
            var campaigns = LoadCampaigns();
            campaigns.Add(this);
            SaveCampaigns(campaigns);
        }

        /// <summary>
        /// Loads all campaigns from storage
        /// </summary>
        /// <returns>List of all campaigns in the system</returns>
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

        /// <summary>
        /// Saves multiple campaigns to storage
        /// </summary>
        /// <param name="campaigns">List of campaigns to save</param>
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

        /// <summary>
        /// Calculates the discounted price for a product considering all active campaigns
        /// </summary>
        /// <param name="product">Product to calculate discount for</param>
        /// <returns>Final price after applying the highest applicable discount</returns>
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

        /// <summary>
        /// Checks if this campaign applies to a specific product
        /// </summary>
        /// <param name="product">Product to check</param>
        /// <returns>True if the campaign applies to the product</returns>
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
