using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using Microsoft.Phone.Controls;
using WPPerfLab.Profiling;
using Windows.Phone.System.Memory;

namespace WPPerfLab.Samples.ThreadSamples
{
    public partial class ThreadSamplesView : PhoneApplicationPage
    {
        private int numberOfTimes = 1000;

        public ThreadSamplesView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void DoSomething()
        {
            Debug.WriteLine("Created thread nr.{0}, memory usage: {1}, process commited bytes: {2}", 
                Thread.CurrentThread.ManagedThreadId,
                MemoryProfilerUtils.GetFormatedMemoryUsageInKB(ForegroundMemoryProfiler.CurrentMemoryUsage), 
                MemoryProfilerUtils.GetFormatedMemoryUsageInKB((long)MemoryManager.ProcessCommittedBytes));
            Thread.Sleep(1000000);
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            for (int i = 0; i < numberOfTimes; i++)
            {
                new Thread(DoSomething).Start();
            }
        }
    }
}