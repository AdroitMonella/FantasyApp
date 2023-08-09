using FantasyApp.Models;

namespace FantasyApp.BookApi
{
    public class GoogleBooksApi : IGoogleBooksApi
    {
        private readonly HttpClient _httpClient;
        private readonly string apiKey = "AIzaSyBUy9rfBft2H7yey8YQo1WsLohg1-o4b5c";
        public Task<List<Volume>> GetVolumesByName(string search)
        {
            throw new NotImplementedException();
        }
    }
}
