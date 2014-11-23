// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NinjectDataAccessModule.cs" company="SoftServe">
//   Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <summary>
//   Defines the NinjectDataAccessModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoftServe.FootballManager.DAL
{
    using Ninject.Modules;
    using SoftServe.FootballManager.DAL.Contracts;
    using SoftServe.FootballManager.DAL.Services;

    /// <summary>
    /// DataAccessModule class.
    /// </summary>
    public class NinjectDataAccessModule : NinjectModule
    {
        /// <summary>
        /// Method on load.
        /// </summary>
        public override void Load()
        {
            this.Bind<IUnitOfWorkFactory>().To<EFUnitOfWorkFactory>();
        }
    }
}
