using System.Diagnostics;

using Microsoft.Phone.Controls;

namespace WPPerfLab.Samples.ListSamples
{
    public partial class NonVirtualizedStackPanel : PhoneApplicationPage
    {
        public NonVirtualizedStackPanel()
        {
            InitializeComponent();
            Loaded += (s, e) =>
                {
                    long height = 25;
                    int numberOfItems = 1600;

                    for (int i = 0; i < numberOfItems; i++)
                    {
                        itemList.Items.Add(height);
                    }
                };
        }
    }
}