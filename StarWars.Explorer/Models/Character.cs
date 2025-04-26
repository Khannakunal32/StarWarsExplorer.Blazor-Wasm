namespace StarWars.Explorer.Models
{
    public class Character
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Height { get; set; }
        public required string Mass { get; set; }
        public required string HairColor { get; set; }
        public required string SkinColor { get; set; }
        public required string EyeColor { get; set; }
        public required string BirthYear { get; set; }
        public required string Gender { get; set; }
        public required string Homeworld { get; set; }
        public List<string> Films { get; set; } = new();
        public List<string> Species { get; set; } = new();
        public List<string> Vehicles { get; set; } = new();
        public List<string> Starships { get; set; } = new();
        public required string Url { get; set; }
    }
}
