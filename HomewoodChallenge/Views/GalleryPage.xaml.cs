using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace HomewoodChallenge.Views
{
    public class FavoritableImage
    {
        public ImageSource Source { get; }
        public bool Favorited = false;

        public FavoritableImage(ImageSource source) => Source = source;
    }

    public partial class GalleryPage : ContentPage
    {
        private static readonly string _imageFilePath = "HomewoodChallenge.Resources.Images.";

        public ObservableCollection<FavoritableImage> ImageCollection { get; } = new ObservableCollection<FavoritableImage>()
        {
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "albert-cashier.jpg")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "black-gay-man.jpg")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "boy-attacked-by-police-dog.jpg")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "desegregation-protest.jpg")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "emmett-till-casket.png")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "harvey-milk-against-briggs-initiative.jpg")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "i-am-a-man.jpg")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "leslie-feinberg-rally.jpg")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "leslie-feinberg-transexual-menace.jpg")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "little-rock-nine.jpg")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "margaret-hamilton.jpeg")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "mlk-i-have-a-dream.jpeg")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "napalm-girl.jpg")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "olympics-black-power-salute.jpeg")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "voting-rights-protest.jpg")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "white-only-water-fountain.jpg")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "woolsworth-sit-in.png")),
            new FavoritableImage(ImageSource.FromResource(_imageFilePath + "workers-atop-a-skyscraper.jpeg"))

        };
        public int Columns { get; } = 3;
        public int ImageSpacing { get; } = 5;

        private int GetImageSize()
            => (int)(DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density 
                - ImageSpacing * Columns - ImageSpacing) / Columns;

        public int ImageSize => GetImageSize();

        public GalleryPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;

            InitializeComponent();
            BindingContext = this;
        }

        private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
            => OnPropertyChanged("ImageSize");

        private void OnImageTapped(object sender, EventArgs e)
        {
            Image image = (Image)sender;
            Navigation.PushAsync(new DetailPage(image));
        }
    }
}
