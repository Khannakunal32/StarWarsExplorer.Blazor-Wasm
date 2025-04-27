using System.Text.Json.Serialization;
using StarWars.Explorer.Models.Common;

namespace StarWars.Explorer.Models
{
    public class Character : IUidEntity
    {
        public string Uid { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("gender")]
        public string Gender { get; set; } = string.Empty;

        [JsonPropertyName("skin_color")]
        public string SkinColor { get; set; } = string.Empty;

        [JsonPropertyName("hair_color")]
        public string HairColor { get; set; } = string.Empty;

        [JsonPropertyName("height")]
        public string Height { get; set; } = string.Empty;

        [JsonPropertyName("eye_color")]
        public string EyeColor { get; set; } = string.Empty;

        [JsonPropertyName("mass")]
        public string Mass { get; set; } = string.Empty;

        [JsonPropertyName("homeworld")]
        public string Homeworld { get; set; } = string.Empty;

        [JsonPropertyName("birth_year")]
        public string BirthYear { get; set; } = string.Empty;

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }
}