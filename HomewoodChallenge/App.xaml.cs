using Xamarin.Forms;
using HomewoodChallenge.Views;

[assembly: ExportFont("Lato-Bold.ttf", Alias = "Lato")]
namespace HomewoodChallenge
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new GalleryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
