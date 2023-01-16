using System.Collections.ObjectModel;
using Android.OS;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiFinanceApp.DataAccess;
using MauiFinanceApp.Models;
using MauiFinanceApp.Pages.Dialogs;
using Mopups.Services;
using OverSheet;

namespace MauiFinanceApp.ViewModels;

public partial class WalletViewModel : BaseViewModel
{
    private readonly WalletDatabase _database;


    [ObservableProperty] private ObservableCollection<Card> _cards = new();
    //[ObservableProperty] private ObservableCollection<Operation> _operations = new();
    [ObservableProperty] private ObservableCollection<Budget> _budgets = new();

    [ObservableProperty] private decimal _amount;
    [ObservableProperty] private Card _selectedCard;

    public WalletViewModel(WalletDatabase database)
    {
        _database = database;
        InitializeWalletDataAsync();
    }

    void InitDefaultData()
    {
        Cards = new()
        {
            new()
            {
                Id = 1,
                Amount = 2000,
                ExpiryDate = DateTimeOffset.Now.AddYears(5),
                Name = "Carol Denver",
                Number ="XXXXXXXXXXX8976"
            },
            new()
            {
                Id = 2,
                Amount = 4000,
                ExpiryDate = DateTimeOffset.Now.AddYears(5),
                Name = "John Idea",
                Number = "XXXXXXXXXXX8936"
            },
            new()
            {
                Id = 3,
                Amount = 6000,
                ExpiryDate = DateTimeOffset.Now.AddYears(5),
                Name = "Ariette Bill",
                Number = "XXXXXXXXXXX8956"
            },
        };

        //Operations = new()
        //{
        //    new()
        //    {
        //        Id = 1,
        //        CardId = 1,
        //        IsDeleted = false,
        //        Amount = 250
        //    },
        //    new()
        //    {
        //        Id = 1,
        //        CardId = 2,
        //        IsDeleted = false,
        //        Amount = 250
        //    },
        //    new()
        //    {
        //        Id = 1,
        //        CardId = 3,
        //        IsDeleted = false,
        //        Amount = 250
        //    },
        //    new()
        //    {
        //        Id = 1,
        //        CardId = 1,
        //        IsDeleted = false,
        //        Amount = 250
        //    },
        //    new()
        //    {
        //        Id = 1,
        //        CardId = 2,
        //        IsDeleted = false,
        //        Amount = 250
        //    },
        //    new()
        //    {
        //        Id = 1,
        //        CardId = 3,
        //        IsDeleted = false,
        //        Amount = 250
        //    },
        //};

        Budgets = new()
        {
            new()
            {
                Id = 1,
                IsActive = true,
                Start = DateTimeOffset.Now,
                End = DateTimeOffset.Now.AddDays(12),
                DedicatedAmount = 50M,
                Description = "Budget for transport",
                HasReachLimit = false,
                Name = "Transport"
            },
            new()
            {
                Id = 2,
                IsActive = true,
                Start = DateTimeOffset.Now,
                End = DateTimeOffset.Now.AddDays(5),
                DedicatedAmount = 50M,
                Description = "Budget for found",
                HasReachLimit = false,
                Name = "Founds"
            },
        };
    }

    async void InitializeWalletDataAsync()
    {
        try
        {
            var rawCards = await _database.GetCardsAsync();
            Cards = new ObservableCollection<Card>(rawCards);

            var rawBudgets = await _database.GetBudgetsAsync();
            Budgets = new ObservableCollection<Budget>(rawBudgets.OrderByDescending(x => x.Start));
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e);
        }
    }

    [RelayCommand]
    void CardSelected(Card card)
    {
        var c = Cards.FirstOrDefault(x => x.Id == card.Id);
        foreach (var crd in Cards)
        {
            crd.IsSelected = false;
        }
        c.IsSelected = false;
        Shell.Current.ShowBottomSheet(new CardDetails(), 20);
    }

    [RelayCommand]
    void AddCard()
    {
        //MopupService.Instance.PushAsync(new AddCard(), true);
        Shell.Current.ShowBottomSheet(new AddCard(_database, UpdateList), 20);
    }

    [RelayCommand]
    void CardDetails()
    {
        //TODO: fixe the gesture command on the card tape
        Shell.Current.ShowBottomSheet(new CardDetails(), 20);
    }

    async void UpdateList()
    {
        var rawCards = await _database.GetCardsAsync();
        Cards = new ObservableCollection<Card>(rawCards.OrderByDescending(x => x.IsDefault));
        Shell.Current.HideBottomSheet();
    }

    [RelayCommand]
    void AddOperation()
    {
        //TODO: Logic to add new operation
    }

    void RemoveOperation(int operationId)
    {
        //TODO: logic to remove operation
    }

    [RelayCommand]
    void ShowBudgetDetails()
    {
        Shell.Current.ShowBottomSheet(new BudgetDetails(), 20);
    }

    [RelayCommand]
    void AddBudget()
    {
        Shell.Current.ShowBottomSheet(new AddBudget(), 20);
    }
}

