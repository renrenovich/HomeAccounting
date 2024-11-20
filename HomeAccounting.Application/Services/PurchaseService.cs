using HomeAccounting.Application.Contracts;
using HomeAccounting.Data;
using HomeAccounting.DataAccess.Contracts;
using HomeAccounting.DataAccess.Repositories;
using HomeAccounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.Application.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IPurchaseRepository _purchaseRepository;

    public PurchaseService(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public async Task<Purchase> GetAsync(int id)
    {
        return await _purchaseRepository.GetAsync(id);
    }

    public async Task<IEnumerable<Purchase>> GetPurchasesAsync(int? creatorUserId)
    {
        return await _purchaseRepository.GetPurchasesAsync(creatorUserId);
    }
    
    public async Task<Purchase> CreateAsync(Purchase purchase)
    {
        return await _purchaseRepository.CreateAsync(purchase);
    }

    public async Task<Purchase> UpdateAsync(int creatorUserId, Purchase purchase)
    {
        var existingPurchase = await _purchaseRepository.GetAsync(purchase.Id);
        if (existingPurchase == null)
            throw new ArgumentException("Purchase is not found!");
        if(existingPurchase.CreatorUserId != creatorUserId 
            || existingPurchase.CreatorUserId != purchase.CreatorUserId)
            throw new ArgumentException("You are not allowed to do this action!");
        return await _purchaseRepository.UpdateAsync(purchase);
    }

    public async Task DeleteAsync(int id, int creatorUserId)
    {
        var purchase = await _purchaseRepository.GetAsync(id);
        if (purchase == null)
            throw new ArgumentException("Purchase is not found!");
        if (purchase.CreatorUserId != creatorUserId)
            throw new ArgumentException("You are not allowed to do this action!");
        await _purchaseRepository.DeleteAsync(purchase);
    }
}