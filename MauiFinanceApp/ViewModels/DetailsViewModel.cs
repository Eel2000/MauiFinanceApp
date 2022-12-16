using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace MauiFinanceApp.ViewModels;

public partial class DetailsViewModel : BaseViewModel
{
     public ISeries[] Series { get; set; } = new ISeries[]
        {
            new ColumnSeries<int>
            {
                Values = new [] { 4, 4, 7, 2, 8 },
                Fill = new SolidColorPaint(SKColors.Blue),
                Stroke = null
            },
            new ColumnSeries<int>
            {
                Values = new[] { 7, 5, 3, 2, 6 },
                Fill = new SolidColorPaint(SKColors.Red),
                Stroke = null
            }
        };
}
