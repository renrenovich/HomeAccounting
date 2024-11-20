using HomeAccounting.Application.Commands;
using HomeAccounting.Application.Contracts;
using HomeAccounting.Data;
using HomeAccounting.DataAccess.Contracts;
using HomeAccounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Report = HomeAccounting.Application.Commands.Report;

namespace HomeAccounting.Application.Services;

public class ReportService : IReportService
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IPurchaseCategoryRepository _purchaseCategoryRepository;
    private readonly IUserRepository _userRepository;

    public ReportService(IPurchaseRepository purchaseRepository, 
        IPurchaseCategoryRepository purchaseCategoryRepository,
        IUserRepository userRepository)
    {
        _purchaseRepository = purchaseRepository;
        _purchaseCategoryRepository = purchaseCategoryRepository;
        _userRepository = userRepository;
    }
    

    public async Task<IEnumerable<Purchase>> GetMonthlyReportAsync(GetMonthlyReport request)
    {
        var startDate = new DateTimeOffset(new DateTime(request.Year, (int)request.Month, 1));
        var endDate = startDate.AddMonths(1).AddDays(-1);
        
        var purchases = await _purchaseRepository.GetReportAsync(startDate, 
            endDate, request.CreatorUserId, request.CategoryId);
        
        return purchases;
    }

    
    public async Task<Report> GetPeriodReportAsync(GetPeriodReport request)
    {
        var purchases = await _purchaseRepository.GetReportAsync(request.FromDate, 
            request.ToDate, request.CreatorUserId, request.CategoryId);
        
        var categoryIds = purchases.Select(e => e.CategoryId).Distinct();
        var categories = await _purchaseCategoryRepository.GetPurchaseCategoriesByIdsAsync(categoryIds);
        var totalAmount = (decimal)purchases.Sum(e => e.Amount);
        var purchaseByCategoryStatistics = purchases
            .GroupBy(e => e.CategoryId)
            .Select(g => new PurchaseByCategoryStatistic
            {
                CategoryName = categories.ContainsKey(g.Key) ? categories[g.Key] : "Unknown",
                TotalAmount = g.Sum(e => e.Amount),
                Percentage = decimal.Round(g.Sum(e => e.Amount) / totalAmount * 100, 2)
            }).ToList();
        var userIds = purchases.Select(e => e.CreatorUserId).Distinct();
        var users = await _userRepository.GetUsersByIdsAsync(userIds);
        var purchaseByUserStatistics = purchases
            .GroupBy(p => p.CreatorUserId)
            .Select(g => new PurchaseByUserStatistic
            {
                UserName = users.ContainsKey(g.Key) ? users[g.Key] : "Unknown",
                TotalAmount = g.Sum(p => p.Amount)
            })
            .ToList();
        var report = new Report
        {
            PurchaseByCategoryStatistics = purchaseByCategoryStatistics,
            PurchaseByUserStatistics = purchaseByUserStatistics
        };
        
        return report;
    }
}