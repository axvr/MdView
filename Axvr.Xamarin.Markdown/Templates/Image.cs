using Axvr.Xamarin.Markdown.Extensions;
using System.IO;

namespace Axvr.Xamarin.Markdown.Templates
{
    /// <summary>
    /// The <c>BindingContext</c> object passed to <see cref="MdView.ImageTemplate"/> on construction.
    /// </summary>
    public class ImageAstNode
    {
        /// <summary>
        /// The URL of the image to render.
        /// </summary>
        public string Url { get; set; }
    }

    /// <summary>
    /// Markdown "image" template view. Intended for use as <see cref="MdView.ImageTemplate"/>.
    /// </summary>
    public class Image : global::Xamarin.Forms.Image
    {
        /// <inheritdoc cref="global::Xamarin.Forms.Image.OnBindingContextChanged"/>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is ImageAstNode node)
            {
                if (Path.GetExtension(node.Url) == ".svg")
                {
                    this.RenderSvg(node.Url);
                }
                else
                {
                    Source = node.Url;
                }
            }
        }
    }
}
