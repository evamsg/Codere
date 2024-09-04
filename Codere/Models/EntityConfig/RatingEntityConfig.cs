using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class RatingEntityConfig
    {
        public static void SetRatingEntityConfig(EntityTypeBuilder<Rating> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id_key);
        }
    }
}
