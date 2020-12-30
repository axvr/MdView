using System;
using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Sample.Helpers
{
    public static class ResourcesHelper
    {
        private static void SetResource(string resourceName, string theme)
        {
            if (!Application.Current.Resources.TryGetValue($"{resourceName}_{theme}", out var value))
            {
                throw new InvalidOperationException($"key {resourceName} not found in the resource dictionary");
            }

            Application.Current.Resources[resourceName] = value;
        }


        private static object GetResource(string resourceName, string theme)
        {
            Application.Current.Resources.TryGetValue($"{resourceName}_{theme}", out var resource);
            return resource;
        }


        public static void LoadTheme(Theme theme)
        {
            void Set(string resource) => SetResource(resource, theme.ToString());

            if (GetResource("StatusBar", theme.ToString()) is Color colour)
            {
                var statusbar = DependencyService.Get<IStatusBarPlatformSpecific>();
                statusbar.SetStatusBarColor(colour);
                // TODO: iOS support.
            }

            Set("NavigationPrimary");
            Set("NavigationForeground");
            Set("NavigationUnselected");
            Set("NavigationDisabled");
            Set("Background");
            Set("Foreground");
            Set("FadedForeground");
            Set("FadedBackground");
            Set("HeadingForeground");
            Set("Accent");
            Set("LinkForeground");
        }


        public static Contrast BestContrastFor(Color color)
        {
            return (color.Luminosity > 0.5) ? Contrast.Dark : Contrast.Light;
        }
    }


    public enum Theme { Default, Light, Dark }


    public interface IStatusBarPlatformSpecific
    {
        void SetStatusBarColor(Color color);
    }


    public enum Contrast { Light, Dark }
}
