using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codere.Models
{
    public class Show
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdKey { get; set; }
         public int Id { get; set; }
         public string? Url { get; set; }
         public string? Name { get; set; }
         public string? Type { get; set; }
         public string? Language { get; set; }
         public string? Genres { get; set; }
         public string? Status { get; set; }
         public int? Runtime { get; set; }
         public int? AverageRuntime { get; set; }
         public DateTime? Premiered { get; set; }
         public DateTime? Ended { get; set; }
         public string? OfficialSite { get; set; }
         public int? Weight { get; set; }
         public string? Summary { get; set; }
         public long? Updated { get; set; }
         public double? Rating_Average { get; set; }
    

        [NotMapped]
        // Relación uno a uno con Schedule
        public Schedule Schedule { get; set; }
        [NotMapped]
        // Relación uno a uno con Network
        public Network Network { get; set; }
        [NotMapped]
        // Relación uno a uno con External (identificadores externos)
        public External External { get; set; }
        [NotMapped]
        // Relación uno a uno con Image (URLs de imágenes)
        public Image Image { get; set; }
        [NotMapped]
        // Relación uno a uno con Link (enlaces relacionados)
        public Link Link { get; set; }
        [NotMapped]
        public DvdCountry DvdCountry { get; set; }
        [NotMapped]
        public PreviousEpisode PreviousEpisode { get; set; }
        [NotMapped]
        public Rating Rating { get; set; }
        [NotMapped]
        public WebChannel WebChannel { get; set; }

    }
}
