using MdView.Sample.Helpers;
using MdView.Sample.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MdView.Sample.Views
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
