using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiFinanceApp.DataAccess;
using MauiFinanceApp.Models;

namespace MauiFinanceApp.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private readonly WalletDatabase _database;

    [ObservableProperty]
    private string username;

    [ObservableProperty]
    private string password;

    public LoginViewModel(WalletDatabase database)
    {
        _database = database;
    }

    [RelayCommand]
    async void LoginCommand()
    {
        var newUser = new User
        {
            Username = Username,
            Password = Password
        };
        await _database.SaveUserAsync(newUser);
        await App.Current.MainPage.Navigation.PopModalAsync(true);
        App.Current.MainPage = new AppShell();
        Preferences.Set("LoggedIn", true);
    }
}

