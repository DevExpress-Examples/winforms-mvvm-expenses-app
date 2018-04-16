using System;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel;
using MVVMExpenses.Common.Utils;

namespace MVVMExpenses.Common.DataModel {
    /// <summary>
    /// The IRepository interface represents the read and write implementation of the Repository pattern 
    /// such that it can be used to query entities of a given type. 
    /// </summary>
    /// <typeparam name="TEntity">A repository entity type.</typeparam>
    /// <typeparam name="TPrimaryKey">An entity primary key type.</typeparam>
    public interface IRepository<TEntity, TPrimaryKey> : IReadOnlyRepository<TEntity> where TEntity : class {

        /// <summary>
        /// Finds an entity with the given primary key value. 
        /// If an entity with the given primary key value exists in the unit of work, then it is returned immediately without making a request to the store. 
        /// Otherwise, a request is made to the store for an entity with the given primary key value and this entity, if found, is attached to the unit of work and returned. 
        /// If no entity is found in the unit of work or the store, then null is returned.
        /// </summary>
        /// <param name="primaryKey">The value of the primary key for the entity to be found.</param>
        TEntity Find(TPrimaryKey primaryKey);

        /// <summary>
        /// Marks the given entity as Added such that it will be commited to the store when IUnitOfWork.SaveChanges is called.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Marks the given entity as Deleted such that it will be deleted from the store when IUnitOfWork.SaveChanges is called. 
        /// Note that the entity must exist in the unit of work in some other state before this method is called.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Creates a new instance of the entity type.
        /// </summary>
        /// <param name="add">A flag determining if the newly created entity is added to the repository.</param>
        TEntity Create(bool add = true);

        /// <summary>
        /// Returns the state of the given entity.
        /// </summary>
        /// <param name="entity">An entity to get state from</param>
        EntityState GetState(TEntity entity);

        /// <summary>
        /// Changes the state of the specified entity to Modified if changes are not automatically tracked by the implementation.
        /// </summary>
        /// <param name="entity">An entity which state should be updated/</param>
        void Update(TEntity entity);

        /// <summary>
        /// Reloads the entity from the store overwriting any property values with values from the store and returns a reloaded entity. 
        /// This method returns the same entity instance with updated properties or new one depending on the implementation.
        /// The entity will be in the Unchanged state after calling this method.
        /// </summary>
        /// <param name="entity">An entity to reload.</param>
        TEntity Reload(TEntity entity);

        /// <summary>
        /// The lambda-expression that returns the entity primary key.
        /// </summary>
        Expression<Func<TEntity, TPrimaryKey>> GetPrimaryKeyExpression { get; }

        /// <summary>
        /// Returns the primary key value for the entity.
        /// </summary>
        /// <param name="entity">An entity for which to obtain a primary key value.</param>
        TPrimaryKey GetPrimaryKey(TEntity entity);

        /// <summary>
        /// Determines whether the given entity has the primary key assigned (the primary key is not null). Always returns true if the primary key is a non-nullable value type.
        /// </summary>
        /// <param name="entity">An entity to test.</param>
        bool HasPrimaryKey(TEntity entity);

        /// <summary>
        /// Assigns the given primary key value to a given entity.
        /// </summary>
        /// <param name="entity">An entity to which to assign the primary key value.</param>
        /// <param name="primaryKey">A primary key value</param>
        void SetPrimaryKey(TEntity entity, TPrimaryKey primaryKey);
    }

    /// <summary>
    /// Provides a set of extension methods to perform commonly used operations with IRepository.
    /// </summary>
    public static class RepositoryExtensions {
        public static Expression<Func<TProjection, TPrimaryKey>> GetProjectionPrimaryKeyExpression<TEntity, TProjection, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository) where TEntity : class {
            var parameter = Expression.Parameter(typeof(TProjection));
            return Expression.Lambda<Func<TProjection, TPrimaryKey>>(Expression.Property(parameter, repository.GetPrimaryKeyPropertyName()), parameter);
        }

        /// <summary>
        /// Builds a lambda expression that compares an entity primary key with the given constant value.
        /// </summary>
        /// <typeparam name="TEntity">A repository entity type.</typeparam>
        /// <typeparam name="TPrimaryKey">An entity primary key type.</typeparam>
        /// <param name="repository">A repository.</param>
        /// <param name="primaryKey">A value to compare with the entity primary key.</param>
        public static Expression<Func<TEntity, bool>> GetPrimaryKeyEqualsExpression<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, TPrimaryKey primaryKey) where TEntity : class {
            return ExpressionHelper.GetValueEqualsExpression(repository.GetPrimaryKeyExpression, primaryKey);
        }

        /// <summary>
        /// Builds a lambda expression that compares an entity primary key with the given constant value.
        /// </summary>
        /// <typeparam name="TEntity">A repository entity type.</typeparam>
        /// <typeparam name="TProjection">A projection entity type.</typeparam>
        /// <typeparam name="TPrimaryKey">An entity primary key type.</typeparam>
        /// <param name="repository">A repository.</param>
        /// <param name="primaryKey">A value to compare with the entity primary key.</param>
        public static Expression<Func<TProjection, bool>> GetProjectionPrimaryKeyEqualsExpression<TEntity, TProjection, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, TPrimaryKey primaryKey) where TEntity : class {
            return GetProjectionValue(primaryKey,
                (TPrimaryKey x) => repository.GetPrimaryKeyEqualsExpression(x),
                (TPrimaryKey x) => {
                    var parameter = Expression.Parameter(typeof(TProjection));
                    var keyExpression = Expression.Lambda<Func<TProjection, TPrimaryKey>>(Expression.Property(parameter, repository.GetPrimaryKeyPropertyName()), parameter);
                    return ExpressionHelper.GetValueEqualsExpression(keyExpression, primaryKey);
                });
        }

        /// <summary>
        /// Returns a primary key of the given entity.
        /// </summary>
        /// <typeparam name="TEntity">A repository entity type.</typeparam>
        /// <typeparam name="TProjection">A projection entity type.</typeparam>
        /// <typeparam name="TPrimaryKey">An entity primary key type.</typeparam>
        /// <param name="repository">A repository.</param>
        /// <param name="projectionEntity">An entity.</param>
        public static TPrimaryKey GetProjectionPrimaryKey<TEntity, TProjection, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, TProjection projectionEntity) where TEntity : class {
            return GetProjectionValue(projectionEntity,
                (TEntity x) => {
                    if(repository.HasPrimaryKey(x)) {
                        return repository.GetPrimaryKey(x);
                    }
                    return default(TPrimaryKey);
                },
                (TProjection x) => (TPrimaryKey)GetProjectionKeyProperty<TEntity, TProjection, TPrimaryKey>(repository).GetValue(x));
        }

        private static PropertyDescriptor GetProjectionKeyProperty<TEntity, TProjection, TPrimaryKey>(IRepository<TEntity, TPrimaryKey> repository) where TEntity : class {
            return TypeDescriptor.GetProperties(typeof(TProjection))[repository.GetPrimaryKeyPropertyName()];
        }

        public static void VerifyProjection<TEntity, TProjection, TPrimaryKey>(IRepository<TEntity, TPrimaryKey> repository, Func<IRepositoryQuery<TEntity>, IQueryable<TProjection>> projection) where TEntity : class {
            if(typeof(TProjection) != typeof(TEntity) && projection == null)
                throw new ArgumentException("Projection should not be null when its type is different from TEntity.");
            if(GetProjectionKeyProperty<TEntity, TProjection, TPrimaryKey>(repository) == null) {
                string tprojectionName = typeof(TProjection).Name;
                throw new ArgumentException(string.Format("Projection type {0} should have primary key property {1}",
                    tprojectionName, repository.GetPrimaryKeyPropertyName()), tprojectionName);
            }
        }

        /// <summary>
        /// Sets the primary key of a given projection.
        /// </summary>
        /// <typeparam name="TEntity">A repository entity type.</typeparam>
        /// <typeparam name="TProjection">A projection entity type.</typeparam>
        /// <typeparam name="TPrimaryKey">An entity primary key type.</typeparam>
        /// <param name="repository">A repository.</param>
        /// <param name="projectionEntity">A projection.</param>
        /// <param name="primaryKey">A new primary key value.</param>
        public static void SetProjectionPrimaryKey<TEntity, TProjection, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, TProjection projectionEntity, TPrimaryKey primaryKey) where TEntity : class {
            if(IsProjection<TEntity, TProjection>(projectionEntity)) {
                GetProjectionKeyProperty<TEntity, TProjection, TPrimaryKey>(repository).SetValue(projectionEntity, primaryKey);
            }
            else {
                repository.SetPrimaryKey(projectionEntity as TEntity, primaryKey);
            }
        }

        /// <summary>
        /// Given a projection, this function returns the corresponding entity. 
        /// If the projection has no corresponding entity, a new entity is created and added to the repository.
        /// Before the new entity is returned, the applyProjectionPropertiesToEntity action is used to transfer property values from the projection to the entity.
        /// </summary>
        /// <typeparam name="TEntity">A repository entity type.</typeparam>
        /// <typeparam name="TProjection">A projection entity type.</typeparam>
        /// <typeparam name="TPrimaryKey">An entity primary key type.</typeparam>
        /// <param name="repository">A repository.</param>
        /// <param name="projectionEntity">A projection.</param>
        /// <param name="applyProjectionPropertiesToEntity">An action which applies the projection properties to the newly created entity.</param>		
        public static TEntity FindExistingOrAddNewEntity<TEntity, TProjection, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, TProjection projectionEntity, Action<TProjection, TEntity> applyProjectionPropertiesToEntity) where TEntity : class {
            bool projection = IsProjection<TEntity, TProjection>(projectionEntity);
            var entity = repository.Find(repository.GetProjectionPrimaryKey(projectionEntity));
            if(entity == null) {
                if(projection) {
                    entity = repository.Create();
                }
                else {
                    entity = projectionEntity as TEntity;
                    repository.Add(entity);
                }
            }
            if(projection) {
                applyProjectionPropertiesToEntity(projectionEntity, entity);
            }
            return entity;
        }

        /// <summary>
        /// Gets whether the given entity is detached from the unit of work.
        /// </summary>
        /// <typeparam name="TEntity">A repository entity type.</typeparam>
        /// <typeparam name="TProjection">A projection entity type.</typeparam>
        /// <typeparam name="TPrimaryKey">An entity primary key type.</typeparam>
        /// <param name="repository">A repository.</param>
        /// <param name="projectionEntity">An entity.</param>
        public static bool IsDetached<TEntity, TProjection, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, TProjection projectionEntity) where TEntity : class {
            return GetProjectionValue(projectionEntity,
                (TEntity x) => repository.GetState(x) == EntityState.Detached,
                (TProjection x) => false);
        }

        /// <summary>
        /// Determines whether the given entity has the primary key assigned (the primary key is not null). Always returns true if the primary key is a non-nullable value type.
        /// </summary>
        /// <typeparam name="TEntity">A repository entity type.</typeparam>
        /// <typeparam name="TProjection">A projection entity type.</typeparam>
        /// <typeparam name="TPrimaryKey">An entity primary key type.</typeparam>
        /// <param name="repository">A repository.</param>
        /// <param name="projectionEntity">An entity.</param>
        public static bool ProjectionHasPrimaryKey<TEntity, TProjection, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, TProjection projectionEntity) where TEntity : class {
            return GetProjectionValue(projectionEntity,
                (TEntity x) => repository.HasPrimaryKey(x),
                (TProjection x) => true);
        }

        /// <summary>
        /// Loads from the store or updates an entity with the given primary key value. If no entity with the given primary key is found in the store, returns null.
        /// </summary>
        /// <typeparam name="TEntity">A repository entity type.</typeparam>
        /// <typeparam name="TProjection">A projection entity type.</typeparam>
        /// <typeparam name="TPrimaryKey">An entity primary key type.</typeparam>
        /// <param name="repository">A repository.</param>
        /// <param name="projection">A LINQ function used to transform entities from the repository entity type to the projection entity type.</param>
        /// <param name="primaryKey">A value to compare with the entity primary key.</param>
        public static TProjection FindActualProjectionByKey<TEntity, TProjection, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, Func<IRepositoryQuery<TEntity>, IQueryable<TProjection>> projection, TPrimaryKey primaryKey) where TEntity : class {
            var primaryKeyEqualsExpression = GetProjectionPrimaryKeyEqualsExpression<TEntity, TProjection, TPrimaryKey>(repository, primaryKey);
            var result = repository.GetFilteredEntities(null, projection).Where(primaryKeyEqualsExpression).Take(1).ToArray().FirstOrDefault(); //WCF incorrect FirstOrDefault implementation workaround
            return GetProjectionValue(result,
                (TEntity x) => x != null ? repository.Reload(x) : null,
                (TProjection x) => x);
        }

        /// <summary>
        /// Returns an entity primary key property name.
        /// </summary>
        /// <typeparam name="TEntity">A repository entity type.</typeparam>
        /// <typeparam name="TPrimaryKey">A primary key type.</typeparam>
        /// <param name="repository">A repository.</param>
        public static string GetPrimaryKeyPropertyName<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository) where TEntity : class {
            return ExpressionHelper.GetPropertyName(repository.GetPrimaryKeyExpression);
        }

        static TProjectionResult GetProjectionValue<TEntity, TProjection, TEntityResult, TProjectionResult>(TProjection value, Func<TEntity, TEntityResult> entityFunc, Func<TProjection, TProjectionResult> projectionFunc) {
            if(typeof(TEntity) != typeof(TProjection) || typeof(TEntityResult) != typeof(TProjectionResult))
                return projectionFunc(value);
            return (TProjectionResult)(object)entityFunc((TEntity)(object)value);
        }

        static bool IsProjection<TEntity, TProjection>(TProjection projection) {
            return !(projection is TEntity);
        }
    }
}
