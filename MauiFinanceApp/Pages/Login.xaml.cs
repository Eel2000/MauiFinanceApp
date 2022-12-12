namespace MauiFinanceApp.Pages;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void BtnLogin_OnClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync(true);
        App.Current.MainPage.Navigation.PushAsync(new AppShell());
    }
}