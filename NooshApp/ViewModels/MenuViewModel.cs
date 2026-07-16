using NooshApp.Models;

namespace NooshApp.ViewModels
{
    /// <summary>
    /// Shapes data for the full Menu page — all items plus the distinct
    /// list of categories, so the View can build filter pills without
    /// re-deriving that list itself.
    /// </summary>
    public class MenuViewModel
    {
        public List<MenuItem> Items { get; set; } = new();
        public List<string> Categories { get; set; } = new();
    }
}