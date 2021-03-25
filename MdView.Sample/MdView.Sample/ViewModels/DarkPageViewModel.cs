using System.Windows.Input;
using Xamarin.Forms;

namespace MdView.Sample.ViewModels
{
    public class DarkPageViewModel : BaseViewModel
    {
        public DarkPageViewModel()
        { }


        private const string PageKey = "dark";


        public ICommand OpenEditorCommand => new Command(OpenEditor);
        private async void OpenEditor()
        {
            ContentDictionary[PageKey] = new Models.MarkdownContent
            {
                Default = _defaultContent,
                Current = _markdown
            };

            await Shell.Current.GoToAsync($"editor?key={PageKey}");
        }


        public void RefreshContent()
        {
            if (ContentDictionary.TryGetValue(PageKey, out var content))
            {
                Markdown = content.Current;
            }
        }


        private const string _defaultContent = @"# Markdown examples

The following section just contains some sample Markdown text which demonstrates some of the Markdown features are supported by MdView.  You can modify or view the Markdown source of this page by clicking the ""__Edit__"" button above.

The Markdown variant used by MdView is [CommonMark](https://commonmark.org/ ""CommonMark specification"").

---

## Inline text

As expected **bold**, _italic_ and **_bold italic_** text will all work, as well as `inline code`.

Inline links work too, although due to limitations in [Xamarin](https://dotnet.microsoft.com/apps/xamarin) clicking anywhere in the paragraph containing the link will open it.

If a paragraph contains 2 or more links, MdView will open an ""[Action Sheet](https://developer.apple.com/design/human-interface-guidelines/ios/views/action-sheets/ ""Action Sheets [Apple Human Interface Guidelines]"")"" listing the link options.  The text displayed in the Action Sheet will be the [_link title_](https://daringfireball.net/projects/markdown/syntax#link).  If no link title was provided, MdView will use the _link text_.


## Ordered and unordered lists

* This is an _**un**ordered_ list.
  + List items can be nested.
    - There is no nesting limit.
* _Ordered_ lists are also supported.
  1. First item.
  2. Second item.
  3. Ordered lists behave identically to ordered lists.


## Headings

MdView supports the first 6 Markdown heading levels.  You'll see them used throughout this page.


## Images

Images can either be stored locally in the app or fetched remotely.

![](https://picsum.photos/id/1050/600/300 ""Remote image"")

![](mdview_logo_small_3?mdview_margin=0,-60,0,-32&mdview_height_request=200 ""Local image"")


## Block quotes

> **Most creativity is a transition from one context into another where things are more surprising.**  There’s an element of surprise, and especially in science, there is often laughter that goes along with the “Aha.”  Art also has this element.  **Our job is to remind us that there are more contexts than the one that we’re in — the one that we think is reality.**
>
> — [Alan Kay](https://queue.acm.org/detail.cfm?id=1039523) (2004)


## Code blocks

```
public static void Main()
{
    Console.WriteLine(""Hello, world!"");
}
```


## Separators

* * *

";


        private string _markdown = _defaultContent;
        public string Markdown
        {
            get => _markdown;
            set => SetProperty(ref _markdown, value);
        }
    }
}
