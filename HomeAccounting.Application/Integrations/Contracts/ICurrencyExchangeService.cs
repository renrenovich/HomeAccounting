using HomeAccounting.Application.Integrations.Commands;

namespace HomeAccounting.Application.Integrations.Contracts;

public interface ICurrencyExchangeService
{
    Task<ExchangePairResultResponse> ExchangePairAsync(ExchangeRequest request);
    Task<ExchangeRatesResultResponse> ExchangeRatesAsync(string currency);
}