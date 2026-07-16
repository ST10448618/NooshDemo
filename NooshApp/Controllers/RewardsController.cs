using Microsoft.AspNetCore.Mvc;
using NooshApp.Helpers;
using NooshApp.Middleware;
using NooshApp.Services.Interfaces;

namespace NooshApp.Controllers
{
    [RequireLogin]
    public class RewardsController : Controller
    {
        private readonly IRewardService _rewardService;

        public RewardsController(IRewardService rewardService)
        {
            _rewardService = rewardService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetLoggedInUserId()!.Value;
            var viewModel = await _rewardService.GetDashboardAsync(userId);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDemoPoints()
        {
            var userId = HttpContext.Session.GetLoggedInUserId()!.Value;
            await _rewardService.AddDemoPointsAsync(userId);
            return RedirectToAction("Index");
        }
    }
}