namespace FantasyApp.Models
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;

        public virtual Volume? Volume { get; set; }
    }
}
