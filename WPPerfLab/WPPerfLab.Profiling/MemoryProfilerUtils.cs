using System;

namespace WPPerfLab.Profiling
{
    public static class MemoryProfilerUtils
    {
        public static string GetFormatedMemoryUsageInMB(long memoryUsageInBytes)
        {
            return string.Format("{0} MB", Math.Ceiling((double)memoryUsageInBytes / 1048576));
        }
        
        public static string GetFormatedMemoryUsageInKB(long memoryUsageInBytes)
        {
            return string.Format("{0} KB", Math.Ceiling((double)memoryUsageInBytes / 1024));
        }
    }
}
