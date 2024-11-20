using HomeAccounting.Data;
using HomeAccounting.DataAccess.Contracts;
using HomeAccounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.DataAccess.Repositories;

public class PurchaseRepository : IPurchaseRepository
{
    private readonly HomeAccountingDbContext _context;

    public PurchaseRepository(HomeAccountingDbContext context)
    {
        _context = context;
    }
    public async Task<Purchase> GetAsync(int id)
    {
        return await _context.Purchase.FindAsync(id);
    }
    
    public async Task<IEnumerable<Purchase>> GetPurchasesAsync(int? creatorUserId)
    {
        if(creatorUserId != null)
            return await _context.Purchase.Where(e => e.CreatorUserId == creatorUserId).ToListAsync();
        return await _context.Purchase.ToListAsync();
    }
    
    public async Task<Purchase> CreateAsync(Purchase purchase)
    {
        _context.Purchase.Add(purchase);
        await _context.SaveChangesAsync();
        return purchase;
    }

    public async Task<Purchase> UpdateAsync(Purchase purchase)
    {
        _context.Purchase.Update(purchase);
        await _context.SaveChangesAsync();
        return purchase;
    }

    public async Task DeleteAsync(Purchase purchase)
    {
            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();
    }

    public async Task<bool> isPurchaseCategoryInUseAsync(int id)
    {
        return await _context.Purchase.AnyAsync(e => e.CategoryId == id);
    }
    
    public async Task<List<Purchase>> GetReportAsync(DateTimeOffset fromDate, DateTimeOffset toDate, int? creatorUserId, int? categoryId)
    {
        return await _context.Purchase
            .Where(p => p.Date >= fromDate.ToUniversalTime() && p.Date <= toDate.ToUniversalTime() &&
                        (creatorUserId == null || p.CreatorUserId == creatorUserId) &&
                        (categoryId == null || p.CategoryId == categoryId))
            .ToListAsync();
    }
}