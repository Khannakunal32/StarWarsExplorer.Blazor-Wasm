using StarWars.Explorer.Infrastructure;
using StarWars.Explorer.Models;
using StarWars.Explorer.Services.Common;

namespace StarWars.Explorer.Services
{
    public class SwapiService : BaseService, ISwapiService
    {
        private readonly HttpClient _httpClient;
        private readonly SwapiTechServiceHelper _helper;
        private const string BaseUrl = "https://www.swapi.tech/api";

        public SwapiService(HttpClient httpClient, IExceptionInterceptor exceptionInterceptor, SwapiTechServiceHelper helper)
            : base(exceptionInterceptor)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
            _helper = helper;
        }

        #region "Characters"
        public async Task<List<Character>> GetCharactersAsync(string? searchTerm)
        {
            return await ExecuteAsync(async () =>
            {
                string endpoint = "/people";
                endpoint += string.IsNullOrWhiteSpace(searchTerm) ? "?expanded=true" : $"?name={searchTerm}";
                return await _helper.GetListAsync<Character>(endpoint);
            }, "GetCharactersAsync");
        }

        public async Task<PagedResult<Character>> GetCharactersAsync(string? searchTerm = null, int page = 1)
        {
            return await ExecuteAsync(async () =>
            {
                string endpoint = $"/people?page={page}&limit=9&expanded=true";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    endpoint += $"&name={searchTerm}";
                }

                return await _helper.GetPagedListAsync<Character>(endpoint);
            }, "GetCharactersAsync");
        }

        public async Task<Character?> GetCharacterAsync(string id)
        {
            return await ExecuteAsync(async () =>
            {
                return await _helper.GetDetailAsync<Character>($"/people/{id}");
            }, $"GetCharacterAsync(id: {id})");
        }
        #endregion "Characters"

        #region "Films"
        public async Task<List<Film>> GetFilmsAsync(string? searchTerm = null)
        {
            return await ExecuteAsync(async () =>
            {
                string endpoint = "/films";
                endpoint += string.IsNullOrWhiteSpace(searchTerm) ? "?expanded=true" : $"?title={searchTerm}";
                return await _helper.GetListAsync<Film>(endpoint);
            }, "GetFilmsAsync");
        }

        public async Task<PagedResult<Film>> GetFilmsAsync(string? searchTerm = null, int page = 1)
        {
            return await ExecuteAsync(async () =>
            {
                string endpoint = $"/films?page={page}&limit=9&expanded=true";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    endpoint += $"&name={searchTerm}";
                }

                return await _helper.GetPagedListAsync<Film>(endpoint);
            }, "GetFilmsAsync");
        }

        public async Task<Film?> GetFilmAsync(string id)
        {
            return await ExecuteAsync(async () =>
            {
                return await _helper.GetDetailAsync<Film>($"/films/{id}");
            }, $"GetFilmAsync(id: {id})");
        }
        #endregion "Films"

        #region "Planets"
        public async Task<List<Planet>> GetPlanetsAsync(string? searchTerm = null)
        {
            return await ExecuteAsync(async () =>
            {
                string endpoint = "/planets";
                endpoint += string.IsNullOrWhiteSpace(searchTerm) ? "?expanded=true" : $"?name={searchTerm}";
                return await _helper.GetListAsync<Planet>(endpoint);
            }, "GetPlanetsAsync");
        }

        public async Task<PagedResult<Planet>> GetPlanetsAsync(string? searchTerm = null, int page = 1)
        {
            return await ExecuteAsync(async () =>
            {
                string endpoint = $"/planets?page={page}&limit=9&expanded=true";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    endpoint += $"&name={searchTerm}";
                }

                return await _helper.GetPagedListAsync<Planet>(endpoint);
            }, "GetPlanetsAsync");
        }

        public async Task<Planet?> GetPlanetAsync(string id)
        {
            return await ExecuteAsync(async () =>
            {
                return await _helper.GetDetailAsync<Planet>($"/planets/{id}");
            }, $"GetPlanetAsync(id: {id})");
        }
        #endregion "Planets"
    }
}