using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPPerfLab.Common.Profiling
{
    public class MemoryProfilerSettings
    {
        public int FontSize { get; set; }
        public bool IsConsoleLoggingEnabled { get; set; }
        public bool IsPopupLoggingEnabled { get; set; }
        public TimeSpan TimerInterval { get; set; }

        public static MemoryProfilerSettings Default
        {
            get
            {
                return new MemoryProfilerSettings()
                {
                    FontSize = 16,
                    IsConsoleLoggingEnabled = false,
                    IsPopupLoggingEnabled = true,
                    TimerInterval = TimeSpan.FromSeconds(1)
                };
            }
        }
    }
}
