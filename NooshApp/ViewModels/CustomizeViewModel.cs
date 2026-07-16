namespace NooshApp.ViewModels
{
    /// <summary>
    /// Represents one protein option for the shawarma builder.
    /// </summary>
    public class ProteinOption
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    /// <summary>
    /// Represents one included ingredient the customer can remove.
    /// </summary>
    public class IngredientOption
    {
        public string Id { get; set; } = string.Empty;   // used as the DOM element id / data attribute
        public string Name { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty; // Font Awesome class
    }

    /// <summary>
    /// Full data set needed to render the Customize page.
    /// </summary>
    public class CustomizeViewModel
    {
        public List<ProteinOption> Proteins { get; set; } = new();
        public List<IngredientOption> Ingredients { get; set; } = new();
    }
}