using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Templates
{
    /// <summary>
    /// The <c>BindingContext</c> object passed to <see cref="MdView.CodeBlockTemplate"/> on construction.
    /// </summary>
    public class CodeBlockAstNode
    {
        public string Text { get; set; }
    }

    /// <summary>
    /// Markdown "code block" template view. Intended for use as <see cref="MdView.CodeBlockTemplate"/>.
    /// </summary>
    /// <remarks>
    /// The control will be passed required data as a <see cref="CodeBlockAstNode"/>
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
                    FontFamily = "Courier";
                    break;

                case Device.Android:
                    FontFamily = "monospace";
                    break;
            }
        }

        private readonly Label _content = new Label();

        /// <inheritdoc cref="Label.OnBindingContextChanged"/>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is CodeBlockAstNode node)
            {
                Text = node.Text;
            }
        }

        #region Pretend to be a Label

        /// <summary>
        /// Gets or sets the text in this <see cref="CodeBlock"/>.
        /// </summary>
        public string Text
        {
            get => _content.Text;
            set => _content.Text = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="Color"/> for the text in this <see cref="CodeBlock"/>.
        /// </summary>
        public Color TextColor
        {
            get => _content.TextColor;
            set => _content.TextColor = value;
        }

        /// <summary>
        /// Gets or sets the font family used for the text in this <see cref="CodeBlock"/>.
        /// </summary>
        public string FontFamily
        {
            get => _content.FontFamily;
            set => _content.FontFamily = value;
        }

        /// <summary>
        /// Gets or sets if the text used for the text in this <see cref="CodeBlock"/> is bold, italic, both or neither.
        /// </summary>
        public FontAttributes FontAttributes
        {
            get => _content.FontAttributes;
            set => _content.FontAttributes = value;
        }

        /// <summary>
        /// Gets or sets if the text used for the text in this <see cref="CodeBlock"/> is underlined, strikethrough, both or neither.
        /// </summary>
        public TextDecorations TextDecorations
        {
            get => _content.TextDecorations;
            set => _content.TextDecorations = value;
        }

        /// <summary>
        /// Gets or sets the font size used for the text in this <see cref="CodeBlock"/>.
        /// </summary>
        public double FontSize
        {
            get => _content.FontSize;
            set => _content.FontSize = value;
        }

        /// <summary>
        /// Gets or sets the character spacing of the text in this <see cref="CodeBlock"/>.
        /// </summary>
        public double CharacterSpacing
        {
            get => _content.CharacterSpacing;
            set => _content.CharacterSpacing = value;
        }

        /// <summary>
        /// Gets or sets the line height of the text in this <see cref="CodeBlock"/>.
        /// </summary>
        public double LineHeight
        {
            get => _content.LineHeight;
            set => _content.LineHeight = value;
        }

        /// <summary>
        /// Gets or sets the formatted text for the text in this <see cref="CodeBlock"/>.
        /// </summary>
        public FormattedString FormattedText
        {
            get => _content.FormattedText;
            set => _content.FormattedText = value;
        }

        /// <summary>
        /// Gets or sets the horizontal text alignment of text in this <see cref="CodeBlock"/>.
        /// </summary>
        public TextAlignment HorizontalTextAlignment
        {
            get => _content.HorizontalTextAlignment;
            set => _content.HorizontalTextAlignment = value;
        }

        /// <summary>
        /// Gets or sets the vertical text alignment of text in this <see cref="CodeBlock"/>.
        /// </summary>
        public TextAlignment VerticalTextAlignment
        {
            get => _content.VerticalTextAlignment;
            set => _content.VerticalTextAlignment = value;
        }

        /// <summary>
        /// Gets or sets how this <see cref="CodeBlock"/> should handle line breaks.
        /// </summary>
        public LineBreakMode LineBreakMode
        {
            get => _content.LineBreakMode;
            set => _content.LineBreakMode = value;
        }

        /// <summary>
        /// Gets or sets the maximum number of lines shown in this <see cref="CodeBlock"/>.
        /// </summary>
        public int MaxLines
        {
            get => _content.MaxLines;
            set => _content.MaxLines = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="Style"/> used to render the text in this <see cref="CodeBlock"/>.
        /// </summary>
        public Style TextStyle
        {
            get => _content.Style;
            set => _content.Style = value;
        }

        /// <inheritdoc cref="Label.TextType"/>
        public TextType TextType
        {
            get => _content.TextType;
            set => _content.TextType = value;
        }

        #endregion
    }
}
