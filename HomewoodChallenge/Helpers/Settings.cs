using System.Collections.ObjectModel;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using HomewoodChallenge.Models;

namespace HomewoodChallenge.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static void InitializeSettings()
        {
            if (SerializedImageCollection == null)
                SerializedImageCollection = SerializeFavoritableImageCollection(_defaultImageCollection);
            ImageCollection = DeserializeFavoritableImageCollection(SerializedImageCollection);
        }

        public static void SaveSettings()
            => SerializedImageCollection = SerializeFavoritableImageCollection(ImageCollection);

        private static readonly string _imageFilePath = "HomewoodChallenge.Resources.Images.";

        private static readonly ObservableCollection<FavoritableImage> _defaultImageCollection 
            = new ObservableCollection<FavoritableImage>()
        {
            new FavoritableImage(_imageFilePath + "albert-cashier.jpg"),
            new FavoritableImage(_imageFilePath + "black-gay-man.jpg"),
            new FavoritableImage(_imageFilePath + "boy-attacked-by-police-dog.jpg"),
            new FavoritableImage(_imageFilePath + "desegregation-protest.jpg"),
            new FavoritableImage(_imageFilePath + "emmett-till-casket.png"),
            new FavoritableImage(_imageFilePath + "harvey-milk-against-briggs-initiative.jpg"),
            new FavoritableImage(_imageFilePath + "i-am-a-man.jpg"),
            new FavoritableImage(_imageFilePath + "leslie-feinberg-rally.jpg"),
            new FavoritableImage(_imageFilePath + "leslie-feinberg-transexual-menace.jpg"),
            new FavoritableImage(_imageFilePath + "little-rock-nine.jpg"),
            new FavoritableImage(_imageFilePath + "margaret-hamilton.jpeg"),
            new FavoritableImage(_imageFilePath + "mlk-i-have-a-dream.jpeg"),
            new FavoritableImage(_imageFilePath + "napalm-girl.jpg"),
            new FavoritableImage(_imageFilePath + "olympics-black-power-salute.jpeg"),
            new FavoritableImage(_imageFilePath + "voting-rights-protest.jpg"),
            new FavoritableImage(_imageFilePath + "white-only-water-fountain.jpg"),
            new FavoritableImage(_imageFilePath + "woolsworth-sit-in.png"),
            new FavoritableImage(_imageFilePath + "workers-atop-a-skyscraper.jpeg")
        };

        public static ObservableCollection<FavoritableImage> ImageCollection { get; set; }

        public static string SerializedImageCollection
        {
            get => AppSettings.GetValueOrDefault("SerializedImageCollectionKey", null);
            set => AppSettings.AddOrUpdateValue("SerializedImageCollectionKey", value);
        }

        private static string SerializeFavoritableImageCollection(ObservableCollection<FavoritableImage> collection)
        {
            string serialization = string.Empty;
            foreach (FavoritableImage image in collection)
                serialization += image.Uri + ' ' + (image.IsFavorited ? "True" : "False") + '\n';
            return serialization;
        }

        private static ObservableCollection<FavoritableImage> DeserializeFavoritableImageCollection(string serialization)
        {
            ObservableCollection<FavoritableImage> collection = new ObservableCollection<FavoritableImage>();
            if (string.IsNullOrWhiteSpace(serialization)) return collection;
            serialization = serialization.TrimEnd();
            serialization += '\n';

            string property = string.Empty;
            int propertiesRead = 0;
            string holdUri = null;
            foreach (char c in serialization)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (propertiesRead % 2 == 0) holdUri = property;
                    else
                    {
                        FavoritableImage image = new FavoritableImage(holdUri);
                        image.IsFavorited = (property == "True");
                        collection.Add(image);
                    }
                    propertiesRead++;
                    property = string.Empty;
                }
                else property += c;
            }

            return collection;
        }
    }
}
