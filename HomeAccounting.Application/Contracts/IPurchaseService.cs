using HomeAccounting.Domain.Entities;

namespace HomeAccounting.Application.Contracts;

public interface IPurchaseService
{
    Task<Purchase> GetAsync(int id);
    Task<IEnumerable<Purchase>> GetPurchasesAsync(int? creatorUserId);
    Task<Purchase> CreateAsync(Purchase purchase);
    Task<Purchase> UpdateAsync(int creatorUserId, Purchase purchase);
    Task DeleteAsync(int id, int creatorUserId);
}