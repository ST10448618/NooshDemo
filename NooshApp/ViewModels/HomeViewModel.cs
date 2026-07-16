using NooshApp.Models;

namespace NooshApp.ViewModels
{
    public class HomeViewModel
    {
        public List<MenuItem> FeaturedMeals { get; set; } = new();
        public List<StoreLocation> StoreLocations { get; set; } = new();
        public string UberEatsUrl { get; set; } = string.Empty;
        public string MrDUrl { get; set; } = string.Empty;
    }
}