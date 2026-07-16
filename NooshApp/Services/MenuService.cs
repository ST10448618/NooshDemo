using NooshApp.Models;
using NooshApp.Repositories.Interfaces;
using NooshApp.Services.Interfaces;

namespace NooshApp.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuItemRepository _repository;
        private const int FeaturedMealCount = 4;

        public MenuService(IMenuItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MenuItem>> GetFeaturedMealsAsync()
        {
            return await _repository.GetFeaturedAsync(FeaturedMealCount);
        }

        public async Task<List<MenuItem>> GetFullMenuAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<MenuItem>> GetMenuByCategoryAsync(string category)
        {
            return await _repository.GetByCategoryAsync(category);
        }
    }
}