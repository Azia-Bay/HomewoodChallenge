using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Essentials;
using HomewoodChallenge.Models;

namespace HomewoodChallenge.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

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

        public FavoritableImage SelectedImage { get; set; }

        private string GetSelectedImageFavoriteUnicode()
            => SelectedImage.IsFavorited ? "\u2765" : "\u2661";

        public string SelectedImageFavoriteUnicode => GetSelectedImageFavoriteUnicode();

        private int GetSelectedImageFavoriteRotation()
            => SelectedImage.IsFavorited ? 90 : 0;

        public int SelectedImageFavoriteRotation => GetSelectedImageFavoriteRotation();

        private Thickness GetTopMargin()
            => DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Portrait
                ? new Thickness(0, 50, 0, 0) : new Thickness(0, 20, 0, 0);

        public Thickness TopMargin => GetTopMargin();

        public int Columns { get; } = 3;
        public int ImageSpacing { get; } = 5;
        public int DoubleImageSpacing { get; } = 10;
        public Thickness ImageCarouselViewMargin { get; } = new Thickness(0, 5, 0, 5);

        private int GetImageSize()
            => (int)(DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density
                - ImageSpacing * Columns - ImageSpacing) / Columns;

        public int ImageSize => GetImageSize();

        public SettingsViewModel()
            => DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;

        private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            OnPropertyChanged("TopMargin");
            OnPropertyChanged("ImageSize");
        }

        public void UpdateFavorite()
        {
            OnPropertyChanged("SelectedImageFavoriteUnicode");
            OnPropertyChanged("SelectedImageFavoriteRotation");
            SelectedImage.UpdateIsFavorited();
        }
    }
}
