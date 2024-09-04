using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class NetworkEntityConfig
    {
        public static void SetNetworkEntityConfig(EntityTypeBuilder<Network> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id_key);
            //entityBuilder.Property(x => x.Name).IsRequired();
            //entityBuilder.Property(x => x.Country).IsRequired();
            //entityBuilder.Property(x => x.OfficialSite).IsRequired();
        }
    }
}
