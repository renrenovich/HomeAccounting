using HomeAccounting.Application.Contracts;
using HomeAccounting.Data;
using HomeAccounting.DataAccess.Contracts;
using HomeAccounting.DataAccess.Repositories;
using HomeAccounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.Application.Services;

public class PurchaseCategoryService : IPurchaseCategoryService
{
    private readonly IPurchaseCategoryRepository _purchaseCategoryRepository;
    private readonly IPurchaseRepository _purchaseRepository;
    
    public PurchaseCategoryService(IPurchaseCategoryRepository purchaseCategoryRepository,
        IPurchaseRepository purchaseRepository)
    {
        _purchaseCategoryRepository = purchaseCategoryRepository;
        _purchaseRepository = purchaseRepository;
    }
    
    public async Task<PurchaseCategory> GetAsync(int id)
    {
        return await _purchaseCategoryRepository.GetAsync(id);
    }

    public async Task<IEnumerable<PurchaseCategory>> GetPurchaseCategoriesAsync()
    {
        return await _purchaseCategoryRepository.GetPurchasesCategoriesAsync();
    }

    public async Task<PurchaseCategory> CreateAsync(PurchaseCategory purchaseCategory)
    {
        return await _purchaseCategoryRepository.CreateAsync(purchaseCategory);
    }

    public async Task<PurchaseCategory> UpdateAsync(PurchaseCategory purchaseCategory)
    {
        await PurchaseCategoryValidate(purchaseCategory.Id);
        return await _purchaseCategoryRepository.UpdateAsync(purchaseCategory);
    }

    public async Task DeleteAsync(int id)
    {
        var existingPurchaseCategory =  await PurchaseCategoryValidate(id);
        await _purchaseCategoryRepository.DeleteAsync(existingPurchaseCategory);
    }

    private async Task<PurchaseCategory> PurchaseCategoryValidate(int id)
    {
        var existingPurchaseCategory = await _purchaseCategoryRepository.GetAsync(id);
        var isPurchaseCategoryInUse = await _purchaseRepository.isPurchaseCategoryInUseAsync(id);
        if (existingPurchaseCategory == null)
            throw new ArgumentException("PurchaseCategory is not found!");
        if(isPurchaseCategoryInUse)
            throw new ArgumentException("PurchaseCategory is in use!\nYou can`t do this action!");
        return existingPurchaseCategory;
    }
    
}