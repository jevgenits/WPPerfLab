using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

using WPPerfLab.Common.Profiling;

namespace WPPerfLab.Samples.Settings
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            CheckBoxToggleMemoryProfiler.IsChecked = MemoryProfiler.IsRunning;
            CheckBoxToggleFrameRateCounters.IsChecked = Application.Current.Host.Settings.EnableFrameRateCounter;
            CheckBoxToggleEnableRedrawRegions.IsChecked = Application.Current.Host.Settings.EnableRedrawRegions;
        }

        private void ToggleFrameRateCounters(object sender, RoutedEventArgs e)
        {
            if (CheckBoxToggleFrameRateCounters.IsChecked.HasValue)
            {
                Application.Current.Host.Settings.EnableFrameRateCounter = CheckBoxToggleFrameRateCounters.IsChecked.Value;
            }
        }

        private void ToggleEnableRedrawRegions(object sender, RoutedEventArgs e)
        {
            if (CheckBoxToggleEnableRedrawRegions.IsChecked.HasValue)
            {
                Application.Current.Host.Settings.EnableRedrawRegions = CheckBoxToggleEnableRedrawRegions.IsChecked.Value;
            }
        }

        private void ToggleMemoryProfiler(object sender, RoutedEventArgs e)
        {
            if (CheckBoxToggleMemoryProfiler.IsChecked.HasValue && CheckBoxToggleMemoryProfiler.IsChecked.Value && !MemoryProfiler.IsRunning)
            {
                MemoryProfiler.Start();
            }
            else
            {
                MemoryProfiler.Stop();
            }
        }
    }
}