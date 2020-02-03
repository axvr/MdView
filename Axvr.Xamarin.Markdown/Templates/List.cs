using System.Collections.Generic;
using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Templates
{
    /// <summary>
    /// The <c>BindingContext</c> object passed to <see cref="MdView.UnorderedListTemplate"/>
    /// and <see cref="MdView.OrderedListTemplate"/> on construction.
    /// </summary>
    public class ListAstNode
    {
        /// <summary>
        /// The views which should be the body of each list item.
        /// </summary>
        public IEnumerable<View> Views { get; set; }
    }

    /// <summary>
    /// Markdown "ordered list" template view. Intended for use as <see cref="MdView.OrderedListTemplate"/>.
    /// </summary>
    /// <remarks>
    /// The control will be passed required data as a <see cref="ListAstNode"/>
    /// object set as the <c>BindingContext</c> of the object; firing the
    /// <see cref="OnBindingContextChanged"/> event handler, which renders the
    /// Markdown.
    /// </remarks>
    public class OrderedList : StackLayout
    {
        /// <summary>
        /// Builds a new default <see cref="OrderedList"/> template.
        /// </summary>
        public OrderedList() : base()
        {
            Spacing = 0;
        }

        /// <inheritdoc cref="Label.OnBindingContextChanged"/>
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

    /// <summary>
    /// Markdown "unordered list" template view. Intended for use as <see cref="MdView.UnorderedListTemplate"/>.
    /// </summary>
    /// <remarks>
    /// The control will be passed required data as a <see cref="ListAstNode"/>
    /// object set as the <c>BindingContext</c> of the object; firing the
    /// <see cref="OnBindingContextChanged"/> event handler, which renders the
    /// Markdown.
    /// </remarks>
    public class UnorderedList : StackLayout
    {
        /// <summary>
        /// Builds a new <see cref="UnorderedList"/> template.
        /// </summary>
        public UnorderedList() : base()
        {
            Spacing = 0;
        }

        /// <inheritdoc cref="Label.OnBindingContextChanged"/>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is ListAstNode node)
            {
                Children.Clear();

                foreach (var view in node.Views)
                {
                    var item = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal
                    };

                    item.Children.Add(new Label { Text = "•" });
                    item.Children.Add(view);

                    Children.Add(item);
                }
            }
        }
    }
}
