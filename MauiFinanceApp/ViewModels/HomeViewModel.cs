using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Java.Sql;
using MauiFinanceApp.DataAccess;

namespace MauiFinanceApp.ViewModels;

public partial class HomeViewModel : BaseViewModel
{

    private readonly WalletDatabase _walletDatabase;

    public HomeViewModel(WalletDatabase walletDatabase)
    {
        _walletDatabase = walletDatabase;
        LoadInitialDashboardAnalytics();
    }

    [ObservableProperty] private decimal _totalAmount;
    [ObservableProperty] private decimal _totalSaving;
    [ObservableProperty] private decimal _totalExpenses;
    [ObservableProperty] private DateTime _dateTime;
    [ObservableProperty] private decimal _monthlySpending;
    [ObservableProperty] private decimal _leftOnTheActiveBudge;



    [RelayCommand]
    void NavigateToStatistic()
    {
        Shell.Current.GoToAsync("/analytics", true);
    }

    async void LoadInitialDashboardAnalytics()
    {
        _dateTime = DateTime.Now;
        //TODO: load and compute finance states(monthly expense,saving, total saving ,expenses)
        var cards = await _walletDatabase.GetCardsAsync();
        if (cards.Any())
        {
            var cardsMoneySum = cards.Sum(c => c.Amount);
            TotalAmount = cardsMoneySum;
        }

        var ops = await _walletDatabase.GetOperationsAsync();
        if (ops.Any())
        {
            var opsGroupedByType = ops.GroupBy(o => o.OperationType, (type, op) => new
            {
                operation = type,
                data = op
            });

            var incomesRaw = opsGroupedByType
                .SingleOrDefault(x => x.operation == Enums.OperationType.INCOME);

            var expensesRaw = opsGroupedByType.SingleOrDefault(x => x.operation == Enums.OperationType.EXPENSE);

            TotalSaving = incomesRaw
                .data
                .Where(x => x.IsDeleted != true && x.OperationDate.Month == DateTime.Now.Month)
                .Sum(x => x.Amount);

            TotalExpenses = expensesRaw
                .data
                .Where(x => x.IsDeleted != true && x.OperationDate.Month == DateTime.Now.Month)
                .Sum(x => x.Amount);

            MonthlySpending = expensesRaw
                .data
                .Where(e => e.IsDeleted != true && e.OperationDate.Date.Month == DateTime.Month)
                .Sum(e => e.Amount);
        }
    }
}

