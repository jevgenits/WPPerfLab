using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

namespace WPPerfLab.Profiling
{
    public class MemoryProfiler
    {
        private static MemoryProfilerSettings settings;

        private static DispatcherTimer timer;
        private static Popup popupControl;
        private static StackPanel popupContentPanel;
        private static TextBlock textblockCurrentMemoryUsage;
        private static TextBlock textblockPeakMemoryUsage;
        private static TextBlock textblockBatteryRemainingChargePercent;

        public static bool IsRunning { get; set; }

        public static void Start()
        {
            Start(MemoryProfilerSettings.Default);
        }

        public static void Start(MemoryProfilerSettings newSettings)
        {
            settings = newSettings;

            if (settings.IsPopupLoggingEnabled)
            {
                CreateAndDisplayPopup();
            }

            if (timer == null)
            {
                timer = new DispatcherTimer() { Interval = settings.TimerInterval };
                timer.Tick += TimerTick;
            }
            timer.Start();

            IsRunning = true;
        }

        public static void Stop()
        {
            if (timer != null)
            {
                timer.Tick -= TimerTick;
                if (timer.IsEnabled)
                {
                    timer.Stop();
                }
                timer = null;
            }

            if (popupControl != null)
            {
                popupControl.IsOpen = false;
            }

            IsRunning = false;
        }

        private static void CreateAndDisplayPopup()
        {
            popupControl = new Popup();

            popupContentPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Background = new SolidColorBrush(settings.BackgroundColor)
            };

            popupContentPanel.Children.Add(GenerateTextBlockForPopup(Colors.White, "Current: "));
            textblockCurrentMemoryUsage = GenerateTextBlockForPopup(Colors.White, "N/A");
            popupContentPanel.Children.Add(textblockCurrentMemoryUsage);

            popupContentPanel.Children.Add(GenerateTextBlockForPopup(Colors.Yellow, "Peak: "));
            textblockPeakMemoryUsage = GenerateTextBlockForPopup(Colors.Yellow, "N/A");
            popupContentPanel.Children.Add(textblockPeakMemoryUsage);

            popupContentPanel.Children.Add(GenerateTextBlockForPopup(Colors.Orange, "Bat: "));
            textblockBatteryRemainingChargePercent = GenerateTextBlockForPopup(Colors.Orange, "N/A");
            popupContentPanel.Children.Add(textblockBatteryRemainingChargePercent);

            popupControl.Child = popupContentPanel;

            popupControl.IsOpen = true;
        }

        private static TextBlock GenerateTextBlockForPopup(Color foregroundColor, string text)
        {
            var tb = new TextBlock();
            tb.FontSize = settings.FontSize;
            tb.Text = text;
            tb.Foreground = new SolidColorBrush(foregroundColor);
            tb.Margin = new Thickness(5, 0, 0, 0);
            return tb;
        }

        private static void TimerTick(object sender, EventArgs e)
        {
            string currentMemory = MemoryProfilerUtils.GetFormatedMemoryUsageInMB(ForegroundMemoryProfiler.CurrentMemoryUsage);
            string peakMemory = MemoryProfilerUtils.GetFormatedMemoryUsageInMB(ForegroundMemoryProfiler.PeakMemoryUsage);
            string batteryRemainingPercent = BatteryUsageProfiler.BatteryRemainingChargePercent.ToString();

            if (settings.IsConsoleLoggingEnabled)
            {
                LogToConsole("Current Memory Usage", currentMemory);
                LogToConsole("Peak Memory Usage", peakMemory);
                LogToConsole("Battery Remaining Charge Percent", batteryRemainingPercent);
                LogToConsole("Battery Remaining Time(ms)", BatteryUsageProfiler.BatteryRemainingTimeInMilliseconds.ToString());
            }

            if (settings.IsPopupLoggingEnabled)
            {
                textblockCurrentMemoryUsage.Text = currentMemory;
                textblockPeakMemoryUsage.Text = peakMemory;
                textblockBatteryRemainingChargePercent.Text = batteryRemainingPercent;
            }
        }

        private static void LogToConsole(string parameterName, string parameterValue)
        {
            Debug.WriteLine(string.Format("{0}: {1}", parameterName, parameterValue));
        }
    }
}
