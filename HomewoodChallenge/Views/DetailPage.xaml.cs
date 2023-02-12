using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomewoodChallenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public ImageSource ImageSource { get; }

        public DetailPage(Image image)
        {
            NavigationPage.SetHasNavigationBar(this, false);

            ImageSource = image.Source;

            InitializeComponent();
            BindingContext = this;
        }

        private void OnBackButtonTapped(object sender, EventArgs e)
        {
            if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1] != this) return;
            Navigation.PopAsync();
        }
    }
}