using Axvr.Xamarin.Markdown.Sample.Helpers;
using Axvr.Xamarin.Markdown.Sample.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Sample.Views
{
    [DesignTimeVisible(false)]
    public partial class DarkPage : ContentPage
    {
        public DarkPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            ResourcesHelper.LoadTheme(Theme.Dark);

            if (BindingContext is DarkPageViewModel page)
            {
                page.RefreshContent();
            }
        }
    }
}
