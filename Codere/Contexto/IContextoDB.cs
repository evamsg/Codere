using Codere.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Codere.Contexto
{
    public interface IContextoDB
    {
        DbSet<Country> Countries { get; set; }
        DbSet<External> Externals { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Link> Links { get; set; }
        DbSet<Network> Networks { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<Schedule> Schedules { get; set; }
        DbSet<Show> Shows { get; set; }
        DbSet<ShowGenre> ShowGenres { get; set; }
        DbSet<WebChannel> WebChannels { get; set; }
        DbSet<DvdCountry> DvdCountries { get; set; }
        DbSet<PreviousEpisode> PreviousEpisodes { get; set; }

        DatabaseFacade Database { get; }
        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}
