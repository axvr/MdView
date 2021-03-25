namespace MdView.Templates
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
        /// Title of the image.
        /// </summary>
        ///
        /// <example>
        /// <code>
        /// ![](https://unsplash.it/200/300 "This is the image title")
        /// </code>
        /// </example>
        public string Title { get; set; }
    }


    /// <summary>
    /// Markdown "image" template view.
    /// </summary>
    ///
    /// <remarks>
    /// Intended for use as <see cref="MdView.ImageTemplate"/>.
    /// </remarks>
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
