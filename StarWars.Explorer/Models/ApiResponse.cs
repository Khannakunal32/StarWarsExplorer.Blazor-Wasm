namespace StarWars.Explorer.Models
{
    public class ApiResponse<T>
    {
        public int Count { get; set; }
        public required string Next { get; set; }
        public required string Previous { get; set; }
        public List<T> Results { get; set; } = new();
    }
}
