using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiFinanceApp.DataAccess;
using MauiFinanceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiFinanceApp.ViewModels.Dialogs
{
    public partial class AddCardViewModel : BaseViewModel
    {
        private Action _action;
        private readonly WalletDatabase _database;

        [ObservableProperty] private string _name;
        [ObservableProperty] private decimal _amount;

        public AddCardViewModel(WalletDatabase database, Action action)
        {
            _database = database;
            _action = action;
        }

        [RelayCommand]
        async void AddCard()
        {
            if (Name != null && Amount > 0)
            {
                var card = new Card
                {
                    Amount = Amount,
                    Name = Name,
                    IsActive = true,
                    IsDefault = false,
                    Number = DateTime.Now.Ticks.ToString(),
                };

                var dialogResult = await Shell.Current.DisplayAlert("Wallet", "Would you like to set this card as default", "Yes", "Non");
                if (dialogResult)
                {
                    var oldDefaultCard = await _database.GetDefaultCardAsync();
                    if (oldDefaultCard != null)
                    {
                        oldDefaultCard.IsDefault = false;
                        await _database.UpdateCardAsync(oldDefaultCard);
                        card.IsDefault = true;
                        await _database.SaveCardAsync(card);
                    }
                    else
                    {
                        card.IsDefault = true;
                        await _database.SaveCardAsync(card);
                    }
                }
                else
                {

                    await _database.SaveCardAsync(card);
                }
                await Shell.Current.DisplayAlert("Wallet", $"new card added {Name}", "ok");
                _action.Invoke();
            }
            else
            {
                await Shell.Current.DisplayAlert("Wallet", "Pease fill the inputs", "ok");
            }
        }

    }
}
