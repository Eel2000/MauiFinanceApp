using MauiFinanceApp.ViewModels;

namespace MauiFinanceApp.Pages;

public partial class Account : ContentPage
{
	public Account(AccountViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}