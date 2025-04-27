namespace StarWars.Explorer.Models.Configuration
{
    public class SwapiConfig
    {
        public string BaseUrl { get; set; }
        public Dictionary<string, string> Endpoints { get; set; }
    }
}