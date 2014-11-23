// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EFFootballManagerUnitOfWork.cs" company="SoftServe">
//   Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <summary>
//   Defines Entity Framework implementation of the IUnitOfWork contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoftServe.FootballManager.DAL.Services
{
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using SoftServe.FootballManager.DAL.Contracts;
    using SoftServe.FootballManager.DAL.Models;

    /// <summary>
    /// Describe methods to work with the store.
    /// </summary>
    public class EFFootballManagerUnitOfWork : IFootballManagerUnitOfWork
    {
        /// <summary>
        /// Context of the data source.
        /// </summary>
        private readonly ObjectContext context;
        
        /// <summary>
        /// Player EF repository.
        /// </summary>
        private EFRepository<Club> clubs;

        /// <summary>
        /// Player EF repository.
        /// </summary>
        private EFRepository<Player> players;

        /// <summary>
        /// Role EF repository.
        /// </summary>
        private EFRepository<Tournament> tournaments;

        /// <summary>
        /// Initializes a new instance of the <see cref="EFFootballManagerUnitOfWork"/> class.
        /// </summary>
        public EFFootballManagerUnitOfWork()
        {
            this.context = ((IObjectContextAdapter)new FootballManagerContext()).ObjectContext;
            this.context.ContextOptions.LazyLoadingEnabled = true;
        }
        
        /// <summary>
        /// Gets players repository.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        public IRepository<Club> Clubs
        {
            get
            {
                if (this.clubs == null)
                {
                    this.clubs = new EFRepository<Club>(this.context);
                }

                return this.clubs;
            }
        }

        /// <summary>
        /// Gets teamPlayers repository.
        /// </summary>
        /// <value>
        /// The team players.
        /// </value>
        public IRepository<Player> Players
        {
            get
            {
                if (this.players == null)
                {
                    this.players = new EFRepository<Player>(this.context);
                }

                return this.players;
            }
        }

        /// <summary>
        /// Gets teamPlayers repository.
        /// </summary>
        /// <value>
        /// The team players.
        /// </value>
        public IRepository<Tournament> Tournaments
        {
            get
            {
                if (this.tournaments == null)
                {
                    this.tournaments = new EFRepository<Tournament>(this.context);
                }

                return this.tournaments;
            }
        }
      
        /// <summary>
        /// Commits all the changes.
        /// </summary>
        public void Commit()
        {
            this.context.SaveChanges();
        }

        /// <summary>
        /// IDisposable.Dispose method implementation.
        /// </summary>
        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
