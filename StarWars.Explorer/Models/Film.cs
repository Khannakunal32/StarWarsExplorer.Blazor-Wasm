using System.Text.Json.Serialization;

namespace StarWars.Explorer.Models
{
    public class Film : IUidEntity
    {
        public string Uid { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("episode_id")]
        public int EpisodeId { get; set; }

        [JsonPropertyName("opening_crawl")]
        public string OpeningCrawl { get; set; } = string.Empty;

        public string Director { get; set; } = string.Empty;
        public string Producer { get; set; } = string.Empty;

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; } = string.Empty;

        public List<string> Characters { get; set; } = new();
        public List<string> Planets { get; set; } = new();
        public List<string> Starships { get; set; } = new();
        public List<string> Vehicles { get; set; } = new();
        public List<string> Species { get; set; } = new();
        public string Url { get; set; } = string.Empty;
    }
}