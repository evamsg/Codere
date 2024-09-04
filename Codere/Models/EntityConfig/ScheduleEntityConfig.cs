using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codere.Models.EntityConfig
{
    public class ScheduleEntityConfig
    {
        public static void SetScheduleEntityConfig(EntityTypeBuilder<Schedule> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id_key);
            //entityBuilder.Property(x => x.Time).IsRequired();
            //entityBuilder.Property(x => x.Day).IsRequired();
        }
    }
}
