using MauiFinanceApp.Pages.Dialogs;
using MauiFinanceApp.ViewModels;
using OverSheet;

namespace MauiFinanceApp.Pages;

public partial class Details : ContentPage
{
	public Details(DetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		Shell.Current.DisplayAlert("Wallet", "test", "OK");
    }
}