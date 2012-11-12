using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPPerfLab.Common.Profiling
{
    public static class Timer
    {
        private static Stopwatch sw = new Stopwatch();

        public static void Start()
        {
            sw.Start();
        }

        public static void Stop()
        {
            sw.Stop();
#if DEBUG
            Debug.WriteLine("Duration: {0} ms", sw.ElapsedMilliseconds);
#endif
        }
    }
}
