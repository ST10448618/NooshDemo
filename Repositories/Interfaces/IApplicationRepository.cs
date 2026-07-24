using NooshApp.Models;

namespace NooshApp.Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        Task AddAsync(Application application);
        Task<List<Application>> GetAllAsync();
    }
}