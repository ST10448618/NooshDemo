using Microsoft.EntityFrameworkCore;
using NooshApp.Data;
using NooshApp.Models;
using NooshApp.Repositories.Interfaces;

namespace NooshApp.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Application application)
        {
            await _context.Applications.AddAsync(application);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Application>> GetAllAsync()
        {
            return await _context.Applications
                .OrderByDescending(a => a.SubmittedAt)
                .ToListAsync();
        }
    }
}