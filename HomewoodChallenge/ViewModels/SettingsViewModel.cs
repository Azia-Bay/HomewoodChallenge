using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Essentials;
using HomewoodChallenge.Models;
using HomewoodChallenge.Helpers;

namespace HomewoodChallenge.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public ObservableCollection<FavoritableImage> ImageCollection
        {
            get => Settings.ImageCollection;
        }

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
