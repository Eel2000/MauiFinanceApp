using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiFinanceApp.DataAccess;
using MauiFinanceApp.Models;
using MauiFinanceApp.Pages;

namespace MauiFinanceApp.ViewModels;

public partial class AccountViewModel : BaseViewModel
{
    private readonly WalletDatabase _database;
    private readonly MainPageViewModel _mainPageViewModel;

    [ObservableProperty]
    private User _connectedUser;

    public AccountViewModel(WalletDatabase database, MainPageViewModel mainPageViewModel)
    {
        _database = database;
        _mainPageViewModel = mainPageViewModel;

        InitDataAsync();
    }

    /// <summary>
    /// Initialize the user(connected) data
    /// </summary>
    async void InitDataAsync()
    {
        var user = await _database.GetConnectedUserAsync();
        if (user is not null)
            ConnectedUser = user;
        else
        {
            Disconnect();
        }
    }

    [RelayCommand]
    async void Disconnect()
    {
        try
        {
            var canDisconnect = await Shell.Current.DisplayAlert("Wallet",
                "All you data will be clean up. Do you still want to disconnect?",
                "Continue", "Cancel");
            if (canDisconnect)
            {
                var deleted = await _database.RemoveUserAsync();
                if (deleted)
                {
                    Preferences.Clear();
                    App.Current.MainPage = new MainPage(_mainPageViewModel);
                    await App.Current.MainPage.Navigation.PushModalAsync(new Login(_database));
                    return;
                }

                await Shell.Current.DisplayAlert("Wallet", "We ancounter a issue when processing to the deconnection", "ok"); 
            }
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlert("Wallet", "We ancounter a issue when processing to the deconnection", "ok");
            Debug.WriteLine("disconnectionError",e);
        }
        //TODO: use the mvvmToolkit taost for alerts
    }

    //TODO: Need to add here the ability to sync data, by switching from disconnected
    //TODO: to connected mode and then sync the current account with the cloud api.
    //TODO: replace all alert by communityToolkit toast
}

