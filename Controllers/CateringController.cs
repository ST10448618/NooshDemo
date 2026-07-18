using Microsoft.AspNetCore.Mvc;
using NooshApp.Services.Interfaces;
using NooshApp.ViewModels;

namespace NooshApp.Controllers
{
    public class CateringController : Controller
    {
        private readonly ICateringService _cateringService;
        private readonly IConfiguration _configuration;

        public CateringController(ICateringService cateringService, IConfiguration configuration)
        {
            _cateringService = cateringService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Request()
        {
            ViewBag.WhatsAppNumber = _configuration["BusinessContact:WhatsAppNumber"];
            return View(new CateringRequestViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Request(CateringRequestViewModel model)
        {
            if (model.EventDate.Date < DateTime.Today)
            {
                ModelState.AddModelError(nameof(model.EventDate), "Event date cannot be in the past.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var request = await _cateringService.SubmitRequestAsync(model);

            return RedirectToAction("Confirmation", new { id = request.Id });
        }

        public async Task<IActionResult> Confirmation(int id)
        {
            var request = await _cateringService.GetByIdAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            ViewBag.RequestId = request.Id;
            ViewBag.WhatsAppNumber = _configuration["BusinessContact:WhatsAppNumber"];
            ViewBag.WhatsAppMessage = BuildWhatsAppMessage(request);

            return View();
        }

        private string BuildWhatsAppMessage(Models.CateringRequest request)
        {
            var message = $"Hi Noosh! I've just submitted a catering request (Ref #{request.Id}).\n\n" +
                        $"Name: {request.FullName}\n" +
                        $"Event Date: {request.EventDate:dd MMM yyyy}\n" +
                        $"Guests: {request.GuestCount}\n" +
                        $"Location: {request.EventLocation}\n";

            if (!string.IsNullOrWhiteSpace(request.AdditionalNotes))
            {
                message += $"Additional Notes: {request.AdditionalNotes}\n";
            }

            message += "\nLooking forward to hearing from you!";

            return Uri.EscapeDataString(message);
        }
    }
}