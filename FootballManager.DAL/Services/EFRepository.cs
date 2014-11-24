// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EFRepository.cs" company="SoftServe">
//   Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <summary>
//   Defines Entity Framework implementation of the IRepository contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoftServe.FootballManager.DAL.Services
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using System.Linq.Expressions;
    using SoftServe.FootballManager.DAL.Contracts;

    /// <summary>
    /// Entity Framework implementation of the IRepository contract.
    /// </summary>
    /// <typeparam name="T">The type from the store.</typeparam>
    internal class EFRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Context object.
        /// </summary>
        private ObjectSet<T> objectSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="EFRepository{T}"/> class. 
        /// </summary>
        /// <param name="context">
        /// Data store context.
        /// </param>>
        public EFRepository(ObjectContext context)
        {
            this.objectSet = context.CreateObjectSet<T>();
        }

        /// <summary>
        /// Gets all the data from the context.
        /// </summary>
        /// <returns>All elements from the context.</returns>
        public IQueryable<T> FindAll()
        {
            return this.objectSet;
        }

        /// <summary>
        /// Gets specified elements from the context.
        /// </summary>
        /// <param name="predicate">Condition to find elements.</param>
        /// <returns>Specified elements from context.</returns>
        public IQueryable<T> FindWhere(Expression<Func<T, bool>> predicate)
        {
            return this.objectSet.Where(predicate);
        }

      
        /// <summary>
        /// Adds specified element to the context.
        /// </summary>
        /// <param name="newEntity">The element to add.</param>
        public void Add(T newEntity)
        {
            this.objectSet.AddObject(newEntity);
        }

        /// <summary>
        /// Removes specified element from the context.
        /// </summary>
        /// <param name="entity">The element to remove.</param>
        public void Remove(T entity)
        {
            this.objectSet.DeleteObject(entity);
        }

        /// <summary>
        /// Updates entity.
        /// </summary>
        /// <param name="updatedEntity">Entity to update.</param>
        public void Update(T updatedEntity)
        {
            this.objectSet.Attach(updatedEntity);
            this.objectSet.Context.ObjectStateManager.ChangeObjectState(updatedEntity, EntityState.Modified);
        }
    }
}
