// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FootballManagerContext.cs" company="SoftServe">
//   Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <summary>
//   Defines Entity Framework implementation of the IUnitOfWork contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoftServe.FootballManager.DAL.Models
{
    using System.Data.Entity;

    /// <summary>
    /// Context class for the application.
    /// </summary>
    public class FootballManagerContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FootballManagerContext"/> class.
        /// </summary>
        public FootballManagerContext()
            : base("name=FootballManagerContext")
        {
        }

        /// <summary>
        /// Gets or sets Club database set.
        /// </summary>
        public virtual DbSet<Club> Club { get; set; }

        /// <summary>
        /// Gets or sets Player database set.
        /// </summary>
        public virtual DbSet<Player> Player { get; set; }

        /// <summary>
        /// Gets or sets Tournaments database set.
        /// </summary>
        public virtual DbSet<Tournament> Tournament { get; set; }

        /// <summary>
        /// Code first representation of the database.
        /// </summary>
        /// <param name="modelBuilder">Code first for database.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.President)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .Property(e => e.Coach)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Players)
                .WithRequired(e => e.Club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Tournaments)
                .WithMany(e => e.Clubs)
                .Map(m => m.ToTable("ClubToTournament").MapLeftKey("ClubId").MapRightKey("TournamentId"));

            modelBuilder.Entity<Player>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.BornCountry)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .Property(e => e.MainPosition)
                .IsUnicode(false);

            modelBuilder.Entity<Tournament>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
