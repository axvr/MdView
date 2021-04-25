using System.Collections.Generic;
using Xamarin.Forms;

namespace MdView.Templates
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
    public abstract class List : Grid
    {
        /// <summary>
        /// Builds a new default <see cref="OrderedList"/> template.
        /// </summary>
        public List() : base()
        {
            RowSpacing = 0;
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = GridLength.Auto },
                new ColumnDefinition { Width = GridLength.Auto }
            };
        }

        /// <inheritdoc cref="Label.OnBindingContextChanged"/>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext is ListData node)
            {
                Children.Clear();

                RowDefinitions = new RowDefinitionCollection();

                int realIndex = 0, visualIndex = 0;

                foreach (var view in node.Views)
                {
                    RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                    // Hide bullet on nested lists.
                    if (! (view is List))
                    {
                        var bullet = GetBulletView(visualIndex);

                        if (bullet != null)
                        {
                            Children.Add(bullet, 0, realIndex);
                        }

                        visualIndex++;
                    }

                    Children.Add(view, 1, realIndex);

                    realIndex++;
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
            return new Label { Text = $"{position + 1}.", Style = BulletStyle };
        }


        /// <inheritdoc cref="BulletStyle"/>
        public static readonly BindableProperty BulletStyleProperty =
            BindableProperty.Create(
                propertyName: nameof(BulletStyle),
                returnType: typeof(Style),
                declaringType: typeof(OrderedList),
                defaultValue: new Style(typeof(Label)));

        /// <summary>
        /// Set style of list bullet.
        /// </summary>
        ///
        /// <remarks>
        /// A list bullet is a <see cref="Label"/>.
        /// </remarks>
        public Style BulletStyle
        {
            get => (Style)GetValue(BulletStyleProperty);
            set => SetValue(BulletStyleProperty, value);
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
            return new Label { Text = "•", Style = BulletStyle };
        }


        /// <inheritdoc cref="BulletStyle"/>
        public static readonly BindableProperty BulletStyleProperty =
            BindableProperty.Create(
                propertyName: nameof(BulletStyle),
                returnType: typeof(Style),
                declaringType: typeof(UnorderedList),
                defaultValue: new Style(typeof(Label)));

        /// <inheritdoc cref="OrderedList.BulletStyle"/>
        public Style BulletStyle
        {
            get => (Style)GetValue(BulletStyleProperty);
            set => SetValue(BulletStyleProperty, value);
        }
    }
}
