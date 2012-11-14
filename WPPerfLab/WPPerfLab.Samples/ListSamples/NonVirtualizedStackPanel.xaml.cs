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
                    for (int i = 0; i < 1600; i++)
                    {
                        itemList.Items.Add(height);
                    }
                };
        }
    }
}