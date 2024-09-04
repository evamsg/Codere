using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codere.Models
{
    public class Network
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_key { get; set; }
        public int Show_Id { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Country_Id { get; set; }
        public string? OfficialSite { get; set; }
        [NotMapped]
        public Show Show { get; set; }
        [NotMapped]
        public Country Country { get; set; }
    }
}
