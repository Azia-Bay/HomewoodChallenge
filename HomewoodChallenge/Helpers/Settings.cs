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
            new FavoritableImage(_imageFilePath + "bear.png"),
            new FavoritableImage(_imageFilePath + "bears.jpg"),
            new FavoritableImage(_imageFilePath + "capybaras.png"),
            new FavoritableImage(_imageFilePath + "fox.jpg"),
            new FavoritableImage(_imageFilePath + "lion.jpg"),
            new FavoritableImage(_imageFilePath + "lion.png"),
            new FavoritableImage(_imageFilePath + "panda.jfif"),
            new FavoritableImage(_imageFilePath + "panda.jpg"),
            new FavoritableImage(_imageFilePath + "panther.png"),
            new FavoritableImage(_imageFilePath + "penguins.jpg"),
            new FavoritableImage(_imageFilePath + "polar-bears.jfif"),
            new FavoritableImage(_imageFilePath + "polar-bears.jpg"),
            new FavoritableImage(_imageFilePath + "raccoon.jpg"),
            new FavoritableImage(_imageFilePath + "red-panda.jpg"),
            new FavoritableImage(_imageFilePath + "seal.jpg"),
            new FavoritableImage(_imageFilePath + "tiger.png"),
            new FavoritableImage(_imageFilePath + "tigers.jpg"),
            new FavoritableImage(_imageFilePath + "wolves.jpg")
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
