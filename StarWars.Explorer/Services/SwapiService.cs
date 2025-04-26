using StarWars.Explorer.Models;
using System.Net.Http.Json;

namespace StarWars.Explorer.Services
{
    public class SwapiService : ISwapiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://www.swapi.tech/api";

        public SwapiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<List<Character>> GetCharactersAsync(string searchTerm = null)
        {
            try
            {

            var characters = new List<Character>();

            string endpoint = "/people";
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                endpoint += $"?search={searchTerm}";
            }

            var response = await _httpClient.GetFromJsonAsync<SwapiTechResponse<Character>>(BaseUrl + endpoint);

            if (response?.Results != null)
            {
                foreach (var result in response.Results)
                {
                    var character = await GetCharacterAsync(result.Uid);
                    if (character != null)
                    {
                        characters.Add(character);
                    }
                }
            }

            return characters;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Character> GetCharacterAsync(string id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<SwapiTechDetailResponse<Character>>(BaseUrl +$"/people/{id}");
                if (response?.Result?.Properties != null)
                {
                    var character = response.Result.Properties;
                    character.Id = id;
                    return character;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Film>> GetFilmsAsync(string searchTerm = null)
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
        }

        public async Task<Film> GetFilmAsync(string id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<SwapiTechDetailResponse<Film>>($"/films/{id}");
                if (response?.Result?.Properties != null)
                {
                    var film = response.Result.Properties;
                    film.Id = id;
                    return film;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Planet>> GetPlanetsAsync(string searchTerm = null)
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
        }

        public async Task<Planet> GetPlanetAsync(string id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<SwapiTechDetailResponse<Planet>>($"/planets/{id}");
                if (response?.Result?.Properties != null)
                {
                    var planet = response.Result.Properties;
                    planet.Id = id;
                    return planet;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
