using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;

namespace MVVMExpenses.Common.DataModel {
    /// <summary>
    /// The IReadOnlyRepository interface represents the read-only implementation of the Repository pattern 
    /// such that it can be used to query entities of a given type. 
    /// </summary>
    /// <typeparam name="TEntity">Repository entity type.</typeparam>
    public interface IReadOnlyRepository<TEntity> : IRepositoryQuery<TEntity> where TEntity : class {

        /// <summary>
        /// The owner unit of work.
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
    }

    /// <summary>
    /// The IRepositoryQuery interface represents an extension of IQueryable designed to provide an ability to specify the related objects to include in the query results.
    /// </summary>
    /// <typeparam name="T">An entity type.</typeparam>
    public interface IRepositoryQuery<T> : IQueryable<T> {

        /// <summary>
        /// Specifies the related objects to include in the query results.
        /// </summary>
        /// <typeparam name="TProperty">The type of the navigation property to be included.</typeparam>
        /// <param name="path">A lambda expression that represents the path to include.</param>
        IRepositoryQuery<T> Include<TProperty>(Expression<Func<T, TProperty>> path);

        /// <summary>
        /// Filters a sequence of entities based on the given predicate.
        /// </summary>
        /// <param name="predicate">A function to test each entity for a condition.</param>
        IRepositoryQuery<T> Where(Expression<Func<T, bool>> predicate);
    }

    /// <summary>
    /// The base class that helps to implement the IRepositoryQuery interface as a wrapper over an existing IQuerable instance.
    /// </summary>
    /// <typeparam name="T">An entity type.</typeparam>
    public abstract class RepositoryQueryBase<T> : IQueryable<T> {
        readonly Lazy<IQueryable<T>> queryable;
        protected IQueryable<T> Queryable { get { return queryable.Value; } }
        protected RepositoryQueryBase(Func<IQueryable<T>> getQueryable) {
            this.queryable = new Lazy<IQueryable<T>>(getQueryable);
        }
        Type IQueryable.ElementType { get { return this.Queryable.ElementType; } }
        Expression IQueryable.Expression { get { return this.Queryable.Expression; } }
        IQueryProvider IQueryable.Provider { get { return this.Queryable.Provider; } }
        IEnumerator IEnumerable.GetEnumerator() { return this.Queryable.GetEnumerator(); }
        IEnumerator<T> IEnumerable<T>.GetEnumerator() { return this.Queryable.GetEnumerator(); }
    }

    /// <summary>
    /// Provides a set of extension methods to perform commonly used operations with IReadOnlyRepository.
    /// </summary>
    public static class ReadOnlyRepositoryExtensions {
        /// <summary>
        /// Returns IQuerable representing sequence of entities from repository filtered by the given predicate and projected to the specified projection entity type by the given LINQ function.
        /// </summary>
        /// <typeparam name="TEntity">A repository entity type.</typeparam>
        /// <typeparam name="TProjection">A projection entity type.</typeparam>
        /// <param name="repository">A repository.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="projection">A LINQ function used to transform entities from repository entity type to projection entity type.</param>
        public static IQueryable<TProjection> GetFilteredEntities<TEntity, TProjection>(this IReadOnlyRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate, Func<IRepositoryQuery<TEntity>, IQueryable<TProjection>> projection) where TEntity : class {
            return AppendToProjection(predicate, projection)(repository);
        }

        /// <summary>
        /// Combines an initial projection and a predicate into a new projection with the effect of both.
        /// </summary>
        /// <typeparam name="TEntity">A repository entity type.</typeparam>
        /// <typeparam name="TProjection">A projection entity type.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="projection">A LINQ function used to transform entities from repository entity type to projection entity type.</param>
        /// <returns></returns>
        public static Func<IRepositoryQuery<TEntity>, IQueryable<TProjection>> AppendToProjection<TEntity, TProjection>(Expression<Func<TEntity, bool>> predicate, Func<IRepositoryQuery<TEntity>, IQueryable<TProjection>> projection) where TEntity : class {
            if(predicate == null && projection == null)
                return q => (IQueryable<TProjection>)q;
            if(predicate == null)
                return projection;
            if(projection == null)
                return q => (IQueryable<TProjection>)q.Where(predicate);
            return q => projection(q.Where(predicate));
        }

        /// <summary>
        /// Returns IQuerable representing sequence of entities from repository filtered by the given predicate.
        /// </summary>
        /// <typeparam name="TEntity">A repository entity type.</typeparam>
        /// <param name="repository">A repository.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        public static IQueryable<TEntity> GetFilteredEntities<TEntity>(this IReadOnlyRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate) where TEntity : class {
            return repository.GetFilteredEntities(predicate, x => x);
        }
    }
}
