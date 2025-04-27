using System.Text.Json.Serialization;

namespace StarWars.Explorer.Models
{
    public class SwapiTechResponse<T>
    {
        public string Message { get; set; } = string.Empty;
        public int Total_Records { get; set; }
        public int Total_Pages { get; set; }
        public string? Previous { get; set; }
        public string? Next { get; set; }

        [JsonPropertyName("result")]
        public List<SwapiTechResult<T>>? Result { get; set; }

        [JsonPropertyName("results")]
        public List<SwapiTechResult<T>>? Results { get; set; }
    }

    public class SwapiTechResult<T>
    {
        [JsonPropertyName("uid")]
        public required string Uid { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("properties")]
        public T Properties { get; set; } = default!;
    }

    public class SwapiTechDetailResponse<T>
    {
        public string Message { get; set; } = string.Empty;
        public SwapiTechDetailResult<T> Result { get; set; } = default!;
    }

    public class SwapiTechDetailResult<T>
    {
        public string Description { get; set; } = string.Empty;
        public T? Properties { get; set; }
        public required string Uid { get; set; }
    }

    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public string? Next { get; set; }
        public string? Previous { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}
