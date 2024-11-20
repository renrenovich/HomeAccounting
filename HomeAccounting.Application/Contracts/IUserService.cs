using HomeAccounting.Domain.Entities;

namespace HomeAccounting.Services;

public interface IUserService
{
    Task<User> GetAsync(int id);
    Task<User> CreateAsync(User user);
}
