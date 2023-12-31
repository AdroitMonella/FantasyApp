﻿namespace FantasyApp.Models.GoogleBooks
{
    public class VolumesApiResponse
    {
        public IEnumerable<VolumeApiResponse>? items { get; set; }
    }
    public class VolumeApiResponse
    {
        public string id { get; set; }
        public VolumeInfo? volumeInfo { get; set; }
    }

    public class VolumeInfo
    {
        public string title { get; set; } =string.Empty;
        public List<string> authors { get; set; }
        public string publisher { get; set; } = string.Empty;
        public string publishedDate { get; set; }
        public string description { get; set; } = string.Empty;

        public string printType { get; set; } = string.Empty;
        public List<string> categories { get; set; }
        public string language { get; set; } = string.Empty;
        public ImageLinks? imageLinks { get; set; }
    }

    public class ImageLinks
    {
        public string smallThumbnail { get; set; }
        public string thumbnail { get; set; }
    }
}
