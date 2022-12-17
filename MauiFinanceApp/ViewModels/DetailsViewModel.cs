using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiFinanceApp.ViewModels;

public partial class DetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    private ISeries[] _getSeries;

    public ISeries[] Series { get; set; } = new ISeries[]
       {
           new ColumnSeries<int>
            {
                Values = new [] { 4, 4, 7, 2, 8 },
                MaxBarWidth = double.MaxValue
            }
       };
}
