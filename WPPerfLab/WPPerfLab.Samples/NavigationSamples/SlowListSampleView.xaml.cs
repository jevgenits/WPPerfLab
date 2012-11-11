using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WPPerfLab.Common.Entities;

namespace WPPerfLab.Samples.NavigationSamples
{
    public partial class SlowListSampleView : PhoneApplicationPage
    {
        public SlowListSampleView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ProductRepository.GetProducts().ForEach(p => itemList.Items.Add(p));
        }
    }
}