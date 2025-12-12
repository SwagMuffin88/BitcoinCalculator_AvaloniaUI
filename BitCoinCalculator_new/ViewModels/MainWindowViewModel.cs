using System.Windows.Input;
using BitCoinCalculator_new.Services;
using CommunityToolkit.Mvvm.Input;

namespace BitCoinCalculator_new.ViewModels;

/*
 Based on:
 https://dev.to/abdul_rehman_2050/get-started-with-avalonia-ui-in-jetbrains-rider-ide-3joj
 */

public class MainWindowViewModel : ViewModelBase
{
    private decimal _btcAmount;
    private decimal _price;
    private string _result;
    
    public decimal BtcAmount {
        get => _btcAmount;
        set => SetProperty(ref _btcAmount, value);
    }
    
    public string Result
    {
        get => _result;
        set => SetProperty(ref _result, value);
    }

    public ICommand CalculateCommand
    {
        get;
    }

    private string _statusMessage;
    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }
    
    // public ReactiveCommand<Unit, Unit> LoginCommand { get; }

    public MainWindowViewModel(IBitcoinPriceService priceService)
    {
        CalculateCommand = new RelayCommand(async () =>
        {
            _price = await priceService.GetCurrentPriceBTCToUSDAsync();
            Result = $"{BtcAmount} BTC = {(BtcAmount * _price):0.00} USD";
            // TODO create functionality to convert to multiple currencies, also curr. to BTC
        });
        
        
    }

    /*public BitcoinRates getRates()
    {
        return null;
    }*/
}