using Microsoft.EntityFrameworkCore;
using NooshApp.Data;
using NooshApp.Models;
using NooshApp.Repositories.Interfaces;

namespace NooshApp.Repositories
{
    public class RewardRepository : IRewardRepository
    {
        private readonly ApplicationDbContext _context;

        public RewardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RewardHistory>> GetHistoryForUserAsync(int userId)
        {
            return await _context.RewardHistories
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.EarnedAt)
                .ToListAsync();
        }

        public async Task<int> GetTotalPointsForUserAsync(int userId)
        {
            return await _context.RewardHistories
                .Where(r => r.UserId == userId)
                .SumAsync(r => r.PointsEarned);
        }

        public async Task AddPointsAsync(int userId, int points, string description)
        {
            var entry = new RewardHistory
            {
                UserId = userId,
                PointsEarned = points,
                Description = description,
                EarnedAt = DateTime.UtcNow
            };

            await _context.RewardHistories.AddAsync(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RewardMilestone>> GetActiveMilestonesAsync()
        {
            return await _context.RewardMilestones
                .Where(m => m.IsActive)
                .OrderBy(m => m.DisplayOrder)
                .ToListAsync();
        }
    }
}