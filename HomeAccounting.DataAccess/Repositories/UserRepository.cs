using HomeAccounting.Data;
using HomeAccounting.DataAccess.Contracts;
using HomeAccounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly HomeAccountingDbContext _context;

    public UserRepository(HomeAccountingDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> CreateAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> GetAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
    
    public async Task<Dictionary<int, string>> GetUsersByIdsAsync(IEnumerable<int> userIds)
    {
        return await _context.Users
            .Where(c => userIds.Contains(c.Id))
            .ToDictionaryAsync(c => c.Id, c => c.Name);
    }
}