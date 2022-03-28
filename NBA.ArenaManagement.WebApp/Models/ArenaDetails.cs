using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA.ArenaManagement.WebApp.Models
{
    public class ArenaDetails
    {
        public string ArenaId { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Team { get; set; }
        public int TotalPercentageComplete { get; set; }
        public int GeneralPercentageComplete { get; set; }
        public int CapacitiesPercentageComplete { get; set; }
        public int SuitesPercentageComplete { get; set; }
        public int PremiumPercentageComplete { get; set; }
        public int ArchitecturePercentageComplete { get; set; }
        public int TechnologyPercentageComplete { get; set; }
        public int FoodPercentageComplete { get; set; }
        public int ArenaPercentageComplete { get; set; }
        public int SecurityPercentageComplete { get; set; }
        public int PracticePercentageComplete { get; set; }
        public int SustainPercentageComplete { get; set; }
        public int ImagesUploaded { get; set; }
    }
}