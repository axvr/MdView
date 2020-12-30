using Axvr.Xamarin.Markdown.Sample.Helpers;
using Axvr.Xamarin.Markdown.Sample.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Axvr.Xamarin.Markdown.Sample.Views
{
    [DesignTimeVisible(false)]
    public partial class SwipePage : ContentPage
    {
        public SwipePage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            ResourcesHelper.LoadTheme(Theme.Light);

            if (BindingContext is SwipePageViewModel page)
            {
                page.RefreshContent();
            }
        }
    }
}
