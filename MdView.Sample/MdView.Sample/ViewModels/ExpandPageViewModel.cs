using System.Windows.Input;
using Xamarin.Forms;

namespace MdView.Sample.ViewModels
{
    public class ExpandPageViewModel : BaseViewModel
    {
        public ExpandPageViewModel()
        { }


        private const string PageKey = "expand";


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


        private const string _defaultContent = @"_This page is a WIP._

# Section 1

Foo...

# Section 2

Bar...

# Section 3

Biz...

# Section 4

Baz...
";


        private string _markdown = _defaultContent;
        public string Markdown
        {
            get => _markdown;
            set => SetProperty(ref _markdown, value);
        }
    }
}
