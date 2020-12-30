using Axvr.Xamarin.Markdown.Sample.Helpers;
using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Sample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            ResourcesHelper.LoadTheme(Theme.Default);
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
