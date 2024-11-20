using System.Text.Json;
using HomeAccounting.Application.Integrations.Commands;
using HomeAccounting.Application.Integrations.Contracts;

namespace HomeAccounting.Application.Integrations.Services;

public class CurrencyExchangeService : ICurrencyExchangeService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _baseUrl;
    
    public CurrencyExchangeService(IHttpClientFactory httpClientFactory, string baseUrl)
    {
        _httpClientFactory = httpClientFactory;
        _baseUrl = baseUrl;
    }

    public async Task<ExchangePairResultResponse> ExchangePairAsync(ExchangeRequest request)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"{_baseUrl}/pair/{request.FromCurrency}/{request.ToCurrency}/{request.Amount}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Error fetching exchange rates.");
        }

        var content = await response.Content.ReadAsStringAsync();
        
        var exchangeRates = JsonSerializer.Deserialize<ExchangePairResponse>(content);
        

        if (!string.Equals(exchangeRates.base_code, request.FromCurrency, StringComparison.CurrentCultureIgnoreCase) ||
            !string.Equals(exchangeRates.target_code, request.ToCurrency, StringComparison.CurrentCultureIgnoreCase))
        {
            throw new KeyNotFoundException("Invalid currency code.");
        }

        
        double exchangedAmount = exchangeRates.conversion_result;

        return new ExchangePairResultResponse
        {
            FromCurrency = request.FromCurrency.ToUpper(),
            ToCurrency = request.ToCurrency.ToUpper(),
            Amount = request.Amount,
            ExchangedAmount = exchangedAmount
        };
    }
    
    public async Task<ExchangeRatesResultResponse> ExchangeRatesAsync(string currency)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"{_baseUrl}/latest/{currency}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Error fetching exchange rates.");
        }

        var content = await response.Content.ReadAsStringAsync();
        
        var exchangeRates = JsonSerializer.Deserialize<ExchangeRatesResponse>(content);
        

        if (!string.Equals(exchangeRates.base_code, currency, StringComparison.CurrentCultureIgnoreCase))
        {
            throw new KeyNotFoundException("Invalid currency code.");
        }

        return new ExchangeRatesResultResponse
        {
            Currency = currency.ToUpper(),
            Rates = exchangeRates.conversion_rates
        };
    }
    
}