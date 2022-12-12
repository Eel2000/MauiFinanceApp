using MauiFinanceApp.DataAccess;
using MauiFinanceApp.ViewModels;

namespace MauiFinanceApp.Pages;

public partial class Login : ContentPage
{
    public Login(WalletDatabase database)
    {
        InitializeComponent();
        BindingContext = new LoginViewModel(database);
    }
}