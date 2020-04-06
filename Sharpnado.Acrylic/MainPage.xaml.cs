using System;
using System.ComponentModel;
using System.Threading.Tasks;

using Sharpnado.Presentation.Forms.RenderedViews;
using Sharpnado.Tasks;

using Xamarin.Forms;

namespace Sharpnado.Acrylic
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            TaskMonitor.Create(DelayExecute);
        }

        private async Task DelayExecute()
        {
            await Task.Delay(3000);

            var dump = PlatformHelper.Instance.DumpNativeViewHierarchy(Search, true);
            Console.WriteLine($"Search Frame dump:{Environment.NewLine}{dump}");

            dump = PlatformHelper.Instance.DumpNativeViewHierarchy(ImageFrame, true);
            Console.WriteLine($"Image Frame dump:{Environment.NewLine}{dump}");
        }
    }
}
