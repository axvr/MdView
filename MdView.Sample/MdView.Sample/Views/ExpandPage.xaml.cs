using MdView.Sample.Helpers;
using MdView.Sample.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MdView.Sample.Views
{
    [DesignTimeVisible(false)]
    public partial class ExpandPage : ContentPage
    {
        public ExpandPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            ResourcesHelper.LoadTheme(Theme.Light);

            if (BindingContext is ExpandPageViewModel page)
            {
                page.RefreshContent();
            }
        }
    }
}
