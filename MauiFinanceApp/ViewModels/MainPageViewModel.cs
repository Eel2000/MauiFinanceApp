using CommunityToolkit.Mvvm.Input;
using MauiFinanceApp.Pages;

namespace MauiFinanceApp.ViewModels;

public partial class MainPageViewModel : BaseViewModel
{


    [RelayCommand]
    void GetStarted()
    {
        App.Current.MainPage.Navigation.PushModalAsync(new Login());
    }
}

