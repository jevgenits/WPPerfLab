using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPPerfLab.Common.Profiling
{
    public static class ForegroundMemoryProfiler
    {
        public static long CurrentMemoryUsage
        {
            get
            {
                return Microsoft.Phone.Info.DeviceStatus.ApplicationCurrentMemoryUsage;
            }
        }

        public static long PeakMemoryUsage
        {
            get
            {
                return Microsoft.Phone.Info.DeviceStatus.ApplicationPeakMemoryUsage;
            }
        }
    }
}
