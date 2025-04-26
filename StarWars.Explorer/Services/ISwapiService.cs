using StarWars.Explorer.Models;

namespace StarWars.Explorer.Services
{
    public interface ISwapiService
    {
        Task<List<Character>> GetCharactersAsync(string? searchTerm);
        Task<Character> GetCharacterAsync(string id);
        Task<List<Film>> GetFilmsAsync(string? searchTerm);
        Task<Film> GetFilmAsync(string id);
        Task<List<Planet>> GetPlanetsAsync(string? searchTerm);
        Task<Planet> GetPlanetAsync(string id);
    }
}
