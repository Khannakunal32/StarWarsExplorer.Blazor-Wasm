namespace StarWars.Explorer.Models.Configuration
{
    public class SwapiConfig
    {
        public string BaseUrl { get; set; } = "";
        public string FilmsEndpoint { get; set; } = "/films";
        public string PlanetsEndpoint { get; set; } = "/planets";
        public string PeopleEndpoint { get; set; } = "/people";
    }
}