using FantasyApp.Models;

namespace FantasyApp.BookApi
{
    public class GoogleBooksApi : IGoogleBooksApi
    {
        private readonly HttpClient _httpClient;
        

        public GoogleBooksApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Volume>> GetVolumesByName(string search)
        {
           HttpResponseMessage? response = await _httpClient.GetAsync($"/volumes?q={search}+subject:fantasy&key={apiKey}");

            if(response.IsSuccessStatusCode)
            {

            }
        }
    }
}
