using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace POO_25453_TP
{
    public class Alert
    {
        // Class attributes
        public int AlertId { get; set; }
        public string Message { get; set; }
        public int ProductID { get; set; } // Updated to match the `ProductID`
        public DateTime CreatedAt { get; set; }

        // File path for alerts.txt 
        private static string alertsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\PROGRAM_CS\POO_25453_TP\Alert\alerts.txt");


    }
}
