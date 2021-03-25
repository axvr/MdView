using MdView.Sample.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(MdView.Sample.iOS.Renderers.Statusbar))]
namespace MdView.Sample.iOS.Renderers
{
    public class Statusbar : IStatusBarPlatformSpecific
    {
        public void SetStatusBarColor(Color color)
        { }
    }
}
