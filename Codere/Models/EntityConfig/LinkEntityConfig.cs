using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class LinkEntityConfig
    {
        public static void SetLinkEntityConfig(EntityTypeBuilder<Link> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id_key);
            //entityBuilder.Property(x => x.Self_Href).IsRequired();
            //entityBuilder.Property(x => x.Previousepisode_Href).IsRequired();
            //entityBuilder.Property(x => x.Previousepisode_Name).IsRequired();
        }
    }
}
