using MauiFinanceApp.ViewModels;

namespace MauiFinanceApp.Pages;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}