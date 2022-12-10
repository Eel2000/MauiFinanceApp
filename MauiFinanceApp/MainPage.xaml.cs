using MauiFinanceApp.Pages;

namespace MauiFinanceApp;

public partial class MainPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    private void BtnStarted_OnClicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Login());
    }
}

