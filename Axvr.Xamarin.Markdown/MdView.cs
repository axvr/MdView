using System.Linq;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Essentials;
using System.Text;

namespace Axvr.Xamarin.Markdown
{
    public class MdView : StackLayout
    {
        public MdView() : base()
        {
            Spacing = 10;
        }


        public Action<string> NavigateToLink { get; set; } = (s) => Launcher.TryOpenAsync(s);


        public string Markdown
        {
            get => (string)GetValue(MarkdownProperty);
            set => SetValue(MarkdownProperty, value);
        }

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


        public DataTemplate Heading1Template
        {
            get => (DataTemplate)GetValue(Heading1TemplateProperty);
            set => SetValue(Heading1TemplateProperty, value);
        }

        public static readonly BindableProperty Heading1TemplateProperty =
            CreateTemplateProperty(nameof(Heading1Template), typeof(Templates.Heading1));


        public DataTemplate Heading2Template
        {
            get => (DataTemplate)GetValue(Heading2TemplateProperty);
            set => SetValue(Heading2TemplateProperty, value);
        }

        public static readonly BindableProperty Heading2TemplateProperty =
            CreateTemplateProperty(nameof(Heading2Template), typeof(Templates.Heading2));


        public DataTemplate Heading3Template
        {
            get => (DataTemplate)GetValue(Heading3TemplateProperty);
            set => SetValue(Heading3TemplateProperty, value);
        }

        public static readonly BindableProperty Heading3TemplateProperty =
            CreateTemplateProperty(nameof(Heading3Template), typeof(Templates.Heading3));


        public DataTemplate Heading4Template
        {
            get => (DataTemplate)GetValue(Heading4TemplateProperty);
            set => SetValue(Heading4TemplateProperty, value);
        }

        public static readonly BindableProperty Heading4TemplateProperty =
            CreateTemplateProperty(nameof(Heading4Template), typeof(Templates.Heading4));


        public DataTemplate Heading5Template
        {
            get => (DataTemplate)GetValue(Heading5TemplateProperty);
            set => SetValue(Heading5TemplateProperty, value);
        }

        public static readonly BindableProperty Heading5TemplateProperty =
            CreateTemplateProperty(nameof(Heading5Template), typeof(Templates.Heading5));


        public DataTemplate Heading6Template
        {
            get => (DataTemplate)GetValue(Heading6TemplateProperty);
            set => SetValue(Heading6TemplateProperty, value);
        }

        public static readonly BindableProperty Heading6TemplateProperty =
            CreateTemplateProperty(nameof(Heading6Template), typeof(Templates.Heading6));


        public DataTemplate SeparatorTemplate
        {
            get => (DataTemplate)GetValue(SeparatorTemplateProperty);
            set => SetValue(SeparatorTemplateProperty, value);
        }

        public static readonly BindableProperty SeparatorTemplateProperty =
            CreateTemplateProperty(nameof(SeparatorTemplate), typeof(Templates.Separator));


        public DataTemplate ParagraphTemplate
        {
            get => (DataTemplate)GetValue(ParagraphTemplateProperty);
            set => SetValue(ParagraphTemplateProperty, value);
        }

        public static readonly BindableProperty ParagraphTemplateProperty =
            CreateTemplateProperty(nameof(ParagraphTemplate), typeof(Templates.Paragraph));


        public DataTemplate CodeBlockTemplate
        {
            get => (DataTemplate)GetValue(CodeBlockTemplateProperty);
            set => SetValue(CodeBlockTemplateProperty, value);
        }

        public static readonly BindableProperty CodeBlockTemplateProperty =
            CreateTemplateProperty(nameof(CodeBlockTemplate), typeof(Templates.CodeBlock));


        public DataTemplate BlockQuoteTemplate
        {
            get => (DataTemplate)GetValue(BlockQuoteTemplateProperty);
            set => SetValue(BlockQuoteTemplateProperty, value);
        }

        public static readonly BindableProperty BlockQuoteTemplateProperty =
            CreateTemplateProperty(nameof(BlockQuoteTemplate), typeof(Templates.BlockQuote));


        public DataTemplate OrderedListTemplate
        {
            get => (DataTemplate)GetValue(OrderedListTemplateProperty);
            set => SetValue(OrderedListTemplateProperty, value);
        }

        public static readonly BindableProperty OrderedListTemplateProperty =
            CreateTemplateProperty(nameof(OrderedListTemplate), typeof(Templates.OrderedList));


        public DataTemplate UnorderedListTemplate
        {
            get => (DataTemplate)GetValue(UnorderedListTemplateProperty);
            set => SetValue(UnorderedListTemplateProperty, value);
        }

        public static readonly BindableProperty UnorderedListTemplateProperty =
            CreateTemplateProperty(nameof(UnorderedListTemplate), typeof(Templates.UnorderedList));


        public DataTemplate ImageTemplate
        {
            get => (DataTemplate)GetValue(ImageTemplateProperty);
            set => SetValue(ImageTemplateProperty, value);
        }

        public static readonly BindableProperty ImageTemplateProperty =
            CreateTemplateProperty(nameof(ImageTemplate), typeof(Templates.Image));


        public DataTemplate SpanTemplate
        {
            get => (DataTemplate)GetValue(SpanTemplateProperty);
            set => SetValue(SpanTemplateProperty, value);
        }

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
                FormattedText = text.Formatted
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
