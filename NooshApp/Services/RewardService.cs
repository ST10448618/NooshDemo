using NooshApp.Repositories.Interfaces;
using NooshApp.Services.Interfaces;
using NooshApp.ViewModels;

namespace NooshApp.Services
{
    public class RewardService : IRewardService
    {
        private readonly IRewardRepository _rewardRepository;
        private const int DemoPointsAmount = 50;

        public RewardService(IRewardRepository rewardRepository)
        {
            _rewardRepository = rewardRepository;
        }

        public async Task<RewardsDashboardViewModel> GetDashboardAsync(int userId)
        {
            var totalPoints = await _rewardRepository.GetTotalPointsForUserAsync(userId);
            var history = await _rewardRepository.GetHistoryForUserAsync(userId);
            var milestones = await _rewardRepository.GetActiveMilestonesAsync();

            // Find the next milestone the user hasn't reached yet.
            var nextMilestone = milestones.FirstOrDefault(m => m.PointsRequired > totalPoints);

            int progressPercent = 0;
            if (nextMilestone != null)
            {
                // Find the previous milestone (or 0) to calculate progress within this band.
                var previousThreshold = milestones
                    .Where(m => m.PointsRequired <= totalPoints)
                    .OrderByDescending(m => m.PointsRequired)
                    .FirstOrDefault()?.PointsRequired ?? 0;

                var band = nextMilestone.PointsRequired - previousThreshold;
                var progressInBand = totalPoints - previousThreshold;

                progressPercent = band > 0
                    ? (int)Math.Round((double)progressInBand / band * 100)
                    : 0;
            }
            else if (milestones.Any())
            {
                // User has surpassed every milestone.
                progressPercent = 100;
            }

            return new RewardsDashboardViewModel
            {
                TotalPoints = totalPoints,
                History = history,
                Milestones = milestones,
                NextMilestone = nextMilestone,
                ProgressPercent = progressPercent
            };
        }

        public async Task AddDemoPointsAsync(int userId)
        {
            await _rewardRepository.AddPointsAsync(userId, DemoPointsAmount, "Demo points (testing)");
        }
    }
}