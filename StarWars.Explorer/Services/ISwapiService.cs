using StarWars.Explorer.Models;

namespace StarWars.Explorer.Services
{
    public interface ISwapiService
    {
        #region Character
        Task<PagedResult<Character>> GetCharactersAsync(string? searchTerm = null, int page = 1);
        Task<Character?> GetCharacterAsync(string id);
        #endregion Character

        #region Film
        Task<List<Film>> GetFilmsAsync(string? searchTerm);
        Task<PagedResult<Film>> GetFilmsAsync(string? searchTerm = null, int page = 1);
        Task<Film?> GetFilmAsync(string id);
        #endregion Film

        #region Planet
        Task<PagedResult<Planet>> GetPlanetsAsync(string? searchTerm = null, int page = 1);
        Task<Planet?> GetPlanetAsync(string id);
        #endregion Planet
    }
}
