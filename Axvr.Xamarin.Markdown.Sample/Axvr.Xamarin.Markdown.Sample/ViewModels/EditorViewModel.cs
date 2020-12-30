using Axvr.Xamarin.Markdown.Sample.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Sample.ViewModels
{
    [QueryProperty(nameof(PageKey), "key")]
    public class EditorViewModel : BaseViewModel
    {
        public EditorViewModel()
        {
            Title = "Markdown Editor";
        }


        public ICommand ResetCommand => new Command(Reset);
        public void Reset()
        {
            Markdown = _content.Default;
        }


        private MarkdownContent _content;


        private string _pageKey;
        public string PageKey
        {
            get => _pageKey;
            set
            {
                _pageKey = Uri.UnescapeDataString(value);

                if (ContentDictionary.TryGetValue(_pageKey, out var content))
                {
                    _content = content;
                    Markdown = _content.Current;
                }
            }
        }


        private string _markdown;
        public string Markdown
        {
            get => _markdown;
            set
            {
                SetProperty(ref _markdown, value);
                _content.Current = value;
            }
        }
    }
}
