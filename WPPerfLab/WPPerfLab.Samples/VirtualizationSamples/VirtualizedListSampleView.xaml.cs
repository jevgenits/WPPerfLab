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

namespace WPPerfLab.Samples.VirtualizationSamples
{
    public partial class VirtualizedListSampleView : PhoneApplicationPage
    {
        public VirtualizedListSampleView()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                ProductRepository.GetProducts(100, 0).ForEach(p => itemList.Items.Add(p));
            };
        }
    }
}