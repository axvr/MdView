using System.Linq;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Essentials;
using System.Text;

namespace MdView
{
    /// <summary>
    /// Markdown renderer.
    /// </summary>
    public class MdView : StackLayout
    {
        /// <summary>
        /// Default constructor to instantiate a new instance of the MdView Markdown render.
        /// </summary>
        public MdView() : base()
        {
            Spacing = 10;
        }


        /// <summary>
        /// Link handler.
        /// </summary>
        ///
        /// <remarks>
        /// Invoked whenever a Markdown link is clicked.
        /// </remarks>
        public Action<string> NavigateToLink { get; set; } = (s) => Launcher.TryOpenAsync(s);


        /// <summary>
        /// The Markdown string that will be rendered by MdView.
        /// </summary>
        public string Markdown
        {
            get => (string)GetValue(MarkdownProperty);
            set => SetValue(MarkdownProperty, value);
        }

        /// <inheritdoc cref="Markdown"/>
        public static readonly BindableProperty MarkdownProperty =
            BindableProperty.Create(
                propertyName: nameof(Markdown),
                returnType: typeof(string),
                declaringType: typeof(MdView),
                defaultValue: null,
                propertyChanged: OnMarkdownChanged);


        private static void OnMarkdownChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as MdView;
            view.RenderMarkdown();
        }


        private void RenderMarkdown()
        {
            Children.Clear();

            if (!string.IsNullOrEmpty(Markdown))
            {
                var parsed = Markdig.Markdown.Parse(Markdown);
                var views = RenderBlocks(parsed.AsEnumerable());

                foreach (var view in views)
                {
                    Children.Add(view);
                }
            }
        }


        private IEnumerable<View> RenderBlocks(IEnumerable<Block> blocks)
        {
            var views = new List<View>();

            foreach (var block in blocks)
            {
                foreach (var view in Render(block))
                {
                    // Remove "Null" items from the rendered Markdown content.
                    if (view is Templates.Null) continue;

                    views.Add(view);
                }
            }

            return views;
        }


        private List<KeyValuePair<string, string>> links = new List<KeyValuePair<string, string>>();


        private void AttachLinks(View view)
        {
            if (links.Any())
            {
                var blockLinks = links;
                // TODO: extract this out to be controlled by NavigateToLink.
                view.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(async () =>
                    {
                        try
                        {
                            if (blockLinks.Count > 1)
                            {
                                var result = await Application.Current.MainPage.DisplayActionSheet("Open link", "Cancel", null, blockLinks.Select(x => x.Key).ToArray());
                                var link = blockLinks.FirstOrDefault(x => x.Key == result);
                                NavigateToLink(link.Value);
                            }
                            else
                            {
                                NavigateToLink(blockLinks.First().Value);
                            }
                        }
                        catch (Exception) { }
                    }),
                });

                links = new List<KeyValuePair<string, string>>();
            }
        }


        #region Templates

        private static BindableProperty CreateTemplateProperty(string propertyName, Type defaultValue)
        {
            return BindableProperty.Create(
                propertyName: propertyName,
                returnType: typeof(DataTemplate),
                declaringType: typeof(MdView),
                defaultValue: new DataTemplate(defaultValue),
                propertyChanged: OnMarkdownChanged);
        }


        /// <summary>
        /// <see cref="DataTemplate"/> representing a Markdown heading of level 1.
        /// </summary>
        ///
        /// <remarks>
        /// Data required by the DataTemplate comes from a <see cref="Templates.HeadingData"/>
        /// object set as the <c>BindingContext</c>.
        /// </remarks>
        ///
        /// <example>
        /// <code>
        /// # Heading 1
        /// </code>
        /// </example>
        public DataTemplate Heading1Template
        {
            get => (DataTemplate)GetValue(Heading1TemplateProperty);
            set => SetValue(Heading1TemplateProperty, value);
        }

        /// <inheritdoc cref="Heading1Template"/>
        public static readonly BindableProperty Heading1TemplateProperty =
            CreateTemplateProperty(nameof(Heading1Template), typeof(Templates.Heading1));


        /// <summary>
        /// <see cref="DataTemplate"/> representing a Markdown heading of level 2.
        /// </summary>
        ///
        /// <remarks>
        /// Data required by the DataTemplate comes from a <see cref="Templates.HeadingData"/>
        /// object set as the <c>BindingContext</c>.
        /// </remarks>
        ///
        /// <example>
        /// <code>
        /// ## Heading 2
        /// </code>
        /// </example>
        public DataTemplate Heading2Template
        {
            get => (DataTemplate)GetValue(Heading2TemplateProperty);
            set => SetValue(Heading2TemplateProperty, value);
        }

        /// <inheritdoc cref="Heading2Template"/>
        public static readonly BindableProperty Heading2TemplateProperty =
            CreateTemplateProperty(nameof(Heading2Template), typeof(Templates.Heading2));


        /// <summary>
        /// <see cref="DataTemplate"/> representing a Markdown heading of level 3.
        /// </summary>
        ///
        /// <remarks>
        /// Data required by the DataTemplate comes from a <see cref="Templates.HeadingData"/>
        /// object set as the <c>BindingContext</c>.
        /// </remarks>
        ///
        /// <example>
        /// <code>
        /// ### Heading 3
        /// </code>
        /// </example>
        public DataTemplate Heading3Template
        {
            get => (DataTemplate)GetValue(Heading3TemplateProperty);
            set => SetValue(Heading3TemplateProperty, value);
        }

        /// <inheritdoc cref="Heading3Template"/>
        public static readonly BindableProperty Heading3TemplateProperty =
            CreateTemplateProperty(nameof(Heading3Template), typeof(Templates.Heading3));


        /// <summary>
        /// <see cref="DataTemplate"/> representing a Markdown heading of level 4.
        /// </summary>
        ///
        /// <remarks>
        /// Data required by the DataTemplate comes from a <see cref="Templates.HeadingData"/>
        /// object set as the <c>BindingContext</c>.
        /// </remarks>
        ///
        /// <example>
        /// <code>
        /// #### Heading 4
        /// </code>
        /// </example>
        public DataTemplate Heading4Template
        {
            get => (DataTemplate)GetValue(Heading4TemplateProperty);
            set => SetValue(Heading4TemplateProperty, value);
        }

        /// <inheritdoc cref="Heading4Template"/>
        public static readonly BindableProperty Heading4TemplateProperty =
            CreateTemplateProperty(nameof(Heading4Template), typeof(Templates.Heading4));


        /// <summary>
        /// <see cref="DataTemplate"/> representing a Markdown heading of level 5.
        /// </summary>
        ///
        /// <remarks>
        /// Data required by the DataTemplate comes from a <see cref="Templates.HeadingData"/>
        /// object set as the <c>BindingContext</c>.
        /// </remarks>
        ///
        /// <example>
        /// <code>
        /// ##### Heading 5
        /// </code>
        /// </example>
        public DataTemplate Heading5Template
        {
            get => (DataTemplate)GetValue(Heading5TemplateProperty);
            set => SetValue(Heading5TemplateProperty, value);
        }

        /// <inheritdoc cref="Heading5Template"/>
        public static readonly BindableProperty Heading5TemplateProperty =
            CreateTemplateProperty(nameof(Heading5Template), typeof(Templates.Heading5));


        /// <summary>
        /// <see cref="DataTemplate"/> representing a Markdown heading of level 6.
        /// </summary>
        ///
        /// <remarks>
        /// Data required by the DataTemplate comes from a <see cref="Templates.HeadingData"/>
        /// object set as the <c>BindingContext</c>.
        /// </remarks>
        ///
        /// <example>
        /// <code>
        /// ###### Heading 6
        /// </code>
        /// </example>
        public DataTemplate Heading6Template
        {
            get => (DataTemplate)GetValue(Heading6TemplateProperty);
            set => SetValue(Heading6TemplateProperty, value);
        }

        /// <inheritdoc cref="Heading6Template"/>
        public static readonly BindableProperty Heading6TemplateProperty =
            CreateTemplateProperty(nameof(Heading6Template), typeof(Templates.Heading6));

        /// <summary>
        /// <see cref="DataTemplate"/> representing a Markdown separator.
        /// </summary>
        ///
        /// <example>
        /// ---
        /// </example>
        public DataTemplate SeparatorTemplate
        {
            get => (DataTemplate)GetValue(SeparatorTemplateProperty);
            set => SetValue(SeparatorTemplateProperty, value);
        }

        /// <inheritdoc cref="SeparatorTemplate"/>
        public static readonly BindableProperty SeparatorTemplateProperty =
            CreateTemplateProperty(nameof(SeparatorTemplate), typeof(Templates.Separator));


        /// <summary>
        /// <see cref="DataTemplate"/> representing a Markdown paragraph.
        /// </summary>
        ///
        /// <remarks>
        /// Data required by the DataTemplate comes from a <see cref="Templates.ParagraphData"/>
        /// object set as the <c>BindingContext</c>.
        ///
        /// The styling of internal attributes such as bold and italic text is performed in the
        /// <see cref="SpanTemplate"/>.
        /// </remarks>
        ///
        /// <example>
        /// <code>
        /// Hello world.
        /// </code>
        /// </example>
        public DataTemplate ParagraphTemplate
        {
            get => (DataTemplate)GetValue(ParagraphTemplateProperty);
            set => SetValue(ParagraphTemplateProperty, value);
        }

        /// <inheritdoc cref="ParagraphTemplate"/>
        public static readonly BindableProperty ParagraphTemplateProperty =
            CreateTemplateProperty(nameof(ParagraphTemplate), typeof(Templates.Paragraph));


        /// <summary>
        /// <see cref="DataTemplate"/> representing a Markdown multiline code block.
        /// </summary>
        ///
        /// <remarks>
        /// Data required by the DataTemplate comes from a <see cref="Templates.CodeBlockData"/>
        /// object set as the <c>BindingContext</c>.
        /// </remarks>
        ///
        /// <example>
        /// <code>
        /// ```
        /// public string Hello(string name)
        /// {
        ///     return $"Hello {name}!";
        /// }
        /// ```
        /// </code>
        /// </example>
        public DataTemplate CodeBlockTemplate
        {
            get => (DataTemplate)GetValue(CodeBlockTemplateProperty);
            set => SetValue(CodeBlockTemplateProperty, value);
        }

        /// <inheritdoc cref="CodeBlockTemplate"/>
        public static readonly BindableProperty CodeBlockTemplateProperty =
            CreateTemplateProperty(nameof(CodeBlockTemplate), typeof(Templates.CodeBlock));


        /// <summary>
        /// <see cref="DataTemplate"/> representing a Markdown multiline block quote.
        /// </summary>
        ///
        /// <remarks>
        /// Data required by the DataTemplate comes from a <see cref="Templates.BlockQuoteData"/>
        /// object set as the <c>BindingContext</c>.
        /// </remarks>
        ///
        /// <example>
        /// <code>
        /// > This is a multiline block quote.
        /// >
        /// > They are very cool
        /// >
        /// > — Albert Einstein.
        /// </code>
        /// </example>
        public DataTemplate BlockQuoteTemplate
        {
            get => (DataTemplate)GetValue(BlockQuoteTemplateProperty);
            set => SetValue(BlockQuoteTemplateProperty, value);
        }

        /// <inheritdoc cref="BlockQuoteTemplate"/>
        public static readonly BindableProperty BlockQuoteTemplateProperty =
            CreateTemplateProperty(nameof(BlockQuoteTemplate), typeof(Templates.BlockQuote));


        /// <summary>
        /// <see cref="DataTemplate"/> representing a Markdown ordered list.
        /// </summary>
        ///
        /// <remarks>
        /// Data required by the DataTemplate comes from a <see cref="Templates.ListData"/>
        /// object set as the <c>BindingContext</c>.
        /// </remarks>
        ///
        /// <example>
        /// <code>
        /// 1. Hello world,
        /// 2. Foo,
        /// 3. Bar.
        /// </code>
        /// </example>
        public DataTemplate OrderedListTemplate
        {
            get => (DataTemplate)GetValue(OrderedListTemplateProperty);
            set => SetValue(OrderedListTemplateProperty, value);
        }

        /// <inheritdoc cref="OrderedListTemplate"/>
        public static readonly BindableProperty OrderedListTemplateProperty =
            CreateTemplateProperty(nameof(OrderedListTemplate), typeof(Templates.OrderedList));


        /// <summary>
        /// <see cref="DataTemplate"/> representing a Markdown unordered list.
        /// </summary>
        ///
        /// <remarks>
        /// Data required by the DataTemplate comes from a <see cref="Templates.ListData"/>
        /// object set as the <c>BindingContext</c>.
        /// </remarks>
        ///
        /// <example>
        /// <code>
        /// * Hello world,
        /// - Foo,
        /// + Bar.
        /// </code>
        /// </example>
        public DataTemplate UnorderedListTemplate
        {
            get => (DataTemplate)GetValue(UnorderedListTemplateProperty);
            set => SetValue(UnorderedListTemplateProperty, value);
        }

        /// <inheritdoc cref="UnorderedListTemplate"/>
        public static readonly BindableProperty UnorderedListTemplateProperty =
            CreateTemplateProperty(nameof(UnorderedListTemplate), typeof(Templates.UnorderedList));


        /// <summary>
        /// <see cref="DataTemplate"/> representing a Markdown image.
        /// </summary>
        ///
        /// <remarks>
        /// Data required by the DataTemplate comes from a <see cref="Templates.ImageData"/>
        /// object set as the <c>BindingContext</c>.
        /// </remarks>
        ///
        /// <example>
        /// <code>
        /// ![](https://unsplash.it/200/300 "This is the image title")
        /// </code>
        /// </example>
        public DataTemplate ImageTemplate
        {
            get => (DataTemplate)GetValue(ImageTemplateProperty);
            set => SetValue(ImageTemplateProperty, value);
        }

        /// <inheritdoc cref="ImageTemplate"/>
        public static readonly BindableProperty ImageTemplateProperty =
            CreateTemplateProperty(nameof(ImageTemplate), typeof(Templates.Image));


        /// <summary>
        /// <see cref="DataTemplate"/> representing an inline element (bold, italic, link, code)
        /// embedded within another textual template such as a paragraph, heading or block quote.
        /// </summary>
        ///
        /// <remarks>
        /// Data required by the DataTemplate comes from a <see cref="Templates.SpanData"/>
        /// object set as the <c>BindingContext</c>.
        /// </remarks>
        ///
        /// <example>
        /// <code>
        /// **Bold**, _italic_, [Link](https://example.com), `code`.
        /// </code>
        /// </example>
        public DataTemplate SpanTemplate
        {
            get => (DataTemplate)GetValue(SpanTemplateProperty);
            set => SetValue(SpanTemplateProperty, value);
        }

        /// <inheritdoc cref="SpanTemplate"/>
        public static readonly BindableProperty SpanTemplateProperty =
            CreateTemplateProperty(nameof(SpanTemplate), typeof(Templates.Span));


        #endregion


        #region Rendering blocks

        private List<View> queuedViews = new List<View>();


        private IEnumerable<View> Render(Block block)
        {
            var views = new List<View>();

            switch (block)
            {
                case HeadingBlock heading:
                    views.Add(Render(heading));
                    break;

                case ParagraphBlock paragraph:
                    views.Add(Render(paragraph));
                    break;

                case QuoteBlock quote:
                    views.Add(Render(quote));
                    break;

                case CodeBlock code:
                    views.Add(Render(code));
                    break;

                case ListBlock list:
                    views.Add(Render(list));
                    break;

                case ListItemBlock listItem:
                    views.AddRange(RenderBlocks(listItem.AsEnumerable()));
                    break;

                case ThematicBreakBlock thematicBreak:
                    views.Add(Render(thematicBreak));
                    break;

                default:
                    Debug.WriteLine($"Can't render {block.GetType()} blocks.");
                    break;
            }

            if (queuedViews.Any())
            {
                foreach (var view in queuedViews)
                {
                    views.Add(view);
                }

                queuedViews.Clear();
            }

            return views;
        }


        private View Render(ThematicBreakBlock _)
        {
            return SeparatorTemplate.CreateContent() as View;
        }


        private View Render(ListBlock block)
        {
            View list;

            if (block.IsOrdered)
            {
                list = OrderedListTemplate.CreateContent() as View;
            }
            else
            {
                list = UnorderedListTemplate.CreateContent() as View;
            }

            list.BindingContext = new Templates.ListData
            {
                Views = RenderBlocks(block.AsEnumerable())
            };

            return list;
        }


        private View Render(HeadingBlock block)
        {
            View heading;

            switch (block.Level)
            {
                case 1:
                    heading = Heading1Template.CreateContent() as View;
                    break;
                case 2:
                    heading = Heading2Template.CreateContent() as View;
                    break;
                case 3:
                    heading = Heading3Template.CreateContent() as View;
                    break;
                case 4:
                    heading = Heading4Template.CreateContent() as View;
                    break;
                case 5:
                    heading = Heading5Template.CreateContent() as View;
                    break;
                case 6:
                    heading = Heading6Template.CreateContent() as View;
                    break;
                default:
                    throw new NotImplementedException("Header levels 7+ are not implemented.");
            }

            var text = CreateText(block.Inline);

            heading.BindingContext = new Templates.HeadingData
            {
                Text = text.Unformatted,
                FormattedText = text.Formatted,
                Level = block.Level
            };

            AttachLinks(heading);

            return heading;
        }


        private View Render(ParagraphBlock block)
        {
            var paragraph = ParagraphTemplate.CreateContent() as View;

            var text = CreateText(block.Inline);

            paragraph.BindingContext = new Templates.ParagraphData
            {
                Text = text.Unformatted,
                FormattedText = text.Formatted
            };

            AttachLinks(paragraph);

            return paragraph;
        }


        private View Render(QuoteBlock block)
        {
            var blockQuote = BlockQuoteTemplate.CreateContent() as View;

            blockQuote.BindingContext = new Templates.BlockQuoteData
            {
                Views = RenderBlocks(block.AsEnumerable())
            };

            return blockQuote;
        }


        private View Render(CodeBlock block)
        {
            var codeblock = CodeBlockTemplate.CreateContent() as View;

            codeblock.BindingContext = new Templates.CodeBlockData
            {
                Text = string.Join(Environment.NewLine, block.Lines)
            };

            return codeblock;
        }


        #region Text

        private (string Unformatted, FormattedString Formatted) CreateText(ContainerInline inlines)
        {
            var formatted = CreateFormatted(inlines);
            var unformatted = CreateUnformatted(formatted);
            return (unformatted, formatted);
        }


        private string CreateUnformatted(FormattedString formattedString)
        {
            var str = new StringBuilder();

            foreach (var span in formattedString.Spans)
            {
                str.Append(span.Text);
            }

            return str.ToString();
        }


        private FormattedString CreateFormatted(ContainerInline inlines)
        {
            var fs = new FormattedString();

            foreach (var inline in inlines)
            {
                var spans = CreateSpans(inline);
                if (spans != null)
                {
                    foreach (var span in spans)
                    {
                        fs.Spans.Add(span);
                    }
                }
            }

            return fs;
        }

        #endregion Text


        private Span[] CreateSpans(Inline inline, Templates.SpanAttributes attributes = Templates.SpanAttributes.None)
        {
            switch (inline)
            {
                case LiteralInline literal:
                    return new[]
                    {
                        CreateSpan(new Templates.SpanData
                        {
                            Text = literal.Content.Text.Substring(literal.Content.Start, literal.Content.Length),
                            Attributes = attributes
                        })
                    };

                case EmphasisInline emphasis:
                    var childAttributes = attributes | (emphasis.DelimiterCount == 2 ? Templates.SpanAttributes.Bold : Templates.SpanAttributes.Italic);
                    return emphasis.SelectMany(x => CreateSpans(x, childAttributes)).ToArray();

                case LineBreakInline breakline:
                    return new[] { CreateSpan(new Templates.SpanData { Text = Environment.NewLine }) };

                case LinkInline link when link.IsImage:
                    var image = ImageTemplate.CreateContent() as View;

                    image.BindingContext = new Templates.ImageData
                    {
                        Uri = link.Url,
                        Title = link.Title
                    };

                    queuedViews.Add(image);
                    return new Span[0];

                case LinkInline link:
                    childAttributes = attributes | Templates.SpanAttributes.Link;
                    var spans = link.SelectMany(x => CreateSpans(x, childAttributes)).ToArray();
                    var linkTitle = string.IsNullOrEmpty(link.Title)
                                  ? string.Join("", spans.Select(x => x.Text))
                                  : link.Title;
                    links.Add(new KeyValuePair<string, string>(linkTitle, link.Url));
                    return spans;

                case CodeInline code:
                    return new[]
                    {
                        CreateSpan(new Templates.SpanData
                        {
                            Text = code.Content,
                            Attributes = attributes | Templates.SpanAttributes.Monospace
                        })
                    };

                default:
                    Debug.WriteLine($"Can't render {inline.GetType()} inlines.");
                    return null;
            }
        }


        private Span CreateSpan(Templates.SpanData data)
        {
            var template = SpanTemplate.CreateContent();

            if (template is Span span)
            {
                span.BindingContext = data;
                return span;
            }
            else
            {
                throw new NotSupportedException($"{nameof(SpanTemplate)} must be a {typeof(DataTemplate).FullName} of {typeof(Span).FullName}");
            }
        }

        #endregion
    }
}
