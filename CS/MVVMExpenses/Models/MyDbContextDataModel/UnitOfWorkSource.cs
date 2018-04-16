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
using DevExpress.Mvvm;
using System.Collections;
using System.ComponentModel;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.Async.Helpers;

namespace MVVMExpenses.Models.MyDbContextDataModel {
    /// <summary>
    /// Provides methods to obtain the relevant IUnitOfWorkFactory.
    /// </summary>
    public static class UnitOfWorkSource {

        /// <summary>
        /// Returns the IUnitOfWorkFactory implementation.
        /// </summary>
        public static IUnitOfWorkFactory<IMyDbContextUnitOfWork> GetUnitOfWorkFactory() {
            return new DbUnitOfWorkFactory<IMyDbContextUnitOfWork>(() => new MyDbContextUnitOfWork(() => new MyDbContext()));
        }
    }
}