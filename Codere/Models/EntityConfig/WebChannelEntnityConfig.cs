using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class WebChannelEntnityConfig
    {
        public static void SetWebChannelEntityConfig(EntityTypeBuilder<WebChannel> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id_key);
        }
    }
}
