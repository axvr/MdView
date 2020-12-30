using System.Windows.Input;
using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Sample.ViewModels
{
    public class DefaultPageViewModel : BaseViewModel
    {
        public DefaultPageViewModel()
        { }


        private const string PageKey = "default";


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


        private const string _defaultContent = @"# MdView

![](mdview_logo_small_3?mdview_margin=0,-60,0,-30&mdview_height_request=200 ""MdView logo"")

[MdView](https://github.com/NumerousTechnology/MdView ""MdView GitHub repository"") is a highly customisable framework for rendering Markdown as native _Xamarin.Forms_ components.

MdView's default controls are designed to be easily replaced with your own custom ones, to better match the design of your app and add additional functionality.

By switching between the tabs below, you'll see various preconfigured examples which demonstrate just how customisable MdView really is.";


        private string _markdown = _defaultContent;

        public string Markdown
        {
            get => _markdown;
            set => SetProperty(ref _markdown, value);
        }
    }
}
