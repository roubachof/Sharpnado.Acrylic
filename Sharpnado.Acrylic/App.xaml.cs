using Xamarin.Forms;

namespace Sharpnado.Acrylic
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MaterialFrame.Initializer.Initialize(true, true);

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

