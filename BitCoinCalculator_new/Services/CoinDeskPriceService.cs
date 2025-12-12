using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BitCoinCalculator_new.Services;

public class CoinDeskPriceService : IBitcoinPriceService
{
    private readonly HttpClient _http = new();

    public async Task<decimal> GetCurrentPriceBTCToUSDAsync()   // TODO expand to other currencies
    {
        var json = await _http.GetStringAsync(
            "https://data-api.coindesk.com/index/cc/v1/latest/tick?market=cadli&instruments=BTC-USD,BTC-EUR&apply_mapping=true&api_key=287a1a4f8df941e85d346e1e04eb8d12603ba3459786036bb26714c835d95326");

        using var doc = JsonDocument.Parse(json);
        
        if (!doc.RootElement.TryGetProperty("Data", out var data))
            throw new Exception("API response missing 'Data'");

        if (!data.TryGetProperty("BTC-USD", out var btcUsd))
            throw new Exception("BTC-USD price not found");

        if (!btcUsd.TryGetProperty("VALUE", out var priceToken))
            throw new Exception("VALUE not found in BTC-USD object");

        return doc.RootElement
            .GetProperty("Data")
            .GetProperty("BTC-USD")
            .GetProperty("VALUE")
            .GetDecimal();
    }
}
