using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Templates
{
    /// <summary>
    /// The <c>BindingContext</c> object passed to <see cref="MdView.BlockQuoteTemplate"/> on construction.
    /// </summary>
    public class BlockQuoteData
    {
        /// <summary>
        /// The body of the block quote.
        /// </summary>
        public View View { get; set; }
    }

    /// <summary>
    /// Markdown "block quote" template view.
    /// </summary>
    ///
    /// <remarks>
    /// Intended for use as <see cref="MdView.BlockQuoteTemplate"/>.
    ///
    /// The control will be passed required data as a <see cref="BlockQuoteData"/>
    /// object set as the <c>BindingContext</c> of the object; firing the
    /// <see cref="OnBindingContextChanged"/> event handler, which renders the Markdown.
    /// </remarks>
    public class BlockQuote : Frame
    {
        /// <summary>
        /// Builds a new default <see cref="BlockQuote"/> template.
        /// </summary>
        public BlockQuote() : base()
        {
            HasShadow = false;
            Padding = 0;
            Opacity = 0.9;

            _content.Children.Add(_separator);

            Content = _content;
        }

        private readonly StackLayout _content = new StackLayout { Orientation = StackOrientation.Horizontal };
        private readonly BoxView _separator = new BoxView { WidthRequest = 4, Color = Color.FromHex("#eaecef") };

        /// <inheritdoc cref="CodeBlock.OnBindingContextChanged"/>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is BlockQuoteData node)
            {
                if (_content.Children.Count > 1)
                {
                    _content.Children.RemoveAt(1);
                }

                _content.Children.Add(node.View);
            }
        }
    }
}
