using MauiFinanceApp.Enums;
using MauiFinanceApp.Pages;
using MauiFinanceApp.Utils;
using CommunityToolkit.Mvvm.Input;

namespace MauiFinanceApp.ViewModels;

public partial class MainPageViewModel : BaseViewModel
{


    [RelayCommand]
    void GetStarted()
    {
        //TODO: login for connection in connected mode. ps: call a backend here.
        App.Current.MainPage.DisplayAlert("Wallet", "The connected mode is not yet available", "Ok");
        //App.Current.MainPage.Navigation.PushModalAsync(new Login());
        //Preferences.Set(Constants.LOGIN_MODE, LoginMode.CONNECTED.ToString());
    }

    [RelayCommand]
    void DisconnectedMode()
    {
        Preferences.Set(Constants.LOGIN_MODE, LoginMode.DISCONNECTED.ToString());
        App.Current.MainPage.Navigation.PushModalAsync(new Login());
        //TODO:implement the login through the local db(sqlite).
    }
}

