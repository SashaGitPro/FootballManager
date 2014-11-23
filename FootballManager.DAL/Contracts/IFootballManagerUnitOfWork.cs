// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFootballManagerUnitOfWork.cs" company="SoftServe">
//   Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <summary>
//   Defines IUnitOfWork contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoftServe.FootballManager.DAL.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using SoftServe.FootballManager.DAL.Models;

    /// <summary>
    /// Describe methods to work with the store.
    /// </summary>
    public interface IFootballManagerUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets Author repository.
        /// </summary>
        /// <value>
        /// The authors.
        /// </value>
        IRepository<Club> Clubs
        {
            get;
        }

        /// <summary>
        /// Gets Publisher repository.
        /// </summary>
        /// <value>
        /// The Publishers.
        /// </value>
        IRepository<Player> Players
        {
            get;
        }

        /// <summary>
        /// Gets Book repository.
        /// </summary>
        /// <value>
        /// The Books.
        /// </value>
        IRepository<Tournament> Tournaments
        {
            get;
        }

        /// <summary>
        /// Commits all the changes the store.
        /// </summary>
        void Commit();
    }
}
