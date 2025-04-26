namespace StarWars.Explorer.Models
{
    public class Film
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ReleaseDate { get; set; }
        public List<string> Characters { get; set; } = new();
        public List<string> Planets { get; set; } = new();
        public List<string> Starships { get; set; } = new();
        public List<string> Vehicles { get; set; } = new();
        public List<string> Species { get; set; } = new();
        public string Url { get; set; }
    }
}
