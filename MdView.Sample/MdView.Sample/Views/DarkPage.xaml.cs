using MdView.Sample.Helpers;
using MdView.Sample.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MdView.Sample.Views
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
