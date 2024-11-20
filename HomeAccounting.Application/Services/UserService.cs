using HomeAccounting.Data;
using HomeAccounting.DataAccess.Contracts;
using HomeAccounting.Domain.Entities;

namespace HomeAccounting.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateAsync(User user)
    {
        return await _userRepository.CreateAsync(user);
    }

    public async Task<User> GetAsync(int id)
    {
        return await _userRepository.GetAsync(id);
    }
}
