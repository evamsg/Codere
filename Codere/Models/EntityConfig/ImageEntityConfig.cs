using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class ImageEntityConfig
    {
        public static void SetImageEntityConfig(EntityTypeBuilder<Image> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id_key);
            //entityBuilder.Property(x => x.Medium).IsRequired();
            //entityBuilder.Property(x => x.Original).IsRequired();
        }
    }
}
