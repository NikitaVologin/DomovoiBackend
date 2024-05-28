using DomovoiBackend.AuthService.Models;

namespace DomovoiBackend.AuthService.Persistence.Repositories;

public interface IUserRepository
{
    Task<User> GetUserAsync(string email, string password);
    Task<Guid> AddUserAsync(User user);
    Task<bool> IsUserExistAsync(string email);
}