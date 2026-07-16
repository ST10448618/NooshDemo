using NooshApp.Models;

namespace NooshApp.Repositories.Interfaces
{
    public interface IRewardRepository
    {
        Task<List<RewardHistory>> GetHistoryForUserAsync(int userId);
        Task<int> GetTotalPointsForUserAsync(int userId);
        Task AddPointsAsync(int userId, int points, string description);
        Task<List<RewardMilestone>> GetActiveMilestonesAsync();
    }
}