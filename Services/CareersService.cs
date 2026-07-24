using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NooshApp.Helpers;
using NooshApp.Models;
using NooshApp.Repositories.Interfaces;
using NooshApp.Services.Interfaces;
using NooshApp.ViewModels;

namespace NooshApp.Services
{
    public class CareersService : ICareersService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IWebHostEnvironment _environment;

        private static readonly string[] ScreeningKeywords = new[]
        {
            "customer service", "restaurant", "kitchen", "management",
            "cooking", "hospitality", "cashier", "pos", "food safety", "communication"
        };

        private const int ShortlistThreshold = 3;

        public CareersService(IApplicationRepository applicationRepository, IWebHostEnvironment environment)
        {
            _applicationRepository = applicationRepository;
            _environment = environment;
        }

        public async Task<Application> SubmitApplicationAsync(CareerApplicationViewModel model, IFormFile cvFile)
        {
            var savedPath = await SaveCvFileAsync(cvFile);
            var cvText = CvTextExtractor.ExtractText(savedPath);
            var score = ScoreCvText(cvText);

            var application = new Application
            {
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                DesiredPosition = model.DesiredPosition,
                CoverLetter = model.CoverLetter,
                CvFilePath = GetRelativePath(savedPath),
                CvOriginalFileName = cvFile.FileName,
                KeywordScore = score,
                Status = score >= ShortlistThreshold ? ApplicationStatus.Shortlisted : ApplicationStatus.Rejected,
                SubmittedAt = DateTime.UtcNow
            };

            await _applicationRepository.AddAsync(application);
            return application;
        }

        private async Task<string> SaveCvFileAsync(IFormFile cvFile)
        {
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "cvs");
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{cvFile.FileName}";
            var fullPath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await cvFile.CopyToAsync(stream);
            }

            return fullPath;
        }

        private string GetRelativePath(string fullPath)
        {
            var relative = Path.GetRelativePath(_environment.WebRootPath, fullPath);
            return "/" + relative.Replace("\\", "/");
        }

        private int ScoreCvText(string cvText)
        {
            if (string.IsNullOrWhiteSpace(cvText))
            {
                return 0;
            }

            var lowerText = cvText.ToLowerInvariant();
            return ScreeningKeywords.Count(keyword => lowerText.Contains(keyword));
        }
    }
}