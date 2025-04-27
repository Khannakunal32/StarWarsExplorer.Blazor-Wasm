using System.Text.Json.Serialization;
using StarWars.Explorer.Models.Common;

namespace StarWars.Explorer.Models
{
    public class Planet : IUidEntity
    {
        public string Uid { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("rotation_period")]
        public string RotationPeriod { get; set; } = string.Empty;

        [JsonPropertyName("orbital_period")]
        public string OrbitalPeriod { get; set; } = string.Empty;

        public string Diameter { get; set; } = string.Empty;
        public string Climate { get; set; } = string.Empty;
        public string Gravity { get; set; } = string.Empty;
        public string Terrain { get; set; } = string.Empty;
        public string SurfaceWater { get; set; } = string.Empty;
        public string Population { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}