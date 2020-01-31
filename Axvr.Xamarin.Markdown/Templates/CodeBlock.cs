using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Templates
{
    public class CodeBlockAstNode
    {
        public string Text { get; set; }
    }

    public class CodeBlock : Frame
    {
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

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is CodeBlockAstNode node)
            {
                Text = node.Text;
            }
        }

        #region Text customisation options

        public string Text
        {
            get => _content.Text;
            set => _content.Text = value;
        }

        public Color TextColor
        {
            get => _content.TextColor;
            set => _content.TextColor = value;
        }

        public string FontFamily
        {
            get => _content.FontFamily;
            set => _content.FontFamily = value;
        }

        public FontAttributes FontAttributes
        {
            get => _content.FontAttributes;
            set => _content.FontAttributes = value;
        }

        public TextDecorations TextDecorations
        {
            get => _content.TextDecorations;
            set => _content.TextDecorations = value;
        }

        public double FontSize
        {
            get => _content.FontSize;
            set => _content.FontSize = value;
        }

        public double CharacterSpacing
        {
            get => _content.CharacterSpacing;
            set => _content.CharacterSpacing = value;
        }

        public double LineHeight
        {
            get => _content.LineHeight;
            set => _content.LineHeight = value;
        }

        public new FlowDirection FlowDirection
        {
            get => _content.FlowDirection;
            set => _content.FlowDirection = value;
        }

        public FormattedString FormattedText
        {
            get => _content.FormattedText;
            set => _content.FormattedText = value;
        }

        public TextAlignment HorizontalTextAlignment
        {
            get => _content.HorizontalTextAlignment;
            set => _content.HorizontalTextAlignment = value;
        }

        public TextAlignment VerticalTextAlignment
        {
            get => _content.VerticalTextAlignment;
            set => _content.VerticalTextAlignment = value;
        }

        public LineBreakMode LineBreakMode
        {
            get => _content.LineBreakMode;
            set => _content.LineBreakMode = value;
        }

        public int MaxLines
        {
            get => _content.MaxLines;
            set => _content.MaxLines = value;
        }

        public Style TextStyle
        {
            get => _content.Style;
            set => _content.Style = value;
        }

        public TextType TextType
        {
            get => _content.TextType;
            set => _content.TextType = value;
        }

        #endregion
    }
}
