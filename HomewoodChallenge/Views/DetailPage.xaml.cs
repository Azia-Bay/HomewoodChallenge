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
    }
}