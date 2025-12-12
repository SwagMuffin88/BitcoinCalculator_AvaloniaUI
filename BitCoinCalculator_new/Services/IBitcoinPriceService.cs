using System.Threading.Tasks;

public interface IBitcoinPriceService
{
    Task<decimal> GetCurrentPriceBTCToUSDAsync();
}