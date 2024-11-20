using HomeAccounting.Domain.Entities;

namespace HomeAccounting.DataAccess.Contracts;

public interface IUserRepository
{
    Task<User> GetAsync(int id);
    Task<User> CreateAsync(User user);
    Task<Dictionary<int, string>> GetUsersByIdsAsync(IEnumerable<int> userIds);
}