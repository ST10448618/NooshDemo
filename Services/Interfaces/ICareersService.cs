using Microsoft.AspNetCore.Http;
using NooshApp.Models;
using NooshApp.ViewModels;

namespace NooshApp.Services.Interfaces
{
    public interface ICareersService
    {
        Task<Application> SubmitApplicationAsync(CareerApplicationViewModel model, IFormFile cvFile);
    }
}