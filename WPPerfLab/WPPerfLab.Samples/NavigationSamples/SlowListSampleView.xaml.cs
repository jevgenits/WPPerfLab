using System.Windows.Navigation;
using Microsoft.Phone.Controls;

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