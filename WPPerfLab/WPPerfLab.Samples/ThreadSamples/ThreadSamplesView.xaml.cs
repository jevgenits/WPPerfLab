using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using Microsoft.Phone.Controls;
using WPPerfLab.Profiling;

namespace WPPerfLab.Samples.ThreadSamples
{
    public partial class ThreadSamplesView : PhoneApplicationPage
    {
        public ThreadSamplesView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void DoSomething()
        {
            while (true)
            {
                Thread.Sleep(1000);
            }
        }

        private void RunThreadMeasurement(int numberOfThreads)
        {
            var initialMemoryUsage = ForegroundMemoryProfiler.CurrentMemoryUsage;
            for (int i = 0; i < numberOfThreads; i++)
            {
                new Thread(DoSomething).Start();
            }
            var memoryDelta = ForegroundMemoryProfiler.CurrentMemoryUsage - initialMemoryUsage;
            var memoryPerThread = memoryDelta / numberOfThreads;

            Debug.WriteLine("Memory per thread (for {0} threads): {1}",
                numberOfThreads,
                MemoryProfilerUtils.GetFormatedMemoryUsageInKB(memoryPerThread));
        }
            
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            RunThreadMeasurement(10);
            RunThreadMeasurement(100);
            RunThreadMeasurement(500);
        }
    }
}