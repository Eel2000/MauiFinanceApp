using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiFinanceApp.DataAccess;
using MauiFinanceApp.Models;

namespace MauiFinanceApp.ViewModels;

public partial class WalletViewModel : BaseViewModel
{
    private readonly WalletDatabase _database;


    [ObservableProperty] private ObservableCollection<Card> _cards = new();
    [ObservableProperty] private ObservableCollection<Operation> _operations = new();

    [ObservableProperty]
    private decimal _amount;

    public WalletViewModel(WalletDatabase database)
    {
        _database = database;
        InitDefaultData();
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
            },
            new()
            {
                Id = 2,
                Amount = 4000,
                ExpiryDate = DateTimeOffset.Now.AddYears(5),
            },
            new()
            {
                Id = 3,
                Amount = 6000,
                ExpiryDate = DateTimeOffset.Now.AddYears(5),
            },
        };

        Operations = new()
        {
            new()
            {
                Id = 1,
                CardId = 1,
                IsDeleted = false,
                Amount = 250
            },
            new()
            {
                Id = 1,
                CardId = 2,
                IsDeleted = false,
                Amount = 250
            },
            new()
            {
                Id = 1,
                CardId = 3,
                IsDeleted = false,
                Amount = 250
            },
            new()
            {
                Id = 1,
                CardId = 1,
                IsDeleted = false,
                Amount = 250
            },
            new()
            {
                Id = 1,
                CardId = 2,
                IsDeleted = false,
                Amount = 250
            },
            new()
            {
                Id = 1,
                CardId = 3,
                IsDeleted = false,
                Amount = 250
            },
        };
    }

    [RelayCommand]
    void CardSelected(Card card)
    {
        var newList = Cards;
        var selectedCard = newList.FirstOrDefault(x => x.Id == card.Id);
        selectedCard.IsSelected = true;

        newList.Remove(selectedCard);
        newList.Add(selectedCard);

        Cards = new(newList);
    }

    [RelayCommand]
    void AddCard()
    {
        //TODO: logic to add new card;
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
}

