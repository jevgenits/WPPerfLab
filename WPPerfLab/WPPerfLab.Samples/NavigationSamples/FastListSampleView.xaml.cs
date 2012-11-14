using Microsoft.Phone.Controls;

using WPPerfLab.Common.Entities;

namespace WPPerfLab.Samples.NavigationSamples
{
    public partial class FastListSampleView : PhoneApplicationPage
    {
        public FastListSampleView()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                ProductRepository.GetProducts().ForEach(p => itemList.Items.Add(p));
            };
        }
    }
}