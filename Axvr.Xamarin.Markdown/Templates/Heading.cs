using System.Linq;
using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Templates
{
    public class HeadingAstNode
    {
        public string Text { get; set; }
        public FormattedString FormattedText { get; set; }
        public FontAttributes FontAttributes { get; set; } = FontAttributes.None;
        public TextDecorations TextDecorations { get; set; } = TextDecorations.None;
    }

    public class Heading : Label
    {
        public Heading() : base()
        {
            FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label));
            FontAttributes = FontAttributes.Bold;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is HeadingAstNode node)
            {
                if (node.FormattedText == null)
                {
                    Text = node.Text;
                }
                else
                {
                    FontAttributes = FontAttributes | node.FontAttributes;
                    TextDecorations = TextDecorations | node.TextDecorations;

                    // NOTE: fixes https://github.com/xamarin/Xamarin.Forms/issues/6734
                    foreach (var span in node.FormattedText.Spans)
                    {
                        span.FontSize = FontSize;
                        span.FontAttributes = span.FontAttributes | FontAttributes;
                        //span.FontFamily = FontFamily;
                        span.TextDecorations = span.TextDecorations | TextDecorations;
                        span.CharacterSpacing = CharacterSpacing;
                        span.LineHeight = LineHeight;
                        span.Parent = this;
                    }

                    FormattedText = node.FormattedText;
                }
            }
        }
    }

    public class Heading1 : Heading
    { }

    public class Heading2 : Heading
    {
        public Heading2() : base()
        {
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
        }
    }

    public class Heading3 : Heading
    {
        public Heading3() : base()
        {
            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
        }
    }

    public class Heading4 : Heading
    {
        public Heading4() : base()
        {
            FontSize = 16;
        }
    }

    public class Heading5 : Heading
    {
        public Heading5() : base()
        {
            FontSize = 14;
        }
    }

    public class Heading6 : Heading
    {
        public Heading6() : base()
        {
            FontSize = 12;
        }
    }
}
