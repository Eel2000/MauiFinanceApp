using MauiFinanceApp.ViewModels;

namespace MauiFinanceApp.Pages;

public partial class Wallet : ContentPage
{
	public Wallet(WalletViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}