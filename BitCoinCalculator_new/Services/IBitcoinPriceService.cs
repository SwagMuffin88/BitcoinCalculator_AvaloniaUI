using System.Threading.Tasks;

namespace BitCoinCalculator_new.Services;

public interface IBitcoinPriceService
{
    Task<decimal> GetCurrentBtcPriceAsync(string currencyToken);
}