using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HomewoodChallenge.ViewModels;

namespace HomewoodChallenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        private readonly SettingsViewModel _vm;

        public DetailPage(SettingsViewModel vm)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            _vm = vm;

            InitializeComponent();
            BindingContext = _vm;
        }

        private void OnBackButtonTapped(object sender, EventArgs e)
        {
            if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1] != this) return;
            Navigation.PopAsync();
        }

        private void OnFavoriteTapped(object sender, EventArgs e)
        {
            _vm.SelectedImage.IsFavorited = !_vm.SelectedImage.IsFavorited;
            _vm.UpdateFavorite();
        }

        private void OnSelectedImageChanged(object sender, EventArgs e)
            => _vm.UpdateFavorite();
    }
}