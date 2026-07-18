using NooshApp.Models;

namespace NooshApp.Repositories.Interfaces
{
    /// <summary>
    /// Defines data-access operations for MenuItems.
    /// The Service layer depends on this interface, never on the concrete class —
    /// this is what makes swapping/mocking the data source possible.
    /// </summary>
    public interface IMenuItemRepository
    {
        Task<List<MenuItem>> GetAllAsync();
        Task<List<MenuItem>> GetByCategoryAsync(string category);
        Task<List<MenuItem>> GetFeaturedAsync(int count);
        Task<MenuItem?> GetByIdAsync(int id);
        Task AddAsync(MenuItem item);
        Task UpdateAsync(MenuItem item);
        Task DeleteAsync(int id);
    }
}