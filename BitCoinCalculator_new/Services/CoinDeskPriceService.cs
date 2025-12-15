using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BitCoinCalculator_new.Services;

public class CoinDeskPriceService : IBitcoinPriceService
{
    private readonly HttpClient _http = new();

    public async Task<decimal> GetCurrentBtcPriceAsync(string currencyToken)
    {
        var json = await _http.GetStringAsync(
            "https://data-api.coindesk.com/index/cc/v1/latest/tick?market=cadli&instruments=BTC-USD,BTC-EUR,BTC-GBP&apply_mapping=true&api_key=287a1a4f8df941e85d346e1e04eb8d12603ba3459786036bb26714c835d95326");

        using var doc = JsonDocument.Parse(json);
        var result = new decimal(0);
        
        if (!doc.RootElement.TryGetProperty("Data", out var data))
            throw new Exception("API response missing 'Data'");

        if (currencyToken == "BTC-EEK")
        {
            if (!data.TryGetProperty("BTC-EUR", out var token))
                throw new Exception("Middle currency EUR price not found");
            
            var dataEEK = doc.RootElement.GetProperty("Data");
            var eurCurrencyJson = dataEEK.GetProperty("BTC-EUR");

            var eurValue = eurCurrencyJson.GetProperty("VALUE").GetDecimal();
            
            result = decimal.Multiply(eurValue, new decimal(15.64));
        }
        
        else
        {
            if (!data.TryGetProperty($"{currencyToken}", out var token))
                throw new Exception($"{currencyToken} price not found");
            
            data = doc.RootElement.GetProperty("Data");
            var currencyJson = data.GetProperty(currencyToken);
            
            result = currencyJson.GetProperty("VALUE").GetDecimal();
        }

        return result;
    }
    
}
