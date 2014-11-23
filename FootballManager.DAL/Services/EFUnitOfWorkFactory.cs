// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EFUnitOfWorkFactory.cs" company="SoftServe">
//   Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <summary>
//   Defines the EFUnitOfWorkFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoftServe.FootballManager.DAL.Services
{
    using System;

    using SoftServe.FootballManager.DAL.Contracts;
    
    /// <summary>
    /// EFUnitOfWorkFactory class.
    /// </summary>
    public class EFUnitOfWorkFactory : IUnitOfWorkFactory
    {
        /// <summary>
        /// CreateVolleyUnitOfWork method.
        /// </summary>
        /// <returns>Return IVolleyUnitOfWork.</returns>
        public IFootballManagerUnitOfWork CreateFootballManagerUnitOfWork()
        {
            return new EFFootballManagerUnitOfWork();
        }
    }
}
