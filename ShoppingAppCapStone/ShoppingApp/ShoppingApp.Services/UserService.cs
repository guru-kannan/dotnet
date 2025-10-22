using ShoppingApp.Entities;
using ShoppingApp.Repositories;

namespace ShoppingApp.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User?> GetUserByIdAsync(string id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task CreateUserAsync(User user)
    {
        // Check if username already exists
        var existingUser = await _userRepository.FindByUsernameAsync(user.Username);
        if (existingUser != null)
        {
            throw new Exception("Username already exists.");
        }

        // For demonstration, let's assume the password is passed in plain text
        var plainPassword = user.PasswordHash; // In real scenarios, use a separate field for plain password
        if (string.IsNullOrWhiteSpace(plainPassword) || plainPassword.Length < 6)
        {
            throw new Exception("Password must be at least 6 characters long.");
        }
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword);

        await _userRepository.CreateAsync(user);
    }
    
    public async Task<bool> ValidateUserCredentialsAsync(string username, string inputPassword)
    {
        var user = await _userRepository.FindByUsernameAsync(username);
        if (user == null)
            return false;

        // Verify password
        return BCrypt.Net.BCrypt.Verify(inputPassword, user.PasswordHash);
    }

    public async Task UpdateUserAsync(string id, User user)
    {
        await _userRepository.UpdateAsync(id, user);
    }

    public async Task DeleteUserAsync(string id)
    {
        await _userRepository.DeleteAsync(id);
    }
}