namespace HomeAccounting.Application.Commands;

public class Report
{
    public List<PurchaseByCategoryStatistic> PurchaseByCategoryStatistics { get; set; }
    public List<PurchaseByUserStatistic> PurchaseByUserStatistics { get; set; }
}