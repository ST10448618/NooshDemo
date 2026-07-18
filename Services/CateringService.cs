using NooshApp.Models;
using NooshApp.Repositories.Interfaces;
using NooshApp.Services.Interfaces;
using NooshApp.ViewModels;

namespace NooshApp.Services
{
    public class CateringService : ICateringService
    {
        private readonly ICateringRepository _cateringRepository;

        public CateringService(ICateringRepository cateringRepository)
        {
            _cateringRepository = cateringRepository;
        }

        public async Task<CateringRequest> SubmitRequestAsync(CateringRequestViewModel model)
        {
            var request = new CateringRequest
            {
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                EventDate = model.EventDate,
                GuestCount = model.GuestCount,
                EventLocation = model.EventLocation,
                AdditionalNotes = model.AdditionalNotes,
                Status = CateringStatus.New,
                SubmittedAt = DateTime.UtcNow
            };

            await _cateringRepository.AddAsync(request);
            return request;
        }

        public async Task<CateringRequest?> GetByIdAsync(int id)
        {
            return await _cateringRepository.GetByIdAsync(id);
        }
    }
}