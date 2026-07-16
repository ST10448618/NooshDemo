using Microsoft.EntityFrameworkCore;
using NooshApp.Data;
using NooshApp.Models;
using NooshApp.Repositories.Interfaces;

namespace NooshApp.Repositories
{
    /// <summary>
    /// Concrete implementation of IMenuItemRepository.
    /// This is the ONLY class in the app allowed to run EF Core queries against MenuItems.
    /// </summary>
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuItem>> GetAllAsync()
        {
            return await _context.MenuItems
                .Where(m => m.IsAvailable)
                .OrderBy(m => m.Category)
                .ThenBy(m => m.Name)
                .ToListAsync();
        }

        public async Task<List<MenuItem>> GetByCategoryAsync(string category)
        {
            return await _context.MenuItems
                .Where(m => m.IsAvailable && m.Category == category)
                .OrderBy(m => m.Name)
                .ToListAsync();
        }

        public async Task<List<MenuItem>> GetFeaturedAsync(int count)
        {
            var featuredItems = await _context.MenuItems
                .Where(m => m.IsAvailable && m.IsPopular)
                .ToListAsync(); // pulled into memory here — safe to use client-side (C#) logic below

            return featuredItems
                .OrderBy(m => Guid.NewGuid()) // now runs in C#, not translated to SQL
                .Take(count)
                .ToList();
        }
        public async Task<MenuItem?> GetByIdAsync(int id)
        {
            return await _context.MenuItems.FindAsync(id);
        }

        public async Task AddAsync(MenuItem item)
        {
            await _context.MenuItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MenuItem item)
        {
            _context.MenuItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.MenuItems.FindAsync(id);
            if (item != null)
            {
                _context.MenuItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}