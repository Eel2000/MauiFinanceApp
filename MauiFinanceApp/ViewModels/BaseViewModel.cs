using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiFinanceApp.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title;

    [ObservableProperty]
    private bool _isBusy;
}

