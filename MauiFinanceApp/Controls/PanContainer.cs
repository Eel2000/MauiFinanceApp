using Mopups.Interfaces;
using Mopups.Services;

namespace MauiFinanceApp.Controls;

public class PanContainer : ContentView
{
    //private readonly /*IPopupNavigation _popupNavigation*/;

    public PanContainer(/*IPopupNavigation popupNavigation*/)
    {
        //_popupNavigation = popupNavigation;
        // Set PanGestureRecognizer.TouchPoints to control the
        // number of touch points needed to pan
        var panGesture = new PanGestureRecognizer();

        panGesture.PanUpdated += OnPanUpdated;
        GestureRecognizers.Add(panGesture);
    }

    void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        switch (e.StatusType)
        {
            // Move view
            case GestureStatus.Running:
                TranslationY = Math.Max(0, (Device.RuntimePlatform == Device.Android ? TranslationY : 0) + e.TotalY);
                break;
            case GestureStatus.Completed:
                if (TranslationY < Height / 4)
                    this.TranslateTo(0, 0, 100, Easing.SinIn);
                else
                {
                    //this.TranslateTo(0, (uint)(Height), 350, Easing.SinInOut);
                    MopupService.Instance.PopAsync();
                }
                break;
            case GestureStatus.Canceled:
                break;
            case GestureStatus.Started:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

