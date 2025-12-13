using System;
using System.Collections.ObjectModel;
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
    // private decimal _price;
    private string _result;
    private string? _currencyToken;
    
    public decimal BtcAmount 
    {
        get => _btcAmount;
        set => SetProperty(ref _btcAmount, value);
    }
    
    public string Result
    {
        get => _result;
        set => SetProperty(ref _result, value);
    }

    public string? CurrencyToken
    {
        get => _currencyToken;
        set => SetProperty(ref _currencyToken, value);
    }

    public ICommand CalculateCommand
    {
        get;
    }

    public ObservableCollection<string> TargetCurrencies { get; } =
    [
        "USD",
        "EUR",
        "GBP"
    ];
    
    public MainWindowViewModel(IBitcoinPriceService priceService)
    {
        CalculateCommand = new RelayCommand(async () =>
        { // TODO add result for missing currency token instead of exception
            // TODO add functionality to convert BTC to EEK
            try
            {
                var price = await priceService
                    .GetCurrentBtcPriceAsync("BTC-" + CurrencyToken);
                Result = 
                    $"{BtcAmount} BTC = {(BtcAmount * price):0.00} {CurrencyToken}";
            }
            catch (Exception e)
            {
                Result = "Invalid input";
                Console.WriteLine(e);
                throw;
            } 
        }); 
    }
    
}