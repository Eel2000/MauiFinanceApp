using MauiFinanceApp.Controls;
using Microsoft.Maui.Platform;

namespace MauiFinanceApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        #region CumstomHandlers

        CustomEntryHandler();


        #endregion

        //var logIn = Preferences.Get("LoggedIn", false);
        //if (logIn is false)
        //{
        MainPage = new MainPage();
        //}
        //else
        //{
        //    MainPage = new AppShell();
        //}
    }

    /// <summary>
    /// Entry handler
    /// </summary>
    void CustomEntryHandler()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(CustomEntry), (handler, view) =>
        {
            if (view is CustomEntry)
            {
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
            }
        });
    }
}
