using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MVVMExpenses.Common.DataModel.EntityFramework {
    /// <summary>
    /// A DbReadOnlyRepository is a IReadOnlyRepository interface implementation representing the collection of all entities in the unit of work, or that can be queried from the database, of a given type. 
    /// DbReadOnlyRepository objects are created from a DbUnitOfWork using the GetReadOnlyRepository method. 
    /// DbReadOnlyRepository provides only read-only operations against entities of a given type.
    /// </summary>
    /// <typeparam name="TEntity">Repository entity type.</typeparam>
    /// <typeparam name="TDbContext">DbContext type.</typeparam>
    public class DbReadOnlyRepository<TEntity, TDbContext> : DbRepositoryQuery<TEntity>, IReadOnlyRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext {

        readonly Func<TDbContext, DbSet<TEntity>> dbSetAccessor;
        readonly DbUnitOfWork<TDbContext> unitOfWork;

        /// <summary>
        /// Initializes a new instance of DbReadOnlyRepository class.
        /// </summary>
        /// <param name="unitOfWork">Owner unit of work that provides context for repository entities.</param>
        /// <param name="dbSetAccessor">Function that returns DbSet entities from Entity Framework DbContext.</param>
        public DbReadOnlyRepository(DbUnitOfWork<TDbContext> unitOfWork, Func<TDbContext, DbSet<TEntity>> dbSetAccessor)
            : base(() => dbSetAccessor(unitOfWork.Context)) {
            this.dbSetAccessor = dbSetAccessor;
            this.unitOfWork = unitOfWork;
        }

        protected DbSet<TEntity> DbSet {
            get { return dbSetAccessor(unitOfWork.Context); }
        }

        protected TDbContext Context {
            get { return unitOfWork.Context; }
        }

        #region IReadOnlyRepository
        IUnitOfWork IReadOnlyRepository<TEntity>.UnitOfWork {
            get { return unitOfWork; }
        }
        #endregion
    }

    /// <summary>
    /// DbRepositoryQuery is an IRepositoryQuery interface implementation that is an extension of IQueryable designed to specify the related objects to include in query results.
    /// </summary>
    /// <typeparam name="TEntity">An entity type.</typeparam>
    public class DbRepositoryQuery<TEntity> : RepositoryQueryBase<TEntity>, IRepositoryQuery<TEntity> where TEntity : class {

        /// <summary>
        /// Initializes a new instance of the DesignTimeRepositoryQuery class.
        /// </summary>
        /// <param name="getQueryable">A function that returns an IQueryable instance which is used by DbRepositoryQuery to perform queries.</param>
        public DbRepositoryQuery(Func<IQueryable<TEntity>> getQueryable)
            : base(getQueryable) { }

        IRepositoryQuery<TEntity> IRepositoryQuery<TEntity>.Include<TProperty>(Expression<Func<TEntity, TProperty>> path) {
            return new DbRepositoryQuery<TEntity>(() => Queryable.Include(path));
        }

        IRepositoryQuery<TEntity> IRepositoryQuery<TEntity>.Where(Expression<Func<TEntity, bool>> predicate) {
            return new DbRepositoryQuery<TEntity>(() => Queryable.Where(predicate));
        }
    }
}
