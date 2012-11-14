using Microsoft.Phone.Controls;
using WPPerfLab.Common.Entities;

namespace WPPerfLab.Samples.ListSamples
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