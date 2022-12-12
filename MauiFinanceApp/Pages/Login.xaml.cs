namespace MauiFinanceApp.Pages;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    private void BtnLogin_OnClicked(object sender, EventArgs e)
    {
        //TODO: add logic for local login
        Navigation.PopModalAsync(true);
        App.Current.MainPage = new AppShell();
        Preferences.Set("LoggedIn", true);
    }
}