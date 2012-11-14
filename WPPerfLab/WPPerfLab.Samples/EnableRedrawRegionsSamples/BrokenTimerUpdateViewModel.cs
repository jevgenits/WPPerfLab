using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace WPPerfLab.Samples.EnableRedrawRegionsSamples
{
    public class BrokenTimerUpdateViewModel : INotifyPropertyChanged
    {
        private DispatcherTimer timer;

        private string currentTimeText;
        public string CurrentTimeText
        {
            get
            {
                return this.currentTimeText;
            }

            set
            {
                if (value != this.currentTimeText)
                {
                    this.currentTimeText = value;
                    NotifyPropertyChanged("CurrentTimeText");
                }
            }
        }

        public void StartTimer()
        {
            if (timer == null)
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += TimerTick;
            }
            timer.Start();
        }

        public void StopTimer()
        {
            timer.Tick -= TimerTick;
            timer.Stop();
        }

        void TimerTick(object sender, EventArgs e)
        {
            CurrentTimeText = DateTime.Now.ToLongTimeString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
