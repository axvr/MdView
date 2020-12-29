using System;
using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Templates
{
    [Flags]
    public enum SpanAttributes
    {
        None = 0x0,
        Bold = 0x1,
        Italic = 0x2,
        Link = 0x4,
        Monospace = 0x8
        // TODO: Underline and strikethrough.
    }


    public class SpanData
    {
        public string Text { get; set; }
        public SpanAttributes Attributes { get; set; } = SpanAttributes.None;
    }


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

        public static readonly BindableProperty InlineCodeForegroundColorProperty =
            BindableProperty.Create(
                propertyName: nameof(InlineCodeForegroundColor),
                returnType: typeof(Color),
                declaringType: typeof(Span),
                defaultValue: Color.FromHex("#24292e"),
                propertyChanged: OnSpanStylePropertiesChanged);

        public Color InlineCodeForegroundColor
        {
            get => (Color)GetValue(InlineCodeForegroundColorProperty);
            set => SetValue(InlineCodeForegroundColorProperty, value);
        }


        public static readonly BindableProperty InlineCodeBackgroundColorProperty =
            BindableProperty.Create(
                propertyName: nameof(InlineCodeBackgroundColor),
                returnType: typeof(Color),
                declaringType: typeof(Span),
                defaultValue: Color.FromHex("#f6f8fa"),
                propertyChanged: OnSpanStylePropertiesChanged);

        public Color InlineCodeBackgroundColor
        {
            get => (Color)GetValue(InlineCodeBackgroundColorProperty);
            set => SetValue(InlineCodeBackgroundColorProperty, value);
        }


        public static readonly BindableProperty InlineCodeFontFamilyProperty =
            BindableProperty.Create(
                propertyName: nameof(InlineCodeFontFamily),
                returnType: typeof(string),
                declaringType: typeof(Span),
                defaultValue: Device.RuntimePlatform == Device.iOS ? "Courier" : "monospace",
                propertyChanged: OnSpanStylePropertiesChanged);

        public string InlineCodeFontFamily
        {
            get => (string)GetValue(InlineCodeFontFamilyProperty);
            set => SetValue(InlineCodeFontFamilyProperty, value);
        }

        #endregion InlineCode


        #region Link

        public static readonly BindableProperty LinkTextColorProperty =
            BindableProperty.Create(
                propertyName: nameof(LinkTextColor),
                returnType: typeof(Color),
                declaringType: typeof(Span),
                defaultValue: Color.FromHex("#0000EE"),
                propertyChanged: OnSpanStylePropertiesChanged);

        public Color LinkTextColor
        {
            get => (Color)GetValue(LinkTextColorProperty);
            set => SetValue(LinkTextColorProperty, value);
        }

        #endregion Link
    }
}
