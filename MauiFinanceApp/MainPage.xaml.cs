using MauiFinanceApp.Pages;
using MauiFinanceApp.ViewModels;

namespace MauiFinanceApp;

public partial class MainPage
{

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }
}

