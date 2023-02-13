using System.ComponentModel;
using Xamarin.Forms;

namespace HomewoodChallenge.Models
{
    public class FavoritableImage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public string Uri { get; }
        public ImageSource Source { get; }
        public bool IsFavorited { get; set; } = false;

        public FavoritableImage(string uri)
        {
            Uri = uri;
            Source = ImageSource.FromResource(Uri);
        }

        public void UpdateIsFavorited()
            => OnPropertyChanged("IsFavorited");
    }
}
