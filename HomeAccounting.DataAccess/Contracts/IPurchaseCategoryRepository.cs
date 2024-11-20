using HomeAccounting.Domain.Entities;

namespace HomeAccounting.DataAccess.Contracts;

public interface IPurchaseCategoryRepository
{
     Task<PurchaseCategory> GetAsync(int id);

     Task<IEnumerable<PurchaseCategory>> GetPurchasesCategoriesAsync();

     Task<PurchaseCategory> CreateAsync(PurchaseCategory purchaseCategory);

     Task<PurchaseCategory> UpdateAsync(PurchaseCategory purchaseCategory);

     Task DeleteAsync(PurchaseCategory purchaseCategory);

     Task<Dictionary<int, string>> GetPurchaseCategoriesByIdsAsync(IEnumerable<int> categoryIds);
}