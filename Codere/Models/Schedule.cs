using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codere.Models
{
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_key { get; set; }
        public int Id { get; set; }
        public int? Show_Id { get; set; }
        public string? Time { get; set; }
        public string? Day { get; set; }
        [NotMapped]
        public Show Show { get; set; }
    }
}
