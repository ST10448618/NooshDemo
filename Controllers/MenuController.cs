using Microsoft.AspNetCore.Mvc;
using NooshApp.Services.Interfaces;
using NooshApp.ViewModels;

namespace NooshApp.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly ICustomizeService _customizeService;

        public MenuController(IMenuService menuService, ICustomizeService customizeService)
        {
            _menuService = menuService;
            _customizeService = customizeService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _menuService.GetFullMenuAsync();

            var viewModel = new MenuViewModel
            {
                Items = items,
                Categories = items
                    .Select(i => i.Category)
                    .Distinct()
                    .OrderBy(c => c)
                    .ToList()
            };

            return View(viewModel);
        }

        public IActionResult Customize()
        {
            var viewModel = _customizeService.GetBuilderOptions();
            return View(viewModel);
        }
    }
}