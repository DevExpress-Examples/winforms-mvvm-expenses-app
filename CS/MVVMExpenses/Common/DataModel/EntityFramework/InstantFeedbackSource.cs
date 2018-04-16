using System;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;
using MVVMExpenses.Common.Utils;
using MVVMExpenses.Common.DataModel;
using DevExpress.Mvvm;
using System.Collections;
using System.ComponentModel;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.Async.Helpers;

namespace MVVMExpenses.Common.DataModel.EntityFramework {

    class InstantFeedbackSource<TEntity> : IInstantFeedbackSource<TEntity>
        where TEntity : class {
        readonly EntityInstantFeedbackSource source;
        readonly PropertyDescriptorCollection threadSafeProperties;

        public InstantFeedbackSource(EntityInstantFeedbackSource source, PropertyDescriptorCollection threadSafeProperties) {
            this.source = source;
            this.threadSafeProperties = threadSafeProperties;
        }

        bool IListSource.ContainsListCollection { get { return ((IListSource)source).ContainsListCollection; } }

        IList IListSource.GetList() {
            return ((IListSource)source).GetList();
        }

        TProperty IInstantFeedbackSource<TEntity>.GetPropertyValue<TProperty>(object threadSafeProxy, Expression<Func<TEntity, TProperty>> propertyExpression) {
            var propertyName = ExpressionHelper.GetPropertyName(propertyExpression);
            var threadSafeProperty = threadSafeProperties[propertyName];
            return (TProperty)threadSafeProperty.GetValue(threadSafeProxy);
        }

        bool IInstantFeedbackSource<TEntity>.IsLoadedProxy(object threadSafeProxy) {
            return threadSafeProxy is ReadonlyThreadSafeProxyForObjectFromAnotherThread;
        }

        void IInstantFeedbackSource<TEntity>.Refresh() {
            source.Refresh();
        }
    }
}