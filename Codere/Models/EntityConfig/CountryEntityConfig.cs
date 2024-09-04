using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class CountryEntityConfig
    {
        public static void SetCountryEntityConfig(EntityTypeBuilder<Country> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id_key);

        }
    }
}
