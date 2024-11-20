namespace HomeAccounting.Application.Commands;

public record GetPeriodReport
{
    public DateTime FromDate { get; init; }
    public DateTime ToDate { get; init; }
    public int? CreatorUserId { get; init; }
    public int? CategoryId { get; init; }
}