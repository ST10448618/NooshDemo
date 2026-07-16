using NooshApp.Models;

namespace NooshApp.Repositories.Interfaces
{
    public interface ICateringRepository
    {
        Task AddAsync(CateringRequest request);
        Task<List<CateringRequest>> GetAllAsync();
        Task<CateringRequest?> GetByIdAsync(int id);
    }
}