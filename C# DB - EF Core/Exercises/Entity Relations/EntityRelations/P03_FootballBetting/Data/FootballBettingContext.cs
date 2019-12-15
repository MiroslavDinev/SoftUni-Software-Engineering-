using System;
using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.OnConfiguringTeams(modelBuilder);
            this.OnConfiguringColors(modelBuilder);
            this.OnConfiguringTowns(modelBuilder);
            this.OnConfiguringCountry(modelBuilder);
            this.OnConfiguringPlayers(modelBuilder);
            this.OnConfiguringPositions(modelBuilder);
            this.OnConfiguringPlayerStatistics(modelBuilder);
            this.OnConfiguringPlayerGames(modelBuilder);
            this.OnConfiguringPlayerBets(modelBuilder);
            this.OnConfiguringPlayerUsers(modelBuilder);
        }

        private void OnConfiguringPlayerUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.UserId);
        }

        private void OnConfiguringPlayerBets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasKey(e => e.BetId);

                entity
                .HasOne(e => e.Game)
                .WithMany(g => g.Bets);

                entity
                .HasOne(e => e.User)
                .WithMany(u => u.Bets);
            });
        }

        private void OnConfiguringPlayerGames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity
                .HasOne(e => e.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(e => e.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(e => e.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(e => e.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void OnConfiguringPlayerStatistics(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.GameId });

                entity
                .HasOne(e => e.Player)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(e => e.PlayerId);

                entity
                .HasOne(e => e.Game)
                .WithMany(g => g.PlayerStatistics)
                .HasForeignKey(e => e.GameId);
            });
        }

        private void OnConfiguringPositions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasKey(e => e.PositionId);
        }

        private void OnConfiguringPlayers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity
                .HasOne(e => e.Team)
                .WithMany(t => t.Players);

                entity
                .HasOne(e => e.Position)
                .WithMany(p => p.Players);
            });
        }

        private void OnConfiguringCountry(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasKey(e => e.CountryId);
        }

        private void OnConfiguringTowns(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Town>(entity=>
            {
                entity.HasKey(e => e.TownId);

                entity
                .HasOne(e => e.Country)
                .WithMany(c => c.Towns);
            });
        }

        private void OnConfiguringColors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.ColorId);
            });
        }

        private void OnConfiguringTeams(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.Property(e => e.Initials)
                .HasColumnType("CHAR(3)");

                entity
                .HasOne(e => e.PrimaryKitColor)
                .WithMany(pc => pc.PrimaryKitTeams)
                .HasForeignKey(e => e.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.SecondaryKitColor)
                .WithMany(sc => sc.SecondaryKitTeams)
                .HasForeignKey(e => e.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(e => e.Town)
                .WithMany(t => t.Teams);
            });
        }
    }
}
