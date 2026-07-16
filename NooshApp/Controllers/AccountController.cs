using Microsoft.AspNetCore.Mvc;
using NooshApp.Helpers;
using NooshApp.Services.Interfaces;
using NooshApp.ViewModels;

namespace NooshApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // If already logged in, skip straight to Rewards.
            if (HttpContext.Session.IsLoggedIn())
            {
                return RedirectToAction("Index", "Rewards");
            }

            return View(new PhoneLoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(PhoneLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var otp = await _authService.RequestOtpAsync(model.PhoneNumber);

            // SIMULATION ONLY: In production, remove this TempData line entirely —
            // the OTP would be sent via a real SMS provider (e.g. Twilio, Clickatell)
            // and never returned to the browser or displayed on screen.
            TempData["SimulatedOtp"] = otp;
            TempData["PhoneNumber"] = model.PhoneNumber;

            return RedirectToAction("VerifyOtp");
        }

        [HttpGet]
        public IActionResult VerifyOtp()
        {
            var phoneNumber = TempData["PhoneNumber"] as string;

            if (string.IsNullOrEmpty(phoneNumber))
            {
                // User landed here directly without requesting an OTP first.
                return RedirectToAction("Login");
            }

            // Keep values alive for the POST view too (TempData is single-read by default).
            TempData.Keep("PhoneNumber");
            TempData.Keep("SimulatedOtp");

            ViewBag.SimulatedOtp = TempData["SimulatedOtp"];

            return View(new VerifyOtpViewModel { PhoneNumber = phoneNumber });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyOtp(VerifyOtpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _authService.VerifyOtpAsync(model.PhoneNumber, model.Otp);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "That code is incorrect or has expired. Please try again.");
                return View(model);
            }

            HttpContext.Session.SetLoggedInUser(user.Id, user.PhoneNumber);

            return RedirectToAction("Index", "Rewards");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.ClearLoggedInUser();
            return RedirectToAction("Index", "Home");
        }
    }
}