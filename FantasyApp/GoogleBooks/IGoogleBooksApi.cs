using FantasyApp.Models;

namespace FantasyApp.BookApi
{
    public interface IGoogleBooksApi
    {
        Task<List<Volume>> GetVolumesByName(string search);
    }
}
