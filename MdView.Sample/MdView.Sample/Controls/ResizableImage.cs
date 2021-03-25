using MdView.Templates;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Xamarin.Forms;

namespace MdView.Sample.Controls
{
    public class ResizableImage : global::Xamarin.Forms.Image
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is ImageData image)
            {
                Source = image.Uri;
            }
        }


        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == SourceProperty.PropertyName)
            {
                var uriSource = Source.GetValue(UriImageSource.UriProperty) as Uri;

                if (uriSource == null)
                {
                    var fileSource = Source
                        .GetValue(FileImageSource.FileProperty)
                        .ToString()
                        .Split(new[] { '?' }, count: 2, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    if (fileSource.Count == 2)
                    {
                        Source = fileSource.First();
                        ResizeImage(fileSource.Last());
                    }
                }
                else
                {
                    ResizeImage(uriSource.Query);
                }
            }

            base.OnPropertyChanging(propertyName);
        }


        private void ResizeImage(string queryString)
        {
            var queryParams = HttpUtility.ParseQueryString(queryString);

            if (queryParams.TryGet("mdview_height_request", out var heightRequestStr)
             && double.TryParse(heightRequestStr, out var heightRequest))
            {
                HeightRequest = heightRequest;
            }

            if (queryParams.TryGet("mdview_width_request", out var widthRequestStr)
             && double.TryParse(widthRequestStr, out var widthRequest))
            {
                WidthRequest = widthRequest;
            }

            if (queryParams.TryGet("mdview_margin", out var marginStr))
            {
                var vals = marginStr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                vals = vals.Select(x => x.Trim()).ToList();

                if (vals.Count == 1)
                {
                    if (double.TryParse(vals.First(), out var uniformSize))
                    {
                        Margin = new Thickness(uniformSize);
                    }
                }
                else if (vals.Count == 2)
                {
                    if (double.TryParse(vals[0], out var horizontalSize)
                     && double.TryParse(vals[1], out var verticalSize))
                    {
                        Margin = new Thickness(horizontalSize, verticalSize);
                    }
                }
                else if (vals.Count == 4)
                {
                    if (double.TryParse(vals[0], out var left) && double.TryParse(vals[1], out var top)
                     && double.TryParse(vals[2], out var right) && double.TryParse(vals[3], out var bottom))
                    {
                        Margin = new Thickness(left, top, right, bottom);
                    }
                }
            }
        }
    }


    public static class NameValueCollectionExtensions
    {
        public static bool TryGet(this NameValueCollection col, string key, out string val)
        {
            val = col.Get(key);
            return val != null;
        }
    }
}
