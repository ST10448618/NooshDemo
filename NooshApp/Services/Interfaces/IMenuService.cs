using NooshApp.Models;

namespace NooshApp.Services.Interfaces
{
    /// <summary>
    /// Business logic layer for menu-related operations.
    /// Controllers talk to this, never directly to the Repository.
    /// </summary>
    public interface IMenuService
    {
        Task<List<MenuItem>> GetFeaturedMealsAsync();
        Task<List<MenuItem>> GetFullMenuAsync();
        Task<List<MenuItem>> GetMenuByCategoryAsync(string category);
    }
}