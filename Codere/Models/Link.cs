using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codere.Models
{
    public class Link
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_key { get; set; }
        public int Id { get; set; }
        public int? Show_Id { get; set; }
        public string? Self_Href { get; set; }
        public string? Previousepisode_Href { get; set; }
        public string? Previousepisode_Name { get; set; }

        [NotMapped]
        public Show Show { get; set; }
    }
}
