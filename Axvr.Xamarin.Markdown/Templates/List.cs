using System.Collections.Generic;
using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Templates
{
    /// <summary>
    /// The <c>BindingContext</c> object passed to <see cref="MdView.UnorderedListTemplate"/>
    /// and <see cref="MdView.OrderedListTemplate"/> on construction.
    /// </summary>
    public class ListData
    {
        /// <summary>
        /// The views which should be the body of each list item.
        /// </summary>
        public IEnumerable<View> Views { get; set; }
    }


    /// <summary>
    /// Abstract representation of a Markdown list.
    /// </summary>
    ///
    /// <remarks>
    /// Controls inheriting from this will be passed the child items in a
    /// <see cref="ListData"/> object set as the <c>BindingContext</c> of the
    /// control; firing the <see cref="List.OnBindingContextChanged"/> event
    /// handler, which renders the Markdown.
    /// </remarks>
    public abstract class List : StackLayout
    {
        /// <summary>
        /// Builds a new default <see cref="OrderedList"/> template.
        /// </summary>
        public List() : base()
        {
            Spacing = 0;
        }

        /// <inheritdoc cref="Label.OnBindingContextChanged"/>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is ListData node)
            {
                Children.Clear();

                int position = 0;

                foreach (var view in node.Views)
                {
                    var item = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal
                    };

                    var bullet = GetBulletView(position);

                    if (bullet != null)
                    {
                        // Handle nested lists.
                        if (view is List)
                        {
                            position--;  // Counteract the increment later on.
                            bullet.Opacity = 0;
                        }

                        item.Children.Add(bullet);
                    }

                    item.Children.Add(view);

                    Children.Add(item);

                    position++;
                }
            }
        }

        /// <summary>
        /// Get the view to represent the bullet of item at <paramref name="position"/>.
        /// </summary>
        ///
        /// <param name="position">0-indexed list item position.</param>
        /// <returns>A view representing the bullet.</returns>
        protected abstract View GetBulletView(int position);
    }


    /// <summary>
    /// Markdown "ordered list" template view.
    /// </summary>
    ///
    /// <remarks>
    /// Intended for use as <see cref="MdView.OrderedListTemplate"/>.
    ///
    /// The control will be passed required data as a <see cref="ListData"/>
    /// object set as the <c>BindingContext</c> of the object; firing the
    /// <see cref="List.OnBindingContextChanged"/> event handler, which renders the
    /// Markdown.
    /// </remarks>
    public class OrderedList : List
    {
        /// <inheritdoc cref="List.GetBulletView(int)"/>
        protected override View GetBulletView(int position)
        {
            return new Label { Text = $"{position + 1}." };
        }
    }


    /// <summary>
    /// Markdown "unordered list" template view.
    /// </summary>
    ///
    /// <remarks>
    /// Intended for use as <see cref="MdView.UnorderedListTemplate"/>.
    ///
    /// The control will be passed required data as a <see cref="ListData"/>
    /// object set as the <c>BindingContext</c> of the object; firing the
    /// <see cref="List.OnBindingContextChanged"/> event handler, which renders the
    /// Markdown.
    /// </remarks>
    public class UnorderedList : List
    {
        /// <inheritdoc cref="List.GetBulletView(int)"/>
        protected override View GetBulletView(int position)
        {
            return new Label { Text = "•" };
        }
    }
}
