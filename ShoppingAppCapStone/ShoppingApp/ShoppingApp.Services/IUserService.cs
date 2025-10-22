using ShoppingApp.Entities;
using ShoppingApp.Repositories;

namespace ShoppingApp.Services;

public interface IUserService
{
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(string id);
    Task CreateUserAsync(User user);
    Task<bool> ValidateUserCredentialsAsync(string username, string inputPassword);
    Task UpdateUserAsync(string id, User user);
    Task DeleteUserAsync(string id);
}