using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Templates
{
    public class BlockQuoteAstNode
    {
        public View View { get; set; }
    }

    public class BlockQuote : Frame
    {
        public BlockQuote() : base()
        {
            HasShadow = false;
            Padding = 0;
            Opacity = 0.9;

            _content.Children.Add(_separator);

            Content = _content;
        }

        private readonly StackLayout _content = new StackLayout { Orientation = StackOrientation.Horizontal };
        private readonly BoxView _separator = new BoxView { WidthRequest = 4, Color = Color.FromHex("#eaecef") };

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is BlockQuoteAstNode node)
            {
                if (_content.Children.Count > 1)
                {
                    _content.Children.RemoveAt(1);
                }

                _content.Children.Add(node.View);
            }
        }
    }
}
