using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NooshApp.Models;
using NooshApp.Services.Interfaces;
using NooshApp.ViewModels;

namespace NooshApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuService _menuService;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IMenuService menuService, IConfiguration configuration)
        {
            _logger = logger;
            _menuService = menuService;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel
            {
                FeaturedMeals = await _menuService.GetFeaturedMealsAsync(),
                StoreLocations = GetStoreLocations(),
                UberEatsUrl = _configuration["DeliveryLinks:UberEatsUrl"] ?? string.Empty,
                MrDUrl = _configuration["DeliveryLinks:MrDUrl"] ?? string.Empty
            };

            return View(viewModel);
        }

        private List<StoreLocation> GetStoreLocations()
        {
            return new List<StoreLocation>
            {
                new StoreLocation
                {
                    Name = "Noosh Saxony Westwood Mall",
                    MallName = "Saxony Westwood Mall",
                    Address = "Westwood Mall, Lincoln Terrace, Westville, Durban",
                    PhoneNumber = "087 226 6674",
                    OpeningHours = "Mon - Sun: 09:00 - 21:00",
                    MapEmbedUrl =  "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3461.248254569304!2d30.961017199999997!3d-29.8282552!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x1ef7019e07301083%3A0x17534deb24a7a4ad!2sNoosh%20Saxony%20Westwood%20Mall!5e0!3m2!1sen!2sza!4v1784144426551!5m2!1sen!2sza"
                },
                new StoreLocation
                {
                    Name = "Noosh Florida Road",
                    MallName = "Musgrave Centre",
                    Address = "279 Florida Rd, Windermere, Berea",
                    PhoneNumber = "087 226 6674",
                    OpeningHours = "Mon - Sun: 09:00 - 20:00",
                    MapEmbedUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3461.177084092737!2d31.012795600000008!3d-29.830309900000003!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x1ef707005debfad1%3A0xbda15fc83aa5af0c!2sNoosh%20Florida%20Road!5e0!3m2!1sen!2sza!4v1784145278083!5m2!1sen!2sza" 
                },
                new StoreLocation
                {
                    Name = "Noosh Pavilion",
                    MallName = "The Pavilion Shopping Centre",
                    Address = "5 Jack Martens Dr, Westville, Durban",
                    PhoneNumber = "087 226 6674",
                    OpeningHours = "Mon - Sun: 09:00 - 21:00",
                    MapEmbedUrl =  "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3460.562523287646!2d30.938385900000004!3d-29.848047!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x1ef701fc29e700a7%3A0xb7a8225019ec66b2!2sNoosh%20Pavilion%20Shopping%20Centre!5e0!3m2!1sen!2sza!4v1784145140210!5m2!1sen!2sza" 

                }
            };
        }

        public IActionResult Charity()
        {
            ViewBag.GalleryImages = GetCharityGalleryImages();
            ViewBag.DonationEmail = _configuration["BusinessContact:DonationEmail"];
            return View();
        }

        private List<string> GetCharityGalleryImages()
        {
            return new List<string>
            {
                "/images/charity/gallery-1.jpg",
                "/images/charity/gallery-2.jpg",
                "/images/charity/gallery-3.jpg",
                "/images/charity/gallery-4.jpg",
                "/images/charity/gallery-5.jpg",
                "/images/charity/gallery-6.jpg",
                "/images/charity/gallery-7.jpg"
            };
        }

        public IActionResult Contact() => View();
        public IActionResult Careers() => View();
        public IActionResult Terms() => View();
    }
}