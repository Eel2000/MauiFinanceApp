﻿using CommunityToolkit.Maui;
using MauiFinanceApp.Controls;
using MauiFinanceApp.DataAccess;
using MauiFinanceApp.Pages;
using MauiFinanceApp.ViewModels;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using Mopups.Interfaces;
using Mopups.Services;

namespace MauiFinanceApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureMopups()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Unbounded-Bold.ttf", "UnboundBold");
                fonts.AddFont("Unbounded-Light.ttf", "UnboundLight");
            })
            .UseMauiCommunityToolkit();

        #region PageRegistration

        builder.Services.AddTransient<Home>();
        builder.Services.AddTransient<Login>();
        builder.Services.AddSingleton<Details>();
        builder.Services.AddSingleton<Wallet>();
        builder.Services.AddSingleton<Account>();
        #endregion

        #region ViewModelRegistration

        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<WalletViewModel>();
        builder.Services.AddTransient<AccountViewModel>();
        builder.Services.AddTransient<MainPageViewModel>();

        #endregion

        #region Custom
        builder.Services.AddSingleton<PanContainer>(); 
        #endregion

        #region Service&DatabaseAccesRegitration

        builder.Services.AddSingleton<WalletDatabase>();

        #endregion


        #region Lib
        builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);
        #endregion

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
