using NooshApp.Services.Interfaces;
using NooshApp.ViewModels;

namespace NooshApp.Services
{
    public class CustomizeService : ICustomizeService
    {
        public CustomizeViewModel GetBuilderOptions()
        {
            return new CustomizeViewModel
            {
                Proteins = new List<ProteinOption>
                {
                    new ProteinOption { Name = "Chicken", Price = 70.00m },
                    new ProteinOption { Name = "Beef", Price = 80.00m },
                    new ProteinOption { Name = "Falafel", Price = 80.00m }
                },
                Ingredients = new List<IngredientOption>
                {
                    new IngredientOption { Id = "hummus", Name = "Hummus", Icon = "fa-solid fa-circle" },
                    new IngredientOption { Id = "onions", Name = "Onions", Icon = "fa-solid fa-seedling" },
                    new IngredientOption { Id = "tomatoes", Name = "Tomatoes", Icon = "fa-solid fa-apple-whole" },
                    new IngredientOption { Id = "pickles", Name = "Pickles", Icon = "fa-solid fa-cucumber" },
                    new IngredientOption { Id = "brinjal", Name = "Fried Brinjal", Icon = "fa-solid fa-egg-plant" },
                    new IngredientOption { Id = "cabbage", Name = "Cabbage", Icon = "fa-solid fa-leaf" },
                    new IngredientOption { Id = "lettuce", Name = "Lettuce", Icon = "fa-solid fa-leaf" },
                    new IngredientOption { Id = "cheese", Name = "Cheese", Icon = "fa-solid fa-cheese" },
                    new IngredientOption { Id = "fries", Name = "Fries", Icon = "fa-solid fa-fries" }
                }
            };
        }
    }
}