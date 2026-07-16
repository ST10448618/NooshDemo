using Microsoft.EntityFrameworkCore;
using NooshApp.Data;
using NooshApp.Models;
using NooshApp.Repositories.Interfaces;

namespace NooshApp.Repositories
{
    public class CateringRepository : ICateringRepository
    {
        private readonly ApplicationDbContext _context;

        public CateringRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CateringRequest request)
        {
            await _context.CateringRequests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CateringRequest>> GetAllAsync()
        {
            return await _context.CateringRequests
                .OrderByDescending(r => r.SubmittedAt)
                .ToListAsync();
        }

        public async Task<CateringRequest?> GetByIdAsync(int id)
        {
            return await _context.CateringRequests.FindAsync(id);
        }
    }
}