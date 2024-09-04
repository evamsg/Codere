using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class ImageEntityConfig
    {
        public static void SetImageEntityConfig(EntityTypeBuilder<Image> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id_key);
            entityBuilder.Property(x => x.Id_key)
                .ValueGeneratedOnAdd()  // Indica que la columna es autonumérica
                .IsRequired();          // Asegura que la clave primaria no sea nula
            //entityBuilder.Property(x => x.Medium).IsRequired();
            //entityBuilder.Property(x => x.Original).IsRequired();
        }
    }
}
