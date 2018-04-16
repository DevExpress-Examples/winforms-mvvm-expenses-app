using System;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;
using MVVMExpenses.Common.Utils;
using MVVMExpenses.Common.DataModel;
using MVVMExpenses.Common.DataModel.EntityFramework;
using MVVMExpenses.DataBase;
using MVVMExpenses.DataModels;
using DevExpress.XtraBars;

namespace MVVMExpenses.Models.MyDbContextDataModel {
    /// <summary>
    /// A MyDbContextUnitOfWork instance that represents the run-time implementation of the IMyDbContextUnitOfWork interface.
    /// </summary>
    public class MyDbContextUnitOfWork : DbUnitOfWork<MyDbContext>, IMyDbContextUnitOfWork {

        public MyDbContextUnitOfWork(Func<MyDbContext> contextFactory)
            : base(contextFactory) {
        }

        IRepository<Account, long> IMyDbContextUnitOfWork.Accounts {
            get { return GetRepository(x => x.Set<Account>(), x => x.ID); }
        }

        IRepository<Category, long> IMyDbContextUnitOfWork.Categories {
            get { return GetRepository(x => x.Set<Category>(), x => x.ID); }
        }

        IRepository<Transaction, long> IMyDbContextUnitOfWork.Transactions {
            get { return GetRepository(x => x.Set<Transaction>(), x => x.ID); }
        }

        BarHeaderItem bhi = new BarHeaderItem() { Width = 100 };
    }
}
