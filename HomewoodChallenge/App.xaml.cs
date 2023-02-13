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

            Helpers.Settings.InitializeSettings();

            MainPage = new NavigationPage(new GalleryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
            => Helpers.Settings.SaveSettings();

        protected override void OnResume()
        {
        }
    }
}
