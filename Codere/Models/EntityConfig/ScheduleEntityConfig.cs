using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class ScheduleEntityConfig
    {
        public static void SetScheduleEntityConfig(EntityTypeBuilder<Schedule> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id_key);
            entityBuilder.Property(x => x.Id_key)
                .ValueGeneratedOnAdd()  // Indica que la columna es autonumérica
                .IsRequired();          // Asegura que la clave primaria no sea nula
            //entityBuilder.Property(x => x.Time).IsRequired();
            //entityBuilder.Property(x => x.Day).IsRequired();
        }
    }
}
