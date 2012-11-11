using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WPPerfLab.Samples.Resources;

namespace WPPerfLab.Samples
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SlowNavigateToList(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/NavigationSamples/SlowListSampleView.xaml", UriKind.Relative));
        }

        private void FastNavigateToList(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/NavigationSamples/FastListSampleView.xaml", UriKind.Relative));
        }

        private void NavigateToNonVirtualizedList(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/VirtualizationSamples/NonVirtualizedListSampleView.xaml", UriKind.Relative));
        }

        private void NavigateToVirtualizedList(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/VirtualizationSamples/VirtualizedListSampleView.xaml", UriKind.Relative));
        }

        private void NavigateToMemoryLeakingPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MemoryLeakSamples/MemoryLeakingListSampleView.xaml", UriKind.Relative));
        }

        private void NavigateToFixedMemoryLeakingPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MemoryLeakSamples/FixedMemoryLeakingListSampleView.xaml", UriKind.Relative));
        }

        private void NavigateToBrokenUpdateTimer(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EnableRedrawRegionsSamples/BrokenTimerUpdatePage.xaml", UriKind.Relative));
        }

        private void NavigateToFixedUpdateTimer(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EnableRedrawRegionsSamples/FixedTimerUpdatePage.xaml", UriKind.Relative));
        }

        private void NavigateToSettingsPage(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings/SettingsPage.xaml", UriKind.Relative));
        }
    }
}