namespace Axvr.Xamarin.Markdown.Templates
{
    /// <summary>
    /// The <c>BindingContext</c> object passed to <see cref="MdView.ImageTemplate"/> on construction.
    /// </summary>
    public class ImageData
    {
        /// <summary>
        /// The URI of the image to render.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Title tag of the image.  Can be used as alt text.
        /// </summary>
        public string Title { get; set; }
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

            if (BindingContext is ImageData node)
            {
                Source = node.Uri;
            }
        }
    }
}
