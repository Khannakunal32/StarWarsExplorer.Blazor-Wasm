using StarWars.Explorer.Infrastructure;
using StarWars.Explorer.Models;
using System.Dynamic;
using System.Net.Http.Json;
using System.Text.Json;

namespace StarWars.Explorer.Services
{
    public class SwapiService : BaseService, ISwapiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://www.swapi.tech/api";

        public SwapiService(HttpClient httpClient, IExceptionInterceptor exceptionInterceptor)
            : base(exceptionInterceptor)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<List<Character>> GetCharactersAsync(string? searchTerm)
        {
            return await ExecuteAsync(async () =>
            {
                var characters = new List<Character>();

                string endpoint = "/people";
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    endpoint += $"?name={searchTerm}";
                }
                else
                {
                    endpoint += "?expanded=true";
                }

                var response = await _httpClient.GetFromJsonAsync<SwapiTechResponse<Character>>(BaseUrl + endpoint);

                var results = response?.Results ?? response?.Result;

                if (results != null)
                {
                    foreach (var result in results)
                    {
                        var character = result.Properties;
                        character.Uid = result.Uid;
                        characters.Add(character);
                    }
                }

                return characters;
            }, "GetCharactersAsync");
        }

        public async Task<Character?> GetCharacterAsync(string id)
        {
            return await ExecuteAsync(async () =>
            {
                var response = await _httpClient.GetFromJsonAsync<SwapiTechDetailResponse<Character>>(BaseUrl + $"/people/{id}");
                if (response?.Result?.Properties != null)
                {
                    var character = response.Result.Properties;
                    character.Uid = id;
                    return character;
                }
                return null;
            }, $"GetCharacterAsync(id: {id})");
        }

        public async Task<List<Film>> GetFilmsAsync(string searchTerm = null)
        {
            return await ExecuteAsync(async () =>
            {
                var films = new List<Film>();

                string endpoint = "/films";
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    endpoint += $"?search={searchTerm}";
                }

                var response = await _httpClient.GetFromJsonAsync<SwapiTechResponse<Film>>(endpoint);

                if (response?.Results != null)
                {
                    foreach (var result in response.Results)
                    {
                        var film = await GetFilmAsync(result.Uid);
                        if (film != null)
                        {
                            films.Add(film);
                        }
                    }
                }

                return films;
            }, "GetFilmsAsync");
        }

        public async Task<Film?> GetFilmAsync(string id)
        {
            return await ExecuteAsync(async () =>
            {
                var response = await _httpClient.GetFromJsonAsync<SwapiTechDetailResponse<Film>>($"/films/{id}");
                if (response?.Result?.Properties != null)
                {
                    var film = response.Result.Properties;
                    film.Id = id;
                    return film;
                }
                return null;
            }, $"GetFilmAsync(id: {id})");
        }

        public async Task<List<Planet>> GetPlanetsAsync(string searchTerm = null)
        {
            return await ExecuteAsync(async () =>
            {
                var planets = new List<Planet>();

                string endpoint = "/planets";
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    endpoint += $"?search={searchTerm}";
                }

                var response = await _httpClient.GetFromJsonAsync<SwapiTechResponse<Planet>>(endpoint);

                if (response?.Results != null)
                {
                    foreach (var result in response.Results)
                    {
                        var planet = await GetPlanetAsync(result.Uid);
                        if (planet != null)
                        {
                            planets.Add(planet);
                        }
                    }
                }

                return planets;
            }, "GetPlanetsAsync");
        }

        public async Task<Planet?> GetPlanetAsync(string id)
        {
            return await ExecuteAsync(async () =>
            {
                var response = await _httpClient.GetFromJsonAsync<SwapiTechDetailResponse<Planet>>($"/planets/{id}");
                if (response?.Result?.Properties != null)
                {
                    var planet = response.Result.Properties;
                    planet.Id = id;
                    return planet;
                }
                return null;
            }, $"GetPlanetAsync(id: {id})");
        }
    }
}