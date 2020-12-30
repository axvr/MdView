using Android.OS;
using Android.Views;
using Axvr.Xamarin.Markdown.Sample.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(Axvr.Xamarin.Markdown.Sample.Droid.Renderers.Statusbar))]
namespace Axvr.Xamarin.Markdown.Sample.Droid.Renderers
{
    public class Statusbar : IStatusBarPlatformSpecific
    {
        public void SetStatusBarColor(Color color)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var window = global::Xamarin.Essentials.Platform.CurrentActivity.Window;

                if (ResourcesHelper.BestContrastFor(color) == Contrast.Dark)
                {
                    window.DecorView.SystemUiVisibility |= (StatusBarVisibility)SystemUiFlags.LightStatusBar;
                }
                else
                {
                    window.DecorView.SystemUiVisibility &= ~(StatusBarVisibility)SystemUiFlags.LightStatusBar;
                }

                var androidColor = color.AddLuminosity(-0.1).ToAndroid();
                window.SetStatusBarColor(androidColor);
            }
        }
    }
}
