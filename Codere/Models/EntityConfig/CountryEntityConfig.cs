using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class CountryEntityConfig
    {
        public static void SetCountryEntityConfig(EntityTypeBuilder<Country> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id_key);
            entityBuilder.Property(x => x.Id_key)
                .ValueGeneratedOnAdd()  // Indica que la columna es autonumérica
                .IsRequired();          // Asegura que la clave primaria no sea nula
        }
    }
}
