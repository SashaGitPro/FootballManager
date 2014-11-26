﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="SoftServe">
//   Copyright (c) SoftServe. All rights reserved.
// </copyright>
// <summary>
//   Defines IRepository contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoftServe.FootballManager.DAL.Contracts
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Describe methods to work with data from store.
    /// </summary>
    /// <typeparam name="T">The type from the store.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Gets all elements of T type.
        /// </summary>
        /// <returns>Collection of T type objects from the store.</returns>
        IQueryable<T> FindAll();

        /// <summary>
        /// Gets specified elements of T type.
        /// </summary>
        /// <param name="predicate">Condition to get T type elements.</param>
        /// <returns>Elements specified by the condition.</returns>
        IQueryable<T> FindWhere(Expression<Func<T, bool>> predicate);

        ///// <summary>
        ///// Find by id
        ///// </summary>
        ///// <param name="id">Id to find</param>
        ///// <returns>T instance with id</returns>
        //T FindById(int id);

        /// <summary>
        /// Adds the T type element to the store.
        /// </summary>
        /// <param name="newEntity">Element to add.</param>
        void Add(T newEntity);

        /// <summary>
        /// Update the T type element to the DB.
        /// </summary>
        /// <param name="oldEntity">Element to add.</param>
        void Update(T oldEntity);

        /// <summary>
        /// Deletes the specified T type element from the store.
        /// </summary>
        /// <param name="entity">Element to delete.</param>
        void Remove(T entity);
    }
}
