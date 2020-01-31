using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown
{
    public class MarkdownTheme
    {
        public MarkdownTheme()
        {
            Paragraph = new MarkdownStyle
            {
                Attributes = FontAttributes.None,
                FontSize = 12,
            };

            Heading1 = new MarkdownStyle
            {
                Attributes = FontAttributes.Bold,
                BorderSize = 1,
                FontSize = 26,
            };

            Heading2 = new MarkdownStyle
            {
                Attributes = FontAttributes.Bold,
                BorderSize = 1,
                FontSize = 22,
            };

            Heading3 = new MarkdownStyle
            {
                Attributes = FontAttributes.Bold,
                FontSize = 20,
            };

            Heading4 = new MarkdownStyle
            {
                Attributes = FontAttributes.Bold,
                FontSize = 18,
            };

            Heading5 = new MarkdownStyle
            {
                Attributes = FontAttributes.Bold,
                FontSize = 16,
            };

            Heading6 = new MarkdownStyle
            {
                Attributes = FontAttributes.Bold,
                FontSize = 14,
            };

            Link = new MarkdownStyle
            {
                Attributes = FontAttributes.None,
                FontSize = 12,
            };

            Code = new MarkdownStyle
            {
                Attributes = FontAttributes.None,
                FontSize = 12,
            };

            Quote = new MarkdownStyle
            {
                Attributes = FontAttributes.None,
                BorderSize = 4,
                FontSize = 12,
                BackgroundColor = Color.Gray.MultiplyAlpha(.1),
            };

            Separator = new MarkdownStyle
            {
                BorderSize = 2,
            };

            // Platform specific properties
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Code.FontFamily = "Courier";
                    break;

                case Device.Android:
                    Code.FontFamily = "monospace";
                    break;
            }
        }

        public Color BackgroundColor { get; set; }

        public MarkdownStyle Paragraph { get; set; } 

        public MarkdownStyle Heading1 { get; set; } 

        public MarkdownStyle Heading2 { get; set; } 

        public MarkdownStyle Heading3 { get; set; } 

        public MarkdownStyle Heading4 { get; set; } 

        public MarkdownStyle Heading5 { get; set; }

        public MarkdownStyle Heading6 { get; set; }

        public MarkdownStyle Quote { get; set; }

        public MarkdownStyle Separator { get; set; }

        public MarkdownStyle Link { get; set; }

        public MarkdownStyle Code { get; set; }

        public float Margin { get; set; } = 10;
    }

    public class LightMarkdownTheme : MarkdownTheme
    {
        public LightMarkdownTheme()
        {
            BackgroundColor = DefaultBackgroundColor;
            Paragraph.ForegroundColor = DefaultTextColor;
            Heading1.ForegroundColor = DefaultTextColor;
            Heading1.BorderColor = DefaultSeparatorColor;
            Heading2.ForegroundColor = DefaultTextColor;
            Heading2.BorderColor = DefaultSeparatorColor;
            Heading3.ForegroundColor = DefaultTextColor;
            Heading4.ForegroundColor = DefaultTextColor;
            Heading5.ForegroundColor = DefaultTextColor;
            Heading6.ForegroundColor = DefaultTextColor;
            Link.ForegroundColor = DefaultAccentColor;
            Code.ForegroundColor = DefaultTextColor;
            Code.BackgroundColor = DefaultCodeBackground;
            Quote.ForegroundColor = DefaultQuoteTextColor;
            Quote.BorderColor = DefaultQuoteBorderColor;
            Separator.BorderColor = DefaultSeparatorColor;
        }

        public static readonly Color DefaultBackgroundColor = Color.FromHex("#ffffff");

        public static readonly Color DefaultAccentColor = Color.FromHex("#0366d6");

        public static readonly Color DefaultTextColor = Color.FromHex("#24292e");

        public static readonly Color DefaultCodeBackground = Color.FromHex("#f6f8fa");

        public static readonly Color DefaultSeparatorColor = Color.FromHex("#eaecef");

        public static readonly Color DefaultQuoteTextColor = Color.FromHex("#6a737d");

        public static readonly Color DefaultQuoteBorderColor = Color.FromHex("#dfe2e5");
    }

    public class DarkMarkdownTheme : MarkdownTheme
    {
        public DarkMarkdownTheme()
        {
            BackgroundColor = DefaultBackgroundColor;
            Paragraph.ForegroundColor = DefaultTextColor;
            Heading1.ForegroundColor = DefaultTextColor;
            Heading1.BorderColor = DefaultSeparatorColor;
            Heading2.ForegroundColor = DefaultTextColor;
            Heading2.BorderColor = DefaultSeparatorColor;
            Heading3.ForegroundColor = DefaultTextColor;
            Heading4.ForegroundColor = DefaultTextColor;
            Heading5.ForegroundColor = DefaultTextColor;
            Heading6.ForegroundColor = DefaultTextColor;
            Link.ForegroundColor = DefaultAccentColor;
            Code.ForegroundColor = DefaultTextColor;
            Code.BackgroundColor = DefaultCodeBackground;
            Quote.ForegroundColor = DefaultQuoteTextColor;
            Quote.BorderColor = DefaultQuoteBorderColor;
            Separator.BorderColor = DefaultSeparatorColor;
        }

        public static readonly Color DefaultBackgroundColor = Color.FromHex("#2b303b");

        public static readonly Color DefaultAccentColor = Color.FromHex("#d08770");

        public static readonly Color DefaultTextColor = Color.FromHex("#eff1f5");

        public static readonly Color DefaultCodeBackground = Color.FromHex("#4f5b66");

        public static readonly Color DefaultSeparatorColor = Color.FromHex("#65737e");

        public static readonly Color DefaultQuoteTextColor = Color.FromHex("#a7adba");

        public static readonly Color DefaultQuoteBorderColor = Color.FromHex("#a7adba");
    }
}
