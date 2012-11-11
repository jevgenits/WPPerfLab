using System.Windows.Threading;

using Microsoft.Phone.Controls;
using System;

namespace WPPerfLab.Samples.EnableRedrawRegionsSamples
{
    public partial class BrokenTimerUpdatePage : PhoneApplicationPage
    {
        public BrokenTimerUpdatePage()
        {
            InitializeComponent();
            DataContext = new BrokenTimerUpdateViewModel();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ((BrokenTimerUpdateViewModel)DataContext).StartTimer();
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            ((BrokenTimerUpdateViewModel)DataContext).StopTimer();
        }
    }
}