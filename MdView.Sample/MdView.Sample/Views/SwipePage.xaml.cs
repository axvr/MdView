using MdView.Sample.Helpers;
using MdView.Sample.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MdView.Sample.Views
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
