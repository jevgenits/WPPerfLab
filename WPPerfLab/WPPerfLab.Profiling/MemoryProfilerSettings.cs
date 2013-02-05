using System;
using System.Windows.Media;

namespace WPPerfLab.Profiling
{
    public class MemoryProfilerSettings
    {
        public int FontSize { get; set; }
        public bool IsConsoleLoggingEnabled { get; set; }
        public bool IsPopupLoggingEnabled { get; set; }
        public TimeSpan TimerInterval { get; set; }
        public Color BackgroundColor { get; set; }

        public static MemoryProfilerSettings Default
        {
            get
            {
                return new MemoryProfilerSettings()
                {
                    FontSize = 16,
                    IsConsoleLoggingEnabled = false,
                    IsPopupLoggingEnabled = false,
                    TimerInterval = TimeSpan.FromSeconds(1),
                    BackgroundColor = Colors.Transparent
                };
            }
        }
    }
}
