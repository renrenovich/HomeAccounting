namespace HomeAccounting.Application.Commands;

public class PurchaseByCategoryStatistic
{
    public string CategoryName { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Percentage { get; set; }
}