﻿namespace HomeAccounting.Application.Integrations.Commands;

public class ExchangeRatesResponse
{
    public string result { get; set; }
    public string documentation { get; set; }
    public string terms_of_use { get; set; }
    public int time_last_update_unix { get; set; }
    public string time_last_update_utc { get; set; }
    public int time_next_update_unix { get; set; }
    public string time_next_update_utc { get; set; }
    public string base_code { get; set; }
    public Dictionary<string, double> conversion_rates { get; set; }
}