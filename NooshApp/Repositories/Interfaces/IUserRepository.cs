using NooshApp.Models;

namespace NooshApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByPhoneNumberAsync(string phoneNumber);
        Task<User> CreateAsync(string phoneNumber);
        Task UpdateAsync(User user);
    }
}