using FantasyApp.Models;
using FantasyApp.Models.GoogleBooks;
using NuGet.Protocol;

namespace FantasyApp.GoogleBooks
{
    public static class VolumeMapper
    {
        public static Volume ApiToVolume (VolumeApiResponse apiVolume)
        {
            Volume volume = new()
            {
                GoogleId = apiVolume.id,
                Title = apiVolume.volumeInfo!.title,
                Published_date = GetYearFromPublicDate(apiVolume.volumeInfo.publishedDate),
                Description = apiVolume.volumeInfo.description,
                Language = apiVolume.volumeInfo.language,
                PrintType = apiVolume.volumeInfo.printType,
                Authors = new List<Author>(),
                Categories = new List<Category>(),
                SmallThumbnail = apiVolume.volumeInfo.imageLinks!.smallThumbnail,
                Thumbnail = apiVolume.volumeInfo.imageLinks.thumbnail
            };

            foreach (var author in apiVolume.volumeInfo.authors)
            {
                volume.Authors.Add(new Author()
                {
                    AuthorName = author
                });
            };

            foreach (var category in apiVolume.volumeInfo.categories)
            {
                volume.Categories.Add(new Category()
                {
                    Name = category
                });
            };

            volume.Publisher = new Publisher
            {
                Name = apiVolume.volumeInfo.publisher
            };

            volume.MainCategory = new MainCategory
            {
                Name = apiVolume.volumeInfo.categories[0]
            };

            return volume;
        }

        private static DateTime GetYearFromPublicDate(string PublishedDate)
        {
            if(DateTime.TryParse(PublishedDate, out DateTime parsedDate))
            {
                return new DateTime(parsedDate.Year);
            }
            else
            {
                int parsedYear;
                if(int.TryParse(PublishedDate, out parsedYear))
                {
                    return new DateTime(parsedYear);
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }
    }
}
