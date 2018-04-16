using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace MVVMExpenses.Common.DataModel.EntityFramework {
    /// <summary>
    /// A DbUnitOfWork instance represents the implementation of the Unit Of Work pattern 
    /// such that it can be used to query from a database and group together changes that will then be written back to the store as a unit. 
    /// </summary>
    /// <typeparam name="TContext">DbContext type.</typeparam>
    public abstract class DbUnitOfWork<TContext> : UnitOfWorkBase, IUnitOfWork where TContext : DbContext {

        readonly Lazy<TContext> context;

        public DbUnitOfWork(Func<TContext> contextFactory) {
            context = new Lazy<TContext>(contextFactory);
        }

        /// <summary>
        /// Instance of underlying DbContext.
        /// </summary>
        public TContext Context { get { return context.Value; } }

        void IUnitOfWork.SaveChanges() {
            try {
                Context.SaveChanges();
            }
            catch(DbEntityValidationException ex) {
                throw DbExceptionsConverter.Convert(ex);
            }
            catch(DbUpdateException ex) {
                throw DbExceptionsConverter.Convert(ex);
            }
        }

        bool IUnitOfWork.HasChanges() {
            return Context.ChangeTracker.HasChanges();
        }

        protected IRepository<TEntity, TPrimaryKey>
            GetRepository<TEntity, TPrimaryKey>(Func<TContext, DbSet<TEntity>> dbSetAccessor, Expression<Func<TEntity, TPrimaryKey>> getPrimaryKeyExpression)
            where TEntity : class {
            return GetRepositoryCore<IRepository<TEntity, TPrimaryKey>, TEntity>(() => new DbRepository<TEntity, TPrimaryKey, TContext>(this, dbSetAccessor, getPrimaryKeyExpression));
        }

        protected IReadOnlyRepository<TEntity>
            GetReadOnlyRepository<TEntity>(Func<TContext, DbSet<TEntity>> dbSetAccessor)
            where TEntity : class {
            return GetRepositoryCore<IReadOnlyRepository<TEntity>, TEntity>(() => new DbReadOnlyRepository<TEntity, TContext>(this, dbSetAccessor));
        }
    }
}