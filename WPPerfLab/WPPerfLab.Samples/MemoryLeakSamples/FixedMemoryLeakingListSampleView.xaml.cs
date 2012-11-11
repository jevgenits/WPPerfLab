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

namespace WPPerfLab.Samples.MemoryLeakSamples
{
    public partial class FixedMemoryLeakingListSampleView : PhoneApplicationPage
    {
        private Action<ProductEntity> productAddedAction;

        public FixedMemoryLeakingListSampleView()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                ProductRepository.GetProducts(100, 0).ForEach(p => itemList.Items.Add(p));

                productAddedAction = (product) => itemList.Items.Add(product);

                ProductRepository.RegisterForProductAddedAction(productAddedAction);
            };
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            ProductRepository.UnregisterForProductAddedAction(productAddedAction);
            // GC.Collect();
        }

        //~FixedMemoryLeakingListSampleView()
        //{

        //}
    }
}