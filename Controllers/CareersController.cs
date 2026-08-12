using Microsoft.AspNetCore.Mvc;
using NooshApp.Services.Interfaces;
using NooshApp.ViewModels;

namespace NooshApp.Controllers
{
    public class CareersController : Controller
    {
        private readonly ICareersService _careersService;

        private static readonly string[] RestaurantPositions = new[]
        {
            "Cashier", "Kitchen Staff", "Shift Supervisor", "Store Manager", "Delivery Driver"
        };

        private static readonly string[] HeadOfficePositions = new[]
        {
            "Marketing Coordinator", "Finance Assistant", "Operations Support"
        };

        private static readonly string[] Locations = new[]
        {
            "Noosh Saxony Westwood Mall", "Noosh Florida Road", "Noosh Pavilion"
        };

        public CareersController(ICareersService careersService)
        {
            _careersService = careersService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.RestaurantPositions = RestaurantPositions;
            ViewBag.HeadOfficePositions = HeadOfficePositions;
            ViewBag.Locations = Locations;
            return View();
        }

        [HttpGet]
        public IActionResult Apply(string? position, string? location)
        {
            var model = new CareerApplicationViewModel();

            if (!string.IsNullOrWhiteSpace(position))
            {
                model.DesiredPosition = !string.IsNullOrWhiteSpace(location) && location != "Head Office"
                    ? $"{position} — {location}"
                    : position;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply(CareerApplicationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var allowedExtensions = new[] { ".pdf", ".docx" };
            var extension = Path.GetExtension(model.CvFile.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError("CvFile", "Please upload a PDF or Word (.docx) file.");
                return View(model);
            }

            const int maxFileSizeBytes = 5 * 1024 * 1024;
            if (model.CvFile.Length > maxFileSizeBytes)
            {
                ModelState.AddModelError("CvFile", "File is too large. Maximum size is 5MB.");
                return View(model);
            }

            var application = await _careersService.SubmitApplicationAsync(model, model.CvFile);
            return RedirectToAction("Confirmation", new { id = application.Id });
        }

        public IActionResult Confirmation(int id)
        {
            ViewBag.ApplicationId = id;
            return View();
        }
    }
}