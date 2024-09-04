using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class ExternalEntityConfig
    {
        public static void SetExternalEntityConfig(EntityTypeBuilder<External> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id_key);
            //entityBuilder.Property(x => x.Tvrage).IsRequired();
            //entityBuilder.Property(x => x.Thetvdb).IsRequired();
            //entityBuilder.Property(x => x.Imdb).IsRequired();
        }
    }
}
