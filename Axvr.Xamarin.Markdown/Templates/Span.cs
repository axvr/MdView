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
        // TODO: make this default control more configurable.

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

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
                    TextColor = Color.FromHex("#0000EE");
                    TextDecorations |= TextDecorations.Underline;
                }

                if (data.Attributes.HasFlag(SpanAttributes.Monospace))
                {
                    Text = $"\u00A0{Text}\u00A0";

                    ForegroundColor = Color.FromHex("#24292e");
                    BackgroundColor = Color.FromHex("#f6f8fa");
                    FontFamily = Device.RuntimePlatform == Device.iOS
                               ? "Courier"
                               : "monospace";
                }
            }
        }
    }
}
