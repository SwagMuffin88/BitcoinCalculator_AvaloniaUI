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
    private static string[] _currencies = ["USD", "EUR", "GBP", "EEK"];
    private string? _currencyToken;
        // = Currencies[0];
    private decimal _btcAmount;
    private string _result;
    
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

    public ObservableCollection<string> TargetCurrencies  => 
        new ObservableCollection<string>(_currencies);
    
    public MainWindowViewModel(IBitcoinPriceService priceService)
    {
        CalculateCommand = new RelayCommand(async () =>
        {
            try
            {
                if (string.IsNullOrEmpty(CurrencyToken)) {
                    Result = "Please select a currency";
                    return;
                }
                
                var price = await priceService
                    .GetCurrentBtcPriceAsync("BTC-" + CurrencyToken);
                Result = 
                    $"{BtcAmount} BTC = {(BtcAmount * price):0.00} {CurrencyToken}";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            } 
        }); 
    }
    
}