using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HomewoodChallenge.ViewModels;

namespace HomewoodChallenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(SettingsViewModel vm)
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
            BindingContext = vm;
        }

        private void OnBackButtonTapped(object sender, EventArgs e)
        {
            if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1] != this) return;
            Navigation.PopAsync();
        }
    }
}