using System.Text.Json.Serialization;

namespace StarWars.Explorer.Models
{
    public class SwapiTechResponse<T>
    {
        public string Message { get; set; }
        public int Total_Records { get; set; }
        public int Total_Pages { get; set; }
        public string Previous { get; set; }
        public string Next { get; set; }

        [JsonPropertyName("result")]
        public List<SwapiTechResult<T>> Result { get; set; }

        [JsonPropertyName("results")]
        public List<SwapiTechResult<T>> Results { get; set; }
    }

    public class SwapiTechResult<T>
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("properties")]
        public T Properties { get; set; }
    }

    public class SwapiTechDetailResponse<T>
    {
        public string Message { get; set; }
        public SwapiTechDetailResult<T> Result { get; set; }
    }

    public class SwapiTechDetailResult<T>
    {
        public string Description { get; set; }
        public T Properties { get; set; }
        public string Uid { get; set; }
    }
}
