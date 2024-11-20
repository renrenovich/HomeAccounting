namespace HomeAccounting.Application.Integrations.Commands;

public class ExchangePairResultResponse
{
    public string FromCurrency { get; set; }
    public string ToCurrency { get; set; }
    public double Amount { get; set; }
    public double ExchangedAmount { get; set; }
}