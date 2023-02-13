using System.ComponentModel;
using Xamarin.Forms;

namespace HomewoodChallenge.Models
{
    public class FavoritableImage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public ImageSource Source { get; }
        public bool IsFavorited { get; set; } = false;

        public FavoritableImage(ImageSource source) => Source = source;

        public void UpdateIsFavorited()
            => OnPropertyChanged("IsFavorited");
    }
}
