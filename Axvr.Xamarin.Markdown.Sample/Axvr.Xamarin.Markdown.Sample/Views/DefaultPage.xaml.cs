using Axvr.Xamarin.Markdown.Sample.Helpers;
using Axvr.Xamarin.Markdown.Sample.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Sample.Views
{
    [DesignTimeVisible(false)]
    public partial class DefaultPage : ContentPage
    {
        public DefaultPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            ResourcesHelper.LoadTheme(Theme.Default);

            if (BindingContext is DefaultPageViewModel page)
            {
                page.RefreshContent();
            }
        }
    }
}
