using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class ShowGenreEntityConfig
    {
        public static void SetShowGenreEntityConfig(EntityTypeBuilder<ShowGenre> entityBuilder)
        {
            entityBuilder.HasKey( x => x.Id_key);
        }
    }
}
