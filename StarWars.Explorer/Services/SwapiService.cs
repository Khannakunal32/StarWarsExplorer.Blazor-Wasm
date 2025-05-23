﻿using System.Runtime;
using StarWars.Explorer.Infrastructure;
using StarWars.Explorer.Models;
using StarWars.Explorer.Models.Configuration;
using StarWars.Explorer.Services.Common;

namespace StarWars.Explorer.Services
{
    public class SwapiService : BaseService, ISwapiService
    {
        private readonly SwapiTechServiceHelper _helper;
        private readonly SwapiConfig _config;

        public SwapiService(IExceptionInterceptor exceptionInterceptor, SwapiTechServiceHelper helper, SwapiConfig config)
            : base(exceptionInterceptor)
        {
            _helper = helper;
            _config = config;
        }

        #region "Characters"
        public async Task<PagedResult<Character>> GetCharactersAsync(string? searchTerm = null, int page = 1)
        {
            return await ExecuteAsync(async () =>
            {
                string endpoint = $"{_config.PeopleEndpoint}?page={page}&limit=9&expanded=true";

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
                return await _helper.GetDetailAsync<Character>($"{_config.PeopleEndpoint}/{id}");
            }, $"GetCharacterAsync(id: {id})");
        }
        #endregion "Characters"

        #region "Films"
        public async Task<List<Film>> GetFilmsAsync(string? searchTerm = null)
        {
            return await ExecuteAsync(async () =>
            {
                string endpoint = _config.FilmsEndpoint;
                endpoint += string.IsNullOrWhiteSpace(searchTerm) ? "?expanded=true" : $"?title={searchTerm}";
                return await _helper.GetListAsync<Film>(endpoint);
            }, "GetFilmsAsync");
        }

        public async Task<PagedResult<Film>> GetFilmsAsync(string? searchTerm = null, int page = 1)
        {
            return await ExecuteAsync(async () =>
            {
                string endpoint = $"{_config.FilmsEndpoint}?page={page}&limit=9&expanded=true";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    endpoint += $"&title={searchTerm}";
                }

                return await _helper.GetPagedListAsync<Film>(endpoint);
            }, "GetFilmsAsync");
        }

        public async Task<Film?> GetFilmAsync(string id)
        {
            return await ExecuteAsync(async () =>
            {
                return await _helper.GetDetailAsync<Film>($"{_config.FilmsEndpoint}/{id}");
            }, $"GetFilmAsync(id: {id})");
        }
        #endregion "Films"

        #region "Planets"
        public async Task<PagedResult<Planet>> GetPlanetsAsync(string? searchTerm = null, int page = 1)
        {
            return await ExecuteAsync(async () =>
            {
                string endpoint = $"{_config.PlanetsEndpoint}?page={page}&limit=9&expanded=true";

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
                return await _helper.GetDetailAsync<Planet>($"{_config.PlanetsEndpoint}/{id}");
            }, $"GetPlanetAsync(id: {id})");
        }
        #endregion "Planets"
    }
}