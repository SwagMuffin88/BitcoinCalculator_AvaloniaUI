using System;
using Avalonia.Input;
using BitCoinCalculator_new.ViewModels;
using ReactiveUI;
using ReactiveUI.Avalonia;

namespace BitCoinCalculator_new.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(disposables => { });
    }

    private void OnRegisterClicked(object? sender, PointerPressedEventArgs e)
    {
        Console.WriteLine("Register clicked");
    }
}