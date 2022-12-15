using MauiFinanceApp.Controls;
using MauiFinanceApp.DataAccess;
using MauiFinanceApp.ViewModels;
using Microsoft.Maui.Platform;

namespace MauiFinanceApp;

public partial class App : Application
{
    public App(MainPageViewModel vm)
    {
        InitializeComponent();

        #region CumstomHandlers

        CustomEntryHandler();


        #endregion

        var logIn = Preferences.Get("LoggedIn", false);
        if (logIn is false)
        {
            MainPage = new MainPage(vm);
        }
        else
        {
            MainPage = new AppShell();
        }
    }

    /// <summary>
    /// Entry handler
    /// </summary>
    void CustomEntryHandler()
    {
#if ANDROID
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(CustomEntry), (handler, view) =>
        {
            if (view is CustomEntry)
            {
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
            }
        });
#endif
    }
}
