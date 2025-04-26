namespace StarWars.Explorer.Models
{
    public class Planet
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RotationPeriod { get; set; }
        public string OrbitalPeriod { get; set; }
        public string Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public string SurfaceWater { get; set; }
        public string Population { get; set; }
        public List<string> Residents { get; set; } = new();
        public List<string> Films { get; set; } = new();
        public string Url { get; set; }
    }
}
