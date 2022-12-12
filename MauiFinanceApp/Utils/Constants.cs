using MauiFinanceApp.Enums;

namespace MauiFinanceApp.Utils;

public class Constants
{
    public const bool LOGGED_IN = false;
    public const string LOGIN_MODE = "loginMode";

    public const string DatabaseFilename = "Wallet.db3";

    public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
}

