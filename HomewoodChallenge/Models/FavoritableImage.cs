using Xamarin.Forms;

namespace HomewoodChallenge.Models
{
    public class FavoritableImage
    {
        public ImageSource Source { get; }
        public bool Favorited { get; } = false;

        public FavoritableImage(ImageSource source) => Source = source;
    }
}
