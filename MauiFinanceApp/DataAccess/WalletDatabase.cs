using MauiFinanceApp.Models;
using MauiFinanceApp.Utils;
using SQLite;

namespace MauiFinanceApp.DataAccess
{
    public class WalletDatabase
    {
        SQLiteAsyncConnection Database;

        public WalletDatabase()
        {
            InitAsync();
        }

        /// <summary>
        /// Init database by creating or not the table if it's already done.
        /// </summary>
        async void InitAsync()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

            await Database.CreateTableAsync<User>();
        }

        #region UserOps

        public async ValueTask SaveUserAsync(User user)
            => await Database.InsertOrReplaceAsync(user);

        public async ValueTask<User> GetConnectedUserAsync()
            => await Database.Table<User>().FirstOrDefaultAsync();

        public async ValueTask<bool> RemoveUserAsync()
        {
            var user = await Database.Table<User>().FirstOrDefaultAsync();
            if (user is not null)
            {
                var result = await Database.DeleteAsync<User>(user);
                return result > 0;
            }

            return false;
        }
        #endregion
    }

}
