using MdView.Templates;
using Xamarin.Forms;

namespace MdView.Sample.Controls
{
    public class CaptionedImage : StackLayout
    {
        public CaptionedImage()
        {
            Children.Add(_image);
            Children.Add(_caption);
        }


        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is ImageData image)
            {
                _image.Source = image.Uri;
                _image.IsVisible = !string.IsNullOrEmpty(image.Uri);

                _caption.Text = image.Title;
                _caption.IsVisible = !string.IsNullOrEmpty(image.Title);
            }
        }


        public global::Xamarin.Forms.Image _image = new ResizableImage { IsVisible = false };

        public static readonly BindableProperty ImageStyleProperty = BindableProperty.Create(
            propertyName: nameof(ImageStyle),
            returnType: typeof(Style),
            declaringType: typeof(CaptionedImage),
            defaultValue: new Style(typeof(global::Xamarin.Forms.Image)),
            propertyChanged: OnImageStyleChanged);

        public Style ImageStyle
        {
            get => (Style)GetValue(ImageStyleProperty);
            set => SetValue(ImageStyleProperty, value);
        }

        private static void OnImageStyleChanged(object bindable, object oldValue, object newValue)
        {
            if (bindable is CaptionedImage self && newValue is Style style)
            {
                self._image.Style = style;
            }
        }


        public Label _caption = new Label { HorizontalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.CenterAndExpand, IsVisible = false };

        public static readonly BindableProperty CaptionStyleProperty = BindableProperty.Create(
            propertyName: nameof(CaptionStyle),
            returnType: typeof(Style),
            declaringType: typeof(CaptionedImage),
            defaultValue: new Style(typeof(Label)),
            propertyChanged: OnCaptionStyleChanged);

        public Style CaptionStyle
        {
            get => (Style)GetValue(CaptionStyleProperty);
            set => SetValue(CaptionStyleProperty, value);
        }

        private static void OnCaptionStyleChanged(object bindable, object oldValue, object newValue)
        {
            if (bindable is CaptionedImage self && newValue is Style style)
            {
                self._caption.Style = style;
            }
        }
    }
}
