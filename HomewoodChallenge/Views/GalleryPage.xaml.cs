using System;
using Xamarin.Forms;
using HomewoodChallenge.Models;
using HomewoodChallenge.ViewModels;

namespace HomewoodChallenge.Views
{
    public partial class GalleryPage : ContentPage
    {
        private readonly SettingsViewModel _vm = new SettingsViewModel();

        public GalleryPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
            BindingContext = _vm;
        }

        private void OnImageTapped(object sender, EventArgs e)
        {
            var currentPage = Navigation.NavigationStack[Navigation.NavigationStack.Count - 1];
            if (currentPage.GetType() == typeof(DetailPage)) return;

            var image = (Image)sender;
            _vm.SelectedImage = image.BindingContext as FavoritableImage;

            Navigation.PushAsync(new DetailPage(_vm));
        }
    }
}
