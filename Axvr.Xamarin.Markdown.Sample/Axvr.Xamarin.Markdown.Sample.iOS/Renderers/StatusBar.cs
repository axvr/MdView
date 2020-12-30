using Axvr.Xamarin.Markdown.Sample.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(Axvr.Xamarin.Markdown.Sample.iOS.Renderers.Statusbar))]
namespace Axvr.Xamarin.Markdown.Sample.iOS.Renderers
{
    public class Statusbar : IStatusBarPlatformSpecific
    {
        public void SetStatusBarColor(Color color)
        { }
    }
}
