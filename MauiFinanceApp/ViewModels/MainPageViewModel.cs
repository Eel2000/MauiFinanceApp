using MauiFinanceApp.Enums;
using MauiFinanceApp.Pages;
using MauiFinanceApp.Utils;
using CommunityToolkit.Mvvm.Input;
using MauiFinanceApp.DataAccess;

namespace MauiFinanceApp.ViewModels;

public partial class MainPageViewModel : BaseViewModel
{
    private readonly WalletDatabase _database;

    public MainPageViewModel(WalletDatabase database)
    {
        _database = database;
    }


    [RelayCommand]
    void GetStarted()
    {
        //TODO: login for connection in connected mode. ps: call a backend here.
        App.Current.MainPage.DisplayAlert("Wallet", "The connected mode is not yet available", "Ok");
        //App.Current.MainPage.Navigation.PushModalAsync(new Login());
        //Preferences.Set(Constants.LOGIN_MODE, LoginMode.CONNECTED.ToString());
    }

    [RelayCommand]
    async void DisconnectedMode()
    {
        Preferences.Set(Constants.LOGIN_MODE, LoginMode.DISCONNECTED.ToString());
        var dailog = await App.Current.MainPage.DisplayAlert("Wallet",
             "You will start using the app in a disconnected way without data sync to the cloud." +
             "do you still want to start?", "Start anyway", "Cancel");

        if (dailog)
            await Application.Current.MainPage.Navigation.PushAsync(new Login(_database));
    }
}

