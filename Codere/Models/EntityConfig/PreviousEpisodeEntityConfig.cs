using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class PreviousEpisodeEntityConfig
    {
        public static void SetPreviousEpisodeEntityConfig(EntityTypeBuilder<PreviousEpisode> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id_key);
        }
    }
}
