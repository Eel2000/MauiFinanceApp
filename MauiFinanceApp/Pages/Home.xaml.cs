using MauiFinanceApp.ViewModels;

namespace MauiFinanceApp.Pages;

public partial class Home : ContentPage
{
	public Home(HomeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}