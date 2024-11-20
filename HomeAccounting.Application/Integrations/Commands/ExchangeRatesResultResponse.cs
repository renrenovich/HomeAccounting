namespace HomeAccounting.Application.Integrations.Commands;

public class ExchangeRatesResultResponse
{
    public string Currency { get; set; }
    public Dictionary<string, double> Rates { get; set; }
}