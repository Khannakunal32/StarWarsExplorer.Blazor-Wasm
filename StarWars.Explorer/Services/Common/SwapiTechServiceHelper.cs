using System.Net.Http.Json;

using StarWars.Explorer.Models;
using StarWars.Explorer.Models.Common;
using StarWars.Explorer.Models.Configuration;

namespace StarWars.Explorer.Services.Common
{
    public class SwapiTechServiceHelper
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://www.swapi.tech/api";

        public SwapiTechServiceHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private List<SwapiTechResult<T>> GetResults<T>(SwapiTechResponse<T>? response)
        {
            return response?.Results ?? response?.Result ?? new List<SwapiTechResult<T>>();
        }

        public async Task<List<T>> GetListAsync<T>(string endpoint) where T : IUidEntity, new()
        {
            var response = await _httpClient.GetFromJsonAsync<SwapiTechResponse<T>>(BaseUrl + endpoint);
            var list = new List<T>();

            foreach (var result in GetResults(response))
            {
                var item = result.Properties;
                item.Uid = result.Uid;
                list.Add(item);
            }
            return list;
        }

        public async Task<T?> GetDetailAsync<T>(string endpoint) where T : class, IUidEntity, new()
        {
            var response = await _httpClient.GetFromJsonAsync<SwapiTechDetailResponse<T>>(BaseUrl + endpoint);
            var item = response?.Result?.Properties;
            if (item != null)
            {
                item.Uid = response!.Result.Uid;
            }
            return item;
        }

        public async Task<PagedResult<T>> GetPagedListAsync<T>(string endpoint) where T : IUidEntity, new()
        {
            var response = await _httpClient.GetFromJsonAsync<SwapiTechResponse<T>>(BaseUrl + endpoint);
            var pagedResult = new PagedResult<T>();

            if (response != null)
            {
                foreach (var result in GetResults(response))
                {
                    var item = result.Properties;
                    item.Uid = result.Uid;
                    pagedResult.Items.Add(item);
                }

                pagedResult.TotalPages = response.Total_Pages;
                pagedResult.TotalRecords = response.Total_Records;
                pagedResult.Next = response.Next;
                pagedResult.Previous = response.Previous;
            }

            return pagedResult;
        }
    }
}