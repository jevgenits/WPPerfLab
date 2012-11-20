namespace WPPerfLab.Profiling
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
