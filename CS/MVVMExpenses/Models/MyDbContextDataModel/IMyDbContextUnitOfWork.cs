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

namespace MVVMExpenses.Models.MyDbContextDataModel {
    /// <summary>
    /// IMyDbContextUnitOfWork extends the IUnitOfWork interface with repositories representing specific entities.
    /// </summary>
    public interface IMyDbContextUnitOfWork : IUnitOfWork {

        /// <summary>
        /// The Account entities repository.
        /// </summary>
        IRepository<Account, long> Accounts { get; }

        /// <summary>
        /// The Category entities repository.
        /// </summary>
        IRepository<Category, long> Categories { get; }

        /// <summary>
        /// The Transaction entities repository.
        /// </summary>
        IRepository<Transaction, long> Transactions { get; }
    }
}
