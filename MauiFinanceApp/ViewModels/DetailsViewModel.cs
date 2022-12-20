using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using CommunityToolkit.Mvvm.ComponentModel;
using OverSheet;
using MauiFinanceApp.Pages.Dialogs;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiFinanceApp.ViewModels;

public partial class DetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    private ISeries[] _getSeries;

    public ISeries[] Series { get; set; } = new ISeries[]
       {
           new ColumnSeries<double>
            {
                Values = new ObservableCollection<double> { 10, 10, 10, 10, 10, 10, 10 },
                Stroke = null,
                Fill = new SolidColorPaint(new SKColor(30, 30, 30, 30)),
                IgnoresBarPosition = true
            },
            new ColumnSeries<double>
            {
                Values = new ObservableCollection<double> { 3, 10, 5, 3, 7, 3, 8 },
                Stroke = null,
                Fill = new SolidColorPaint(SKColors.CornflowerBlue),
                IgnoresBarPosition = true
            }
       };


    [RelayCommand]
    void AddBudget()
    {
        Shell.Current.ShowBottomSheet(new AddBudget(), 20);
    }
}
