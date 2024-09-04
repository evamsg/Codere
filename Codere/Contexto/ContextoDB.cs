using Codere.Models;
using Codere.Models.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Codere.Contexto
{
    public class ContextoDB : DbContext, IContextoDB
    {
        public ContextoDB(DbContextOptions<ContextoDB> options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<External> Externals { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowGenre> ShowGenres { get; set; }
        public DbSet<WebChannel> WebChannels { get; set; }
        public DbSet<DvdCountry> DvdCountries { get; set; }
        public DbSet<PreviousEpisode> PreviousEpisodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CountryEntityConfig.SetCountryEntityConfig(modelBuilder.Entity<Country>());
            DvdCountryEntityConfig.SetDvdCountrEntityConfig(modelBuilder.Entity<DvdCountry>());
            ShowEntityConfig.SetShowEntityConfig(modelBuilder.Entity<Show>());
            ExternalEntityConfig.SetExternalEntityConfig(modelBuilder.Entity<External>());
            ImageEntityConfig.SetImageEntityConfig(modelBuilder.Entity<Image>());
            LinkEntityConfig.SetLinkEntityConfig(modelBuilder.Entity<Link>());
            NetworkEntityConfig.SetNetworkEntityConfig(modelBuilder.Entity<Network>());
            RatingEntityConfig.SetRatingEntityConfig(modelBuilder.Entity<Rating>());
            ScheduleEntityConfig.SetScheduleEntityConfig(modelBuilder.Entity<Schedule>());
            ShowGenreEntityConfig.SetShowGenreEntityConfig(modelBuilder.Entity<ShowGenre>());
            WebChannelEntnityConfig.SetWebChannelEntityConfig(modelBuilder.Entity<WebChannel>());
            PreviousEpisodeEntityConfig.SetPreviousEpisodeEntityConfig(modelBuilder.Entity<PreviousEpisode>());

            modelBuilder.Entity<Country>().HasKey(e => e.Id_key);
            modelBuilder.Entity<Country>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<DvdCountry>().HasKey(e => e.Id_key);
            modelBuilder.Entity<DvdCountry>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<External>().HasKey(e => e.Id_key);
            modelBuilder.Entity<External>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Image>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Link>().HasKey(e => e.Id_key);
            modelBuilder.Entity<Link>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Network>().HasKey(e => e.Id_key);
            modelBuilder.Entity<Network>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<PreviousEpisode>().HasKey(e => e.Id_key);
            modelBuilder.Entity<PreviousEpisode>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Rating>().HasKey(e => e.Id_key);
            modelBuilder.Entity<Rating>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Schedule>().HasKey(e => e.Id_key);
            modelBuilder.Entity<Schedule>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<ShowGenre>().HasKey(e => e.Id_key);
            modelBuilder.Entity<ShowGenre>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<WebChannel>().HasKey(e => e.Id_key);
            modelBuilder.Entity<WebChannel>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Show>().HasKey(e => e.IdKey); // Define la clave primaria
            modelBuilder.Entity<Show>()
        .Property(x => x.IdKey)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Show>()
        .HasOne(s => s.DvdCountry)
        .WithOne(sd => sd.Show)
        .HasForeignKey<DvdCountry>(sd => sd.Show_Id) // Clave foránea en Schedule
        .HasPrincipalKey<Show>(s => s.Id); // Clave principal no primaria en Show

            modelBuilder.Entity<Show>()
         .HasOne(s => s.External)
         .WithOne(sd => sd.Show)
         .HasForeignKey<External>(sd => sd.Show_Id) // Clave foránea en Schedule
         .HasPrincipalKey<Show>(s => s.Id); // Clave principal no primaria en Show

            modelBuilder.Entity<Show>()
        .HasOne(s => s.Image)
        .WithOne(sd => sd.Show)
        .HasForeignKey<Image>(sd => sd.Show_Id) // Clave foránea en Schedule
        .HasPrincipalKey<Show>(s => s.Id); // Clave principal no primaria en Show

            modelBuilder.Entity<Show>()
        .HasOne(s => s.Link)
        .WithOne(sd => sd.Show)
        .HasForeignKey<Link>(sd => sd.Show_Id) // Clave foránea en Schedule
        .HasPrincipalKey<Show>(s => s.Id); // Clave principal no primaria en Show

            modelBuilder.Entity<Show>()
        .HasOne(s => s.Network)
        .WithOne(sd => sd.Show)
        .HasForeignKey<Network>(sd => sd.Show_Id) // Clave foránea en Schedule
        .HasPrincipalKey<Show>(s => s.Id); // Clave principal no primaria en Show

            modelBuilder.Entity<Show>()
        .HasOne(s => s.PreviousEpisode)
        .WithOne(sd => sd.Show)
        .HasForeignKey<PreviousEpisode>(sd => sd.Show_Id) // Clave foránea en Schedule
        .HasPrincipalKey<Show>(s => s.Id); // Clave principal no primaria en Show

            modelBuilder.Entity<Show>()
        .HasOne(s => s.Rating)
        .WithOne(sd => sd.Show)
        .HasForeignKey<Rating>(sd => sd.Show_Id) // Clave foránea en Schedule
        .HasPrincipalKey<Show>(s => s.Id); // Clave principal no primaria en Show

            modelBuilder.Entity<Show>()
        .HasOne(s => s.Schedule)
        .WithOne(sd => sd.Show)
        .HasForeignKey<Schedule>(sd => sd.Show_Id) // Clave foránea en Schedule
        .HasPrincipalKey<Show>(s => s.Id); // Clave principal no primaria en Show

            modelBuilder.Entity<Show>()
        .HasOne(s => s.WebChannel)
        .WithOne(sd => sd.Show)
        .HasForeignKey<WebChannel>(sd => sd.Show_Id) // Clave foránea en Schedule
        .HasPrincipalKey<Show>(s => s.Id); // Clave principal no primaria en Show


            base.OnModelCreating(modelBuilder);
        }

    }
}
