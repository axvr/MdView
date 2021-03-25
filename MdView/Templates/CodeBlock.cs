using Xamarin.Forms;

namespace MdView.Templates
{
    /// <summary>
    /// The <c>BindingContext</c> object passed to <see cref="MdView.CodeBlockTemplate"/> on construction.
    /// </summary>
    public class CodeBlockData
    {
        /// <summary>
        /// Code block content.
        /// </summary>
        public string Text { get; set; }
    }


    /// <summary>
    /// Markdown "code block" template view.
    /// </summary>
    ///
    /// <remarks>
    /// Intended for use as <see cref="MdView.CodeBlockTemplate"/>.
    ///
    /// The control will be passed required data as a <see cref="CodeBlockData"/>
    /// object set as the <c>BindingContext</c> of the object; firing the
    /// <see cref="OnBindingContextChanged"/> event handler, which renders the Markdown.
    /// </remarks>
    public class CodeBlock : Frame
    {
        /// <summary>
        /// Builds a new default <see cref="CodeBlock"/> template.
        /// </summary>
        public CodeBlock() : base()
        {
            CornerRadius = 3;
            HasShadow = false;
            Padding = 10;
            BackgroundColor = Color.FromHex("#f6f8fa");

            Content = _content;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    _content.FontFamily = "Courier";
                    break;

                case Device.Android:
                    _content.FontFamily = "monospace";
                    break;
            }
        }


        /// <inheritdoc cref="Label.OnBindingContextChanged"/>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is CodeBlockData node)
            {
                _content.Text = node.Text;
            }
        }


        private readonly Label _content = new Label();


        public static readonly BindableProperty ContentStyleProperty =
            BindableProperty.Create(
                propertyName: nameof(ContentStyle),
                returnType: typeof(Style),
                declaringType: typeof(BlockQuote),
                defaultValue: new Style(typeof(Label)),
                propertyChanged: OnContentStyleChanged);

        public Style ContentStyle
        {
            get => (Style)GetValue(ContentStyleProperty);
            set => SetValue(ContentStyleProperty, value);
        }

        private static void OnContentStyleChanged(object bindable, object oldValue, object newValue)
        {
            if (bindable is CodeBlock self && newValue is Style style)
            {
                self._content.Style = style;
            }
        }
    }
}
