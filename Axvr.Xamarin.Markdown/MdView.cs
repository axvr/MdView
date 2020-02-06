using System.Linq;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Essentials;

namespace Axvr.Xamarin.Markdown
{
    public class MdView : ContentView
    {
        public Action<string> NavigateToLink { get; set; } = (s) => Launcher.TryOpenAsync(s);

        public string Markdown
        {
            get { return (string)GetValue(MarkdownProperty); }
            set { SetValue(MarkdownProperty, value); }
        }

        public static readonly BindableProperty MarkdownProperty = BindableProperty.Create(nameof(Markdown), typeof(string), typeof(MdView), null, propertyChanged: OnMarkdownChanged);

        static void OnMarkdownChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as MdView;
            view.RenderMarkdown();
        }

        private StackLayout stack;

        private List<KeyValuePair<string, string>> links = new List<KeyValuePair<string, string>>();

        private void RenderMarkdown()
        {
            stack = new StackLayout()
            {
                Spacing = 10, // TODO: allow configuration of spacing (convert MdView into a stacklayout, or provide access).
            };

            if (!string.IsNullOrEmpty(Markdown))
            {
                var parsed = Markdig.Markdown.Parse(Markdown);
                var views = RenderBlocks(parsed.AsEnumerable());

                foreach (var view in views)
                {
                    stack.Children.Add(view);
                }
            }

            Content = stack;
        }

        private IEnumerable<View> RenderBlocks(IEnumerable<Block> blocks)
        {
            var views = new List<View>();

            foreach (var block in blocks)
            {
                views.AddRange(Render(block));
            }

            return views;
        }

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

        public DataTemplate Heading1Template
        {
            get { return (DataTemplate)GetValue(Heading1TemplateProperty); }
            set { SetValue(Heading1TemplateProperty, value); }
        }

        public static readonly BindableProperty Heading1TemplateProperty = BindableProperty.Create(nameof(Heading1Template), typeof(DataTemplate), typeof(MdView), new DataTemplate(typeof(Templates.Heading1)), propertyChanged: OnMarkdownChanged);

        public DataTemplate Heading2Template
        {
            get { return (DataTemplate)GetValue(Heading2TemplateProperty); }
            set { SetValue(Heading2TemplateProperty, value); }
        }

        public static readonly BindableProperty Heading2TemplateProperty = BindableProperty.Create(nameof(Heading2Template), typeof(DataTemplate), typeof(MdView), new DataTemplate(typeof(Templates.Heading2)), propertyChanged: OnMarkdownChanged);

        public DataTemplate Heading3Template
        {
            get { return (DataTemplate)GetValue(Heading3TemplateProperty); }
            set { SetValue(Heading3TemplateProperty, value); }
        }

        public static readonly BindableProperty Heading3TemplateProperty = BindableProperty.Create(nameof(Heading3Template), typeof(DataTemplate), typeof(MdView), new DataTemplate(typeof(Templates.Heading3)), propertyChanged: OnMarkdownChanged);

        public DataTemplate Heading4Template
        {
            get { return (DataTemplate)GetValue(Heading4TemplateProperty); }
            set { SetValue(Heading4TemplateProperty, value); }
        }

        public static readonly BindableProperty Heading4TemplateProperty = BindableProperty.Create(nameof(Heading4Template), typeof(DataTemplate), typeof(MdView), new DataTemplate(typeof(Templates.Heading4)), propertyChanged: OnMarkdownChanged);

        public DataTemplate Heading5Template
        {
            get { return (DataTemplate)GetValue(Heading5TemplateProperty); }
            set { SetValue(Heading5TemplateProperty, value); }
        }

        public static readonly BindableProperty Heading5TemplateProperty = BindableProperty.Create(nameof(Heading5Template), typeof(DataTemplate), typeof(MdView), new DataTemplate(typeof(Templates.Heading5)), propertyChanged: OnMarkdownChanged);

        public DataTemplate Heading6Template
        {
            get { return (DataTemplate)GetValue(Heading6TemplateProperty); }
            set { SetValue(Heading6TemplateProperty, value); }
        }

        public static readonly BindableProperty Heading6TemplateProperty = BindableProperty.Create(nameof(Heading6Template), typeof(DataTemplate), typeof(MdView), new DataTemplate(typeof(Templates.Heading6)), propertyChanged: OnMarkdownChanged);


        public DataTemplate SeparatorTemplate
        {
            get { return (DataTemplate)GetValue(SeparatorTemplateProperty); }
            set { SetValue(SeparatorTemplateProperty, value); }
        }

        public static readonly BindableProperty SeparatorTemplateProperty = BindableProperty.Create(nameof(SeparatorTemplate), typeof(DataTemplate), typeof(MdView), new DataTemplate(typeof(Templates.Separator)), propertyChanged: OnMarkdownChanged);

        public DataTemplate ParagraphTemplate
        {
            get { return (DataTemplate)GetValue(ParagraphTemplateProperty); }
            set { SetValue(ParagraphTemplateProperty, value); }
        }

        public static readonly BindableProperty ParagraphTemplateProperty = BindableProperty.Create(nameof(ParagraphTemplate), typeof(DataTemplate), typeof(MdView), new DataTemplate(typeof(Templates.Paragraph)), propertyChanged: OnMarkdownChanged);

        public DataTemplate CodeBlockTemplate
        {
            get { return (DataTemplate)GetValue(CodeBlockTemplateProperty); }
            set { SetValue(CodeBlockTemplateProperty, value); }
        }

        public static readonly BindableProperty CodeBlockTemplateProperty = BindableProperty.Create(nameof(CodeBlockTemplate), typeof(DataTemplate), typeof(MdView), new DataTemplate(typeof(Templates.CodeBlock)), propertyChanged: OnMarkdownChanged);

        public DataTemplate BlockQuoteTemplate
        {
            get { return (DataTemplate)GetValue(BlockQuoteTemplateProperty); }
            set { SetValue(BlockQuoteTemplateProperty, value); }
        }

        public static readonly BindableProperty BlockQuoteTemplateProperty = BindableProperty.Create(nameof(BlockQuoteTemplate), typeof(DataTemplate), typeof(MdView), new DataTemplate(typeof(Templates.BlockQuote)), propertyChanged: OnMarkdownChanged);

        public DataTemplate OrderedListTemplate
        {
            get { return (DataTemplate)GetValue(OrderedListTemplateProperty); }
            set { SetValue(OrderedListTemplateProperty, value); }
        }

        public static readonly BindableProperty OrderedListTemplateProperty = BindableProperty.Create(nameof(OrderedListTemplate), typeof(DataTemplate), typeof(MdView), new DataTemplate(typeof(Templates.OrderedList)), propertyChanged: OnMarkdownChanged);

        public DataTemplate UnorderedListTemplate
        {
            get { return (DataTemplate)GetValue(UnorderedListTemplateProperty); }
            set { SetValue(UnorderedListTemplateProperty, value); }
        }

        public static readonly BindableProperty UnorderedListTemplateProperty = BindableProperty.Create(nameof(UnorderedListTemplate), typeof(DataTemplate), typeof(MdView), new DataTemplate(typeof(Templates.UnorderedList)), propertyChanged: OnMarkdownChanged);

        public DataTemplate ImageTemplate
        {
            get { return (DataTemplate)GetValue(ImageTemplateProperty); }
            set { SetValue(ImageTemplateProperty, value); }
        }

        public static readonly BindableProperty ImageTemplateProperty = BindableProperty.Create(nameof(ImageTemplate), typeof(DataTemplate), typeof(MdView), new DataTemplate(typeof(Templates.Image)), propertyChanged: OnMarkdownChanged);

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

        private View Render(ThematicBreakBlock block)
        {
            return SeparatorTemplate.CreateContent() as View;
        }

        private View Render(ListBlock block)
        {
            var views = new List<View>();

            for (int i = 0; i < block.Count(); i++)
            {
                var item = block.ElementAt(i);

                views.AddRange(Render(item));
            }

            View list;

            if (block.IsOrdered)
            {
                list = OrderedListTemplate.CreateContent() as View;
            }
            else
            {
                list = UnorderedListTemplate.CreateContent() as View;
            }

            list.BindingContext = new Templates.ListAstNode
            {
                Views = views
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

            heading.BindingContext = new Templates.HeadingAstNode
            {
                FormattedText = CreateFormatted(block.Inline)
            };

            AttachLinks(heading);

            return heading;
        }

        private View Render(ParagraphBlock block)
        {
            var paragraph = ParagraphTemplate.CreateContent() as View;

            paragraph.BindingContext = new Templates.ParagraphAstNode
            {
                FormattedText = CreateFormatted(block.Inline)
            };

            AttachLinks(paragraph);

            return paragraph;
        }

        private View Render(QuoteBlock block)
        {
            var blockQuote = BlockQuoteTemplate.CreateContent() as View;

            var inner = new StackLayout();

            foreach (var view in RenderBlocks(block.AsEnumerable()))
            {
                inner.Children.Add(view);
            }

            blockQuote.BindingContext = new Templates.BlockQuoteAstNode
            {
                View = inner
            };

            return blockQuote;
        }

        private View Render(CodeBlock block)
        {
            var codeblock = CodeBlockTemplate.CreateContent() as View;

            codeblock.BindingContext = new Templates.CodeBlockAstNode
            {
                Text = string.Join(Environment.NewLine, block.Lines)
            };

            return codeblock;
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

        private Span[] CreateSpans(Inline inline, FontAttributes attributes = FontAttributes.None, Color? foregroundColor = null)
        {
            switch (inline)
            {
                case LiteralInline literal:
                    var span = new Span
                    {
                        Text = literal.Content.Text.Substring(literal.Content.Start, literal.Content.Length),
                        FontAttributes = attributes
                    };

                    if (foregroundColor.HasValue)
                    {
                        span.ForegroundColor = foregroundColor.Value;
                    }

                    return new[] { span };

                case EmphasisInline emphasis:
                    var childAttributes = attributes | (emphasis.DelimiterCount == 2 ? FontAttributes.Bold : FontAttributes.Italic);
                    return emphasis.SelectMany(x => CreateSpans(x, childAttributes)).ToArray();

                case LineBreakInline breakline:
                    return new[] { new Span { Text = "\n" } };

                case LinkInline link:
                    // TODO: make styling of this more customisable and less hacky.

                    var url = link.Url;

                    if (link.IsImage)
                    {
                        var image = ImageTemplate.CreateContent() as View;
                        image.BindingContext = new Templates.ImageAstNode
                        {
                            Url = url
                        };

                        queuedViews.Add(image);
                        return new Span[0];
                    }
                    else
                    {
                        var spans = link.SelectMany(x => CreateSpans(x, foregroundColor: Color.FromHex("#0366d6"))).ToArray();
                        links.Add(new KeyValuePair<string, string>(string.Join("", spans.Select(x => x.Text)), url));
                        return spans;
                    }

                case CodeInline code:
                    // TODO: make this customisable + less hacky.
                    return new[]
                    {
                        new Span
                        {
                            Text = "\u2002" + code.Content + "\u2002",
                            ForegroundColor = Color.FromHex("#24292e"),
                            BackgroundColor = Color.FromHex("#f6f8fa"),
                            FontFamily = Device.RuntimePlatform == Device.iOS
                                       ? "Courier"
                                       : "monospace"
                        }
                    };

                default:
                    Debug.WriteLine($"Can't render {inline.GetType()} inlines.");
                    return null;
            }
        }

        #endregion
    }
}
