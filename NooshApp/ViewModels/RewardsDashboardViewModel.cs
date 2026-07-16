using NooshApp.Models;

namespace NooshApp.ViewModels
{
    public class RewardsDashboardViewModel
    {
        public int TotalPoints { get; set; }
        public List<RewardHistory> History { get; set; } = new();
        public List<RewardMilestone> Milestones { get; set; } = new();
        public RewardMilestone? NextMilestone { get; set; }
        public int ProgressPercent { get; set; }
    }
}