// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWorkFactory.cs" company="SoftServe">
//   Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <summary>
//   Defines the IUnitOfWorkFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoftServe.FootballManager.DAL.Contracts
{
    /// <summary>
    /// IUnitOfWorkFactory interface.
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Create volley unit of work method.
        /// </summary>
        /// <returns>Return result.</returns>
        IFootballManagerUnitOfWork CreateFootballManagerUnitOfWork();
    }
}
