using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using MVVMExpenses.Common.Utils;
using MVVMExpenses.Models.MyDbContextDataModel;
using MVVMExpenses.Common.DataModel;
using MVVMExpenses.DataModels;
using MVVMExpenses.DataBase;
using MVVMExpenses.Common.ViewModel;

namespace MVVMExpenses.Models.ViewModels {
    /// <summary>
    /// Represents the single Transaction object view model.
    /// </summary>
    public partial class TransactionViewModel : SingleObjectViewModel<Transaction, long, IMyDbContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of TransactionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static TransactionViewModel Create(IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new TransactionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the TransactionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the TransactionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected TransactionViewModel(IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Transactions, x => x.Comment) {
        }

        /// <summary>
        /// The view model that contains a look-up collection of Accounts for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Account> LookUpAccounts {
            get { return GetLookUpEntitiesViewModel((TransactionViewModel x) => x.LookUpAccounts, x => x.Accounts); }
        }

        /// <summary>
        /// The view model that contains a look-up collection of Categories for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Category> LookUpCategories {
            get { return GetLookUpEntitiesViewModel((TransactionViewModel x) => x.LookUpCategories, x => x.Categories); }
        }
    }
}
