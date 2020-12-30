using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Sample
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("editor", typeof(Views.Editor));
        }
    }
}
