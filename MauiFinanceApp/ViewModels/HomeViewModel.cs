using CommunityToolkit.Mvvm.Input;

namespace MauiFinanceApp.ViewModels;

public partial class HomeViewModel : BaseViewModel
{

    [RelayCommand]
    void NavigateToStatistic()
    {
        Shell.Current.GoToAsync("/Analytics",true);
    }
}

