using HomeAccounting.Domain.Entities;

namespace HomeAccounting.DataAccess.Contracts;

public interface IPurchaseRepository
{
    Task<Purchase> GetAsync(int id);
    Task<IEnumerable<Purchase>> GetPurchasesAsync(int? creatorUserId);
    Task<Purchase> CreateAsync(Purchase purchase);
    Task<Purchase> UpdateAsync(Purchase purchase);
    Task DeleteAsync(Purchase purchase);
    Task<bool> isPurchaseCategoryInUseAsync(int id);
    Task<List<Purchase>> GetReportAsync(DateTimeOffset fromDate, DateTimeOffset toDate, int? creatorUserId,
        int? categoryId);
}