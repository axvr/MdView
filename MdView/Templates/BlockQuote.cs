using System.Collections.Generic;
using Xamarin.Forms;

namespace MdView.Templates
{
    /// <summary>
    /// The <c>BindingContext</c> object passed to <see cref="MdView.BlockQuoteTemplate"/> on construction.
    /// </summary>
    public class BlockQuoteData
    {
        /// <summary>
        /// The body of the block quote.
        /// </summary>
        public IEnumerable<View> Views { get; set; }
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

                var body = new StackLayout();

                foreach (var view in node.Views)
                {
                    body.Children.Add(view);
                }

                _content.Children.Add(body);
            }
        }


        private readonly BoxView _separator = new BoxView { WidthRequest = 4, Color = Color.FromHex("#eaecef") };


        public static readonly BindableProperty SeparatorStyleProperty =
            BindableProperty.Create(
                propertyName: nameof(SeparatorStyle),
                returnType: typeof(Style),
                declaringType: typeof(BlockQuote),
                defaultValue: new Style(typeof(BoxView)),
                propertyChanged: OnSeparatorStyleChanged);

        public Style SeparatorStyle
        {
            get => (Style)GetValue(SeparatorStyleProperty);
            set => SetValue(SeparatorStyleProperty, value);
        }

        private static void OnSeparatorStyleChanged(object bindable, object oldValue, object newValue)
        {
            if (bindable is BlockQuote self && newValue is Style style)
            {
                self._separator.Style = style;
            }
        }


        private readonly StackLayout _content = new StackLayout { Orientation = StackOrientation.Horizontal };


        public static readonly BindableProperty ContentStyleProperty =
            BindableProperty.Create(
                propertyName: nameof(ContentStyle),
                returnType: typeof(Style),
                declaringType: typeof(BlockQuote),
                defaultValue: new Style(typeof(StackLayout)),
                propertyChanged: OnContentStyleChanged);

        public Style ContentStyle
        {
            get => (Style)GetValue(ContentStyleProperty);
            set => SetValue(ContentStyleProperty, value);
        }

        private static void OnContentStyleChanged(object bindable, object oldValue, object newValue)
        {
            if (bindable is BlockQuote self && newValue is Style style)
            {
                self._content.Style = style;
            }
        }
    }
}
