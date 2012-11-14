using Microsoft.Phone.Controls;

using WPPerfLab.Common.Entities;

namespace WPPerfLab.Samples.MemoryLeakSamples
{
    public partial class MemoryLeakingListSampleView : PhoneApplicationPage
    {
        public MemoryLeakingListSampleView()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                ProductRepository.GetProducts(100, 0).ForEach(p => itemList.Items.Add(p));

                ProductRepository.RegisterForProductAddedAction((product) => itemList.Items.Add(product));
            };
        }
    }
}