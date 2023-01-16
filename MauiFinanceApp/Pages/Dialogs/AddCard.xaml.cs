using MauiFinanceApp.DataAccess;
using MauiFinanceApp.ViewModels.Dialogs;

namespace MauiFinanceApp.Pages.Dialogs;

public partial class AddCard
{
    public AddCard(WalletDatabase db, Action action = null)
    {
        InitializeComponent();
        BindingContext = new AddCardViewModel(db, action);
    }
}