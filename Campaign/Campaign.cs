using System;

namespace POO_25453_TP
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
        public int ProductID { get; set; }   // Renamed to match Product class convention
        public int BrandID { get; set; }     // Renamed to match Brand class convention
        public int CategoryID { get; set; }  // Renamed to match Category class convention

        // File path for campaigns.txt for persistence
        private static string campaignsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\POO_25453_TP\Campaign\campaigns.txt");


    }
}
