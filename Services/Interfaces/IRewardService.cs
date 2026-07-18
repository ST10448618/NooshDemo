using NooshApp.ViewModels;

namespace NooshApp.Services.Interfaces
{
    public interface IRewardService
    {
        Task<RewardsDashboardViewModel> GetDashboardAsync(int userId);
        Task AddDemoPointsAsync(int userId);
    }
}