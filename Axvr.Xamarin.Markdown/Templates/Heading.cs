using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Templates
{
    /// <summary>
    /// The <c>BindingContext</c> object for heading views, used to pass
    /// required data to the Markdown heading templates.
    /// </summary>
    /// <seealso cref="MdView.Heading1Template"/>
    /// <seealso cref="MdView.Heading2Template"/>
    /// <seealso cref="MdView.Heading3Template"/>
    /// <seealso cref="MdView.Heading4Template"/>
    /// <seealso cref="MdView.Heading5Template"/>
    /// <seealso cref="MdView.Heading6Template"/>
    public class HeadingAstNode
    {
        public string Text { get; set; }
        public FormattedString FormattedText { get; set; }
    }

    /// <summary>
    /// Base Markdown "heading" template view. Intended for use in <see cref="MdView"/>.
    /// </summary>
    /// <remarks>
    /// The control will be passed required data as a <see cref="HeadingAstNode"/>
    /// object set as the <c>BindingContext</c> of the object; firing the
    /// <see cref="OnBindingContextChanged"/> event handler, which renders the Markdown.
    /// </remarks>
    public abstract class Heading : Label
    {
        /// <summary>
        /// Builds a new default heading template instance.
        /// </summary>
        public Heading() : base()
        {
            FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label));
            FontAttributes = FontAttributes.Bold;
        }

        /// <inheritdoc cref="Label.OnBindingContextChanged"/>
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
                    // NOTE: fixes https://github.com/xamarin/Xamarin.Forms/issues/6734
                    foreach (var span in node.FormattedText.Spans)
                    {
                        span.FontSize = FontSize;
                        span.FontAttributes = span.FontAttributes | FontAttributes;
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

    /// <summary>
    /// Markdown "heading 1" template view. Intended for use as <see cref="MdView.Heading1Template"/>.
    /// </summary>
    public class Heading1 : Heading
    { }

    /// <summary>
    /// Markdown "heading 2" template view. Intended for use as <see cref="MdView.Heading2Template"/>.
    /// </summary>
    public class Heading2 : Heading
    {
        /// <inheritdoc cref="Heading.Heading"/>
        public Heading2() : base()
        {
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
        }
    }

    /// <summary>
    /// Markdown "heading 3" template view. Intended for use as <see cref="MdView.Heading3Template"/>.
    /// </summary>
    public class Heading3 : Heading
    {
        /// <inheritdoc cref="Heading.Heading"/>
        public Heading3() : base()
        {
            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
        }
    }

    /// <summary>
    /// Markdown "heading 4" template view. Intended for use as <see cref="MdView.Heading4Template"/>.
    /// </summary>
    public class Heading4 : Heading
    {
        /// <inheritdoc cref="Heading.Heading"/>
        public Heading4() : base()
        {
            FontSize = 16;
        }
    }

    /// <summary>
    /// Markdown "heading 5" template view. Intended for use as <see cref="MdView.Heading5Template"/>.
    /// </summary>
    public class Heading5 : Heading
    {
        /// <inheritdoc cref="Heading.Heading"/>
        public Heading5() : base()
        {
            FontSize = 14;
        }
    }

    /// <summary>
    /// Markdown "heading 6" template view. Intended for use as <see cref="MdView.Heading6Template"/>.
    /// </summary>
    public class Heading6 : Heading
    {
        /// <inheritdoc cref="Heading.Heading"/>
        public Heading6() : base()
        {
            FontSize = 12;
        }
    }
}
