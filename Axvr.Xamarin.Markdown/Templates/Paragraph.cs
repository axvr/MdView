using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Templates
{
    public class ParagraphAstNode
    {
        public string Text { get; set; }
        public FormattedString FormattedText { get; set; }
        public FontAttributes FontAttributes { get; set; } = FontAttributes.None;
        public TextDecorations TextDecorations { get; set; } = TextDecorations.None;
    }

    public class Paragraph : Label
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is ParagraphAstNode node)
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
}
