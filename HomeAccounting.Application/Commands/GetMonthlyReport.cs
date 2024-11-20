using HomeAccounting.Domain.Enum;

namespace HomeAccounting.Application.Commands;

public record GetMonthlyReport
{
    public int Year { get; init; }
    public Month Month { get; init; }
    public int? CreatorUserId { get; init; }
    public int? CategoryId { get; init; }
}