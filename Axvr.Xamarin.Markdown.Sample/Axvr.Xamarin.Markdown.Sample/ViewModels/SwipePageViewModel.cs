using System.Windows.Input;
using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Sample.ViewModels
{
    public class SwipePageViewModel : BaseViewModel
    {
        public SwipePageViewModel()
        { }


        private const string PageKey = "swipe";


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

# Page 1

---

# Page 2

---

# Page 3

---

# Page 4
";


        private string _markdown = _defaultContent;
        public string Markdown
        {
            get => _markdown;
            set => SetProperty(ref _markdown, value);
        }
    }
}
