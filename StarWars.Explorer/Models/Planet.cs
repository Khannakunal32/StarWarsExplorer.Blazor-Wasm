using System.Text.Json.Serialization;

namespace StarWars.Explorer.Models
{
    public class Planet : IUidEntity
    {
        public string Uid { get; set; } = string.Empty;
        public string? Name { get; set; }

        [JsonPropertyName("rotation_period")]
        public string? RotationPeriod { get; set; }

        [JsonPropertyName("orbital_period")]
        public string? OrbitalPeriod { get; set; }

        public string? Diameter { get; set; }
        public string? Climate { get; set; }
        public string? Gravity { get; set; }
        public string? Terrain { get; set; }
        public string? SurfaceWater { get; set; }
        public string? Population { get; set; }
        public string? Url { get; set; }
    }
}