using System;
using Xamarin.Forms;

namespace MdView.Templates
{
    /// <summary>
    /// Attributes of a span which <see cref="MdView.SpanTemplate"/> is expected to render.
    /// </summary>
    ///
    /// <remarks>
    /// More than one attribute can be used.
    /// </remarks>
    [Flags]
    public enum SpanAttributes
    {
        /// <summary>No attributes.</summary>
        None = 0x0,

        /// <summary>Bold attribute.</summary>
        Bold = 0x1,

        /// <summary>Italic attribute.</summary>
        Italic = 0x2,

        /// <summary>Link attribute.</summary>
        Link = 0x4,

        /// <summary>Inline code attribute.</summary>
        Monospace = 0x8

        // TODO: Underline and strikethrough.
    }


    /// <summary>
    /// The <c>BindingContext</c> object passed to <see cref="MdView.SpanTemplate"/> on construction.
    /// </summary>
    public class SpanData
    {
        /// <summary>
        /// Text within the span.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Attributes which change how a span looks visually.
        /// </summary>
        public SpanAttributes Attributes { get; set; } = SpanAttributes.None;
    }


    /// <summary>
    /// Markdown "span" template view.  Handles rendering of bold and italic text,
    /// links and inline code.
    /// </summary>
    ///
    /// <remarks>
    /// Intended for use as <see cref="MdView.SpanTemplate"/>.
    ///
    /// The control will be passed required data as a <see cref="SpanData"/>
    /// object set as the <c>BindingContext</c> of the object; firing the
    /// <see cref="OnBindingContextChanged"/> event handler, which renders the Markdown.
    /// </remarks>
    public class Span : global::Xamarin.Forms.Span
    {
        private void RenderSpanMarkdown()
        {
            if (BindingContext is SpanData data)
            {
                Text = data.Text;

                if (data.Attributes.HasFlag(SpanAttributes.Bold))
                {
                    FontAttributes |= FontAttributes.Bold;
                }

                if (data.Attributes.HasFlag(SpanAttributes.Italic))
                {
                    FontAttributes |= FontAttributes.Italic;
                }

                if (data.Attributes.HasFlag(SpanAttributes.Link))
                {
                    TextColor = LinkTextColor;
                    TextDecorations |= TextDecorations.Underline;
                }

                if (data.Attributes.HasFlag(SpanAttributes.Monospace))
                {
                    Text = $"\u00A0{Text}\u00A0";

                    ForegroundColor = InlineCodeForegroundColor;
                    BackgroundColor = InlineCodeBackgroundColor;
                    FontFamily = InlineCodeFontFamily;
                }
            }
        }


        /// <inheritdoc cref="Span.OnBindingContextChanged"/>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            RenderSpanMarkdown();
        }


        private static void OnSpanStylePropertiesChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is Span self && oldValue != newValue)
            {
                self.OnBindingContextChanged();
            }
        }


        #region InlineCode

        /// <inheritdoc cref="InlineCodeForegroundColor"/>
        public static readonly BindableProperty InlineCodeForegroundColorProperty =
            BindableProperty.Create(
                propertyName: nameof(InlineCodeForegroundColor),
                returnType: typeof(Color),
                declaringType: typeof(Span),
                defaultValue: Color.FromHex("#24292e"),
                propertyChanged: OnSpanStylePropertiesChanged);

        /// <summary>
        /// Foreground colour for inline code spans.
        /// </summary>
        public Color InlineCodeForegroundColor
        {
            get => (Color)GetValue(InlineCodeForegroundColorProperty);
            set => SetValue(InlineCodeForegroundColorProperty, value);
        }


        /// <inheritdoc cref="InlineCodeBackgroundColor"/>
        public static readonly BindableProperty InlineCodeBackgroundColorProperty =
            BindableProperty.Create(
                propertyName: nameof(InlineCodeBackgroundColor),
                returnType: typeof(Color),
                declaringType: typeof(Span),
                defaultValue: Color.FromHex("#f6f8fa"),
                propertyChanged: OnSpanStylePropertiesChanged);

        /// <summary>
        /// Background colour for inline code spans.
        /// </summary>
        public Color InlineCodeBackgroundColor
        {
            get => (Color)GetValue(InlineCodeBackgroundColorProperty);
            set => SetValue(InlineCodeBackgroundColorProperty, value);
        }


        /// <inheritdoc cref="InlineCodeFontFamily"/>
        public static readonly BindableProperty InlineCodeFontFamilyProperty =
            BindableProperty.Create(
                propertyName: nameof(InlineCodeFontFamily),
                returnType: typeof(string),
                declaringType: typeof(Span),
                defaultValue: Device.RuntimePlatform == Device.iOS ? "Courier" : "monospace",
                propertyChanged: OnSpanStylePropertiesChanged);

        /// <summary>
        /// Font family for inline code spans.
        /// </summary>
        public string InlineCodeFontFamily
        {
            get => (string)GetValue(InlineCodeFontFamilyProperty);
            set => SetValue(InlineCodeFontFamilyProperty, value);
        }

        #endregion InlineCode


        #region Link

        /// <inheritdoc cref="LinkTextColor"/>
        public static readonly BindableProperty LinkTextColorProperty =
            BindableProperty.Create(
                propertyName: nameof(LinkTextColor),
                returnType: typeof(Color),
                declaringType: typeof(Span),
                defaultValue: Color.FromHex("#0000EE"),
                propertyChanged: OnSpanStylePropertiesChanged);

        /// <summary>
        /// Text colour for link spans.
        /// </summary>
        ///
        /// <remarks>
        /// Typically blue.
        /// </remarks>
        public Color LinkTextColor
        {
            get => (Color)GetValue(LinkTextColorProperty);
            set => SetValue(LinkTextColorProperty, value);
        }

        #endregion Link
    }
}
