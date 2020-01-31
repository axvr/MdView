using System.Collections.Generic;
using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Templates
{
    public class ListAstNode
    {
        public IEnumerable<View> Views { get; set; }
    }

    public class OrderedList : StackLayout
    {
        public OrderedList() : base()
        {
            Spacing = 0;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is ListAstNode node)
            {
                Children.Clear();

                int order = 1;

                foreach (var view in node.Views)
                {
                    var item = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal
                    };

                    item.Children.Add(new Label { Text = $"{order}." });
                    item.Children.Add(view);

                    Children.Add(item);

                    order++;
                }
            }
        }
    }

    public class UnorderedList : StackLayout
    {
        public UnorderedList() : base()
        {
            Spacing = 0;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is ListAstNode node)
            {
                Children.Clear();

                int order = 1;

                foreach (var view in node.Views)
                {
                    var item = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal
                    };

                    item.Children.Add(new Label { Text = "•" });
                    item.Children.Add(view);

                    Children.Add(item);

                    order++;
                }
            }
        }
    }
}
