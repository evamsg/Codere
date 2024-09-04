using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codere.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_key { get; set; }
        public int Id { get; set; }
        //puede estar en WebChannel o en Network
        //si es de WebChanel le añado W al principio, si es Network le añado N
        public string? IdPadre { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? TimeZone { get; set; }
        [NotMapped]
        public Show Show { get; set; }
    }
}
