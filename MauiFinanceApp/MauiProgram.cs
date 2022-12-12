using MauiFinanceApp.Pages;
using Microsoft.Extensions.Logging;

namespace MauiFinanceApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<Home>();
        builder.Services.AddTransient<Login>();
        builder.Services.AddSingleton<Details>();
        builder.Services.AddSingleton<Wallet>();
        builder.Services.AddSingleton<Account>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
