using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiFinanceApp.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    [ObservableProperty]
    private string username;

    [ObservableProperty]
    private string password;

    public LoginViewModel()
    {

    }

    [RelayCommand]
    void LoginCommand()
    {
        App.Current.MainPage.Navigation.PopModalAsync(true);
        App.Current.MainPage = new AppShell();
        Preferences.Set("LoggedIn", true);
    }
}

