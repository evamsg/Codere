namespace Codere.Models
{
    public class ShowMapeo
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Language { get; set; }
        public List<string> Genres { get; set; }
        public string? Status { get; set; }
        public int? Runtime { get; set; }
        public int? AverageRuntime { get; set; }
        public DateTime? Premiered { get; set; }
        public DateTime? Ended { get; set; }
        public string? OfficialSite { get; set; }
        public Schedule? Schedule { get; set; }

        public Image? Image { get; set; }
        public Link? Link { get; set; }
        public Rating? Rating { get; set; }
        public PreviousEpisode? PreviousEpisode { get; set; }
        public int? Weight { get; set; }
        public string? Summary { get; set; }
        public Double? Updated { get; set; }
        public double? Rating_Average { get; set; }
        public Network? Network { get; set; }
        public WebChannel? WebChannel { get; set; }
        public DvdCountry? DvdCountry { get; set; }
        public External? Externals { get; set; }
    }
}
