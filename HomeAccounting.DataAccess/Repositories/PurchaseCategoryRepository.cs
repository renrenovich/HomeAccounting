using HomeAccounting.Data;
using HomeAccounting.DataAccess.Contracts;
using HomeAccounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.DataAccess.Repositories;

public class PurchaseCategoryRepository : IPurchaseCategoryRepository
{
    private readonly HomeAccountingDbContext _context;

    public PurchaseCategoryRepository(HomeAccountingDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<PurchaseCategory> GetAsync(int id)
    {
        return await _context.PurchaseCategory.FindAsync(id);
    }

    public async Task<IEnumerable<PurchaseCategory>> GetPurchasesCategoriesAsync()
    {
        return await _context.PurchaseCategory.ToListAsync();
    }
    
    public async Task<PurchaseCategory> CreateAsync(PurchaseCategory purchaseCategory)
    {
        _context.PurchaseCategory.Add(purchaseCategory);
        await _context.SaveChangesAsync();
        return purchaseCategory;
    }

    public async Task<PurchaseCategory> UpdateAsync(PurchaseCategory purchaseCategory)
    {
        _context.PurchaseCategory.Update(purchaseCategory);
        await _context.SaveChangesAsync();
        return purchaseCategory;
    }

    public async Task DeleteAsync(PurchaseCategory purchaseCategory)
    {
        _context.PurchaseCategory.Remove(purchaseCategory);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Dictionary<int, string>> GetPurchaseCategoriesByIdsAsync(IEnumerable<int> categoryIds)
    {
        return await _context.PurchaseCategory
            .Where(c => categoryIds.Contains(c.Id))
            .ToDictionaryAsync(c => c.Id, c => c.Name);
    }
    
    
}