using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codere.Models
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_key { get; set; }
        public int Id { get; set; }
        public int Show_Id { get; set; }
        public double? Average { get; set; }
        [NotMapped]
        public Show Show { get; set; }
    }
}
