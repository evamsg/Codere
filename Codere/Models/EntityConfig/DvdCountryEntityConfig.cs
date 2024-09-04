using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class DvdCountryEntityConfig
    {
        public static void SetDvdCountrEntityConfig(EntityTypeBuilder<DvdCountry> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id_key);
        }
    }
}
