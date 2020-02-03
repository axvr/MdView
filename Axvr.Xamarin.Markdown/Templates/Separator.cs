using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Templates
{
    /// <summary>
    /// Markdown "separator" template view. Intended for use as <see cref="MdView.SeparatorTemplate"/>.
    /// </summary>
    public class Separator : BoxView
    {
        /// <summary>
        /// Builds a new default <see cref="Separator"/> instance.
        /// </summary>
        public Separator() : base()
        {
            HeightRequest = 2;
            BackgroundColor = Color.FromHex("#eaecef");
        }
    }
}
