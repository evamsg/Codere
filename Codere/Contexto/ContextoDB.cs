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

            modelBuilder.Entity<Country>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<DvdCountry>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<External>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Image>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Link>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Network>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<PreviousEpisode>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Rating>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Schedule>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<ShowGenre>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<WebChannel>()
        .Property(x => x.Id_key)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Show>()
           .HasOne(s => s.DvdCountry)
           .WithOne(sd => sd.Show)
           .HasForeignKey<DvdCountry>(sd => sd.Show_Id);

            modelBuilder.Entity<DvdCountry>()
        .HasKey(sd => sd.Show_Id);

            modelBuilder.Entity<Show>()
          .HasOne(s => s.External)
          .WithOne(sd => sd.Show)
          .HasForeignKey<External>(sd => sd.Show_Id);

            modelBuilder.Entity<External>()
        .HasKey(sd => sd.Show_Id);

            modelBuilder.Entity<Show>()
          .HasOne(s => s.Image)
          .WithOne(sd => sd.Show)
          .HasForeignKey<Image>(sd => sd.Show_Id);

            modelBuilder.Entity<Image>()
        .HasKey(sd => sd.Show_Id);

            modelBuilder.Entity<Show>()
          .HasOne(s => s.Link)
          .WithOne(sd => sd.Show)
          .HasForeignKey<Link>(sd => sd.Show_Id);

            modelBuilder.Entity<Link>()
        .HasKey(sd => sd.Show_Id);

            modelBuilder.Entity<Show>()
          .HasOne(s => s.Network)
          .WithOne(sd => sd.Show)
          .HasForeignKey<Network>(sd => sd.Show_Id);

            modelBuilder.Entity<Network>()
        .HasKey(sd => sd.Show_Id);

            modelBuilder.Entity<Show>()
          .HasOne(s => s.PreviousEpisode)
          .WithOne(sd => sd.Show)
          .HasForeignKey<PreviousEpisode>(sd => sd.Show_Id);

            modelBuilder.Entity<PreviousEpisode>()
        .HasKey(sd => sd.Show_Id);

            modelBuilder.Entity<Show>()
          .HasOne(s => s.Rating)
          .WithOne(sd => sd.Show)
          .HasForeignKey<Rating>(sd => sd.Show_Id);

            modelBuilder.Entity<Rating>()
        .HasKey(sd => sd.Show_Id);

            modelBuilder.Entity<Show>()
          .HasOne(s => s.Schedule)
          .WithOne(sd => sd.Show)
          .HasForeignKey<Schedule>(sd => sd.Show_Id);

            modelBuilder.Entity<Schedule>()
        .HasKey(sd => sd.Show_Id);

            modelBuilder.Entity<Show>()
          .HasOne(s => s.WebChannel)
          .WithOne(sd => sd.Show)
          .HasForeignKey<WebChannel>(sd => sd.Show_Id);

            modelBuilder.Entity<WebChannel>()
        .HasKey(sd => sd.Show_Id);


            base.OnModelCreating(modelBuilder);
        }

    }
}
