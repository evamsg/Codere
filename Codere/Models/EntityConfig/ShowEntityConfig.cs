using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class ShowEntityConfig
    {
        public static void SetShowEntityConfig(EntityTypeBuilder<Show> entityBuilder)
        {
            entityBuilder.HasKey( x => x.IdKey);
            //entityBuilder.Property(x => x.Url).IsRequired();
            //entityBuilder.Property(x => x.Name).IsRequired();
            //entityBuilder.Property(x => x.Type).IsRequired();
            //entityBuilder.Property(x => x.Language).IsRequired();
            //entityBuilder.Property(x => x.Status).IsRequired();
            //entityBuilder.Property(x => x.AverageRuntime).IsRequired();
            //entityBuilder.Property(x => x.Premiered).IsRequired();
            //entityBuilder.Property(x => x.Ended).IsRequired();
            //entityBuilder.Property(x => x.OfficialSite).IsRequired();
            //entityBuilder.Property(x => x.Weight).IsRequired();
            //entityBuilder.Property(x => x.Summary).IsRequired();
            //entityBuilder.Property(x => x.Updated).IsRequired();
            //entityBuilder.Property(x => x.Rating_Average).IsRequired();

            //entityBuilder.Ignore(x => x.LibroAutor);

        }
    }
}
