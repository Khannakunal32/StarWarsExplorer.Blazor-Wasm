namespace StarWars.Explorer.Models
{
    public class SwapiTechResponse<T>
    {
        public string Message { get; set; }
        public T Result { get; set; }
        public List<SwapiTechResult> Results { get; set; }
    }

    public class SwapiTechResult
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
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
