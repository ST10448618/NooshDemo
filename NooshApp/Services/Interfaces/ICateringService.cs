using NooshApp.Models;
using NooshApp.ViewModels;

namespace NooshApp.Services.Interfaces
{
    public interface ICateringService
    {
        Task<CateringRequest> SubmitRequestAsync(CateringRequestViewModel model);
        Task<CateringRequest?> GetByIdAsync(int id);
    }
}