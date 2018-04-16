using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MVVMExpenses.Common.DataModel {
    /// <summary>
    /// The base class for unit of works that provides the storage for repositories. 
    /// </summary>
    public class UnitOfWorkBase {

        readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        protected TRepository GetRepositoryCore<TRepository, TEntity>(Func<TRepository> createRepositoryFunc)
            where TRepository : IReadOnlyRepository<TEntity>
            where TEntity : class {
            object result = null;
            if(!repositories.TryGetValue(typeof(TEntity), out result)) {
                result = createRepositoryFunc();
                repositories[typeof(TEntity)] = result;
            }
            return (TRepository)result;
        }
    }
}