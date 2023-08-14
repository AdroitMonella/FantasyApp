using FantasyApp.GoogleBooks;
using FantasyApp.Models;
using FantasyApp.Models.GoogleBooks;

namespace FantasyApp.BookApi
{
    public class GoogleBooksApi : IGoogleBooksApi
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string? _apiKey;

        public GoogleBooksApi(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiKey = configuration["GoogleBooks:ServiceApiKey"];
        }

        public async Task<List<Volume>> GetVolumesByName(string search)
        {
            HttpResponseMessage? response = await _httpClient.GetAsync($"/books/v1/volumes?q={search}+subject:fantasy&key={_apiKey}");

            if (response.IsSuccessStatusCode)
            {
                VolumesApiResponse? result = await response.Content.ReadFromJsonAsync<VolumesApiResponse>();
                List<Volume> volumes = new();

                if(result?.items != null)
                {
                    foreach (VolumeApiResponse volume in result?.items!)
                    {
                        volumes.Add(VolumeMapper.ApiToVolume(volume));
                    }
                }
                return volumes;
            }
            else
            {
                throw new HttpRequestException($"Failes to retrieve searchinformation. Status Code: {response.StatusCode}");
            };

        }
    }
}
