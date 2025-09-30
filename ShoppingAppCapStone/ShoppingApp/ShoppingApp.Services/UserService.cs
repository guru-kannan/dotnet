using ShoppingApp.Entities;
using ShoppingApp.Repositories;

namespace ShoppingApp.Services;

public class UserService: IUserService
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
        await _userRepository.CreateAsync(user);
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