using Microsoft.Phone.Info;
using Windows.Phone.Devices.Power;

namespace WPPerfLab.Profiling
{
    public static class BatteryUsageProfiler
    {
        private static readonly Battery BatteryManager = Battery.GetDefault();

        public static int BatteryRemainingChargePercent
        {
            get
            {
                return BatteryManager.RemainingChargePercent;
            }
        }

        public static double BatteryRemainingTimeInMilliseconds
        {
            get
            {
                return BatteryManager.RemainingDischargeTime.TotalMilliseconds;
            }
        }
    }
}
