using HomeAccounting.Domain.Entities;

namespace HomeAccounting.Application.Contracts;

public interface IPurchaseCategoryService
{
    Task<PurchaseCategory> GetAsync(int id);
    Task<IEnumerable<PurchaseCategory>> GetPurchaseCategoriesAsync();
    Task<PurchaseCategory> CreateAsync(PurchaseCategory purchaseCategory);
    Task<PurchaseCategory> UpdateAsync(PurchaseCategory purchaseCategory);
    Task DeleteAsync(int id);
}