using ReactiveUI;
using System;
using System.ComponentModel;
using System.Reactive;
using System.Diagnostics;
using Avalonia.Dialogs.Internal;

namespace BitCoinCalculator_new.ViewModels;

/*
 Based on:
 https://dev.to/abdul_rehman_2050/get-started-with-avalonia-ui-in-jetbrains-rider-ide-3joj
 */

public class MainWindowViewModel : ViewModelBase
{
    private string _username;
    public string Username
    {
        get => _username;
        set => this.RaiseAndSetIfChanged(ref _username, value);
    }

    private string _password;
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }

    private string _statusMessage;
    public string StatusMessage
    {
        get => _statusMessage;
        set => this.RaiseAndSetIfChanged(ref _statusMessage, value);
    }
    
    public ReactiveCommand<Unit, Unit> LoginCommand { get; }

    public MainWindowViewModel()
    {
        const string DUMMY_USERNAME = "admin";
        const string DUMMY_PASSWORD = "password123";

        LoginCommand = ReactiveCommand.Create(() =>
        {
            StatusMessage = string.Empty;
            
            // Simple validation check
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                StatusMessage = "Please enter both username and password.";
                Debug.WriteLine("Login failed: Empty credentials.");
                return;
            }
            
            // Dummy login logic
            if (Username.Equals(DUMMY_USERNAME, StringComparison.OrdinalIgnoreCase) && Password == DUMMY_PASSWORD)
            {
                StatusMessage = "Login successful!";
                Debug.WriteLine($"Login successful for user: {Username}");
                // You can add navigation or other logic here upon successful login
            }
            else
            {
                StatusMessage = "Invalid username or password.";
                Debug.WriteLine("Login failed: Invalid credentials.");
            }
        });
        
    }

    public BitcoinRates getRates()
    {
        return null;
    }
}