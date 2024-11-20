using HomeAccounting.Application.Commands;
using HomeAccounting.Domain.Entities;
using HomeAccounting.Domain.Enum;
using Report = HomeAccounting.Application.Commands.Report;

namespace HomeAccounting.Application.Contracts;

public interface IReportService
{
    Task<IEnumerable<Purchase>> GetMonthlyReportAsync(GetMonthlyReport request);
    Task<Report> GetPeriodReportAsync(GetPeriodReport request);
}