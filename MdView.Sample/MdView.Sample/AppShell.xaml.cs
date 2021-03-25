using Xamarin.Forms;

namespace MdView.Sample
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
