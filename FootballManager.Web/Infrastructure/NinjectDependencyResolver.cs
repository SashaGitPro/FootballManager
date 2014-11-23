// ------------------------------------------------------------------------------------------------
// <copyright file="NinjectDependencyResolver.cs" company="SoftServe">
//   Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <summary>
//   Defines the NinjectDependencyResolver type.
// </summary>
// -----------------------------------------------------------------------------------------
namespace SoftServe.FootballManager.Web.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using Ninject;
    using Ninject.Web.Common;
    using SoftServe.FootballManager.DAL;
    
    /// <summary>
    /// DependencyResolver class.
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        /// <summary>
        /// IKernel kernel.
        /// </summary>
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyResolver"/> class. 
        /// Initializes a new instance of the DependencyResolver class.
        /// </summary>
        public NinjectDependencyResolver()
        {
            this.kernel = CreateKernel();
        }

        /// <summary>
        /// Get service method.
        /// </summary>
        /// <param name="serviceType">Service type.</param>
        /// <returns>Return service.</returns>
        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        /// <summary>
        /// Get services service method.
        /// </summary>
        /// <param name="serviceType">Service type.</param>
        /// <returns>Return services.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel(
                new NinjectDataAccessModule()
            );
            //kernel.Inject(Roles.Provider);
            return kernel;
        }
    }
}