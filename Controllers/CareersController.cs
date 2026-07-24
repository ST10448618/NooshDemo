using Microsoft.AspNetCore.Mvc;
using NooshApp.Services.Interfaces;
using NooshApp.ViewModels;

namespace NooshApp.Controllers
{
    public class CareersController : Controller
    {
        private readonly ICareersService _careersService;

        public CareersController(ICareersService careersService)
        {
            _careersService = careersService;
        }

        [HttpGet]
        public IActionResult Apply()
        {
            return View(new CareerApplicationViewModel());
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