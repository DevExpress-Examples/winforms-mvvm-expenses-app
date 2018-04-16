using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using MVVMExpenses.Common.Utils;
using MVVMExpenses.Models.MyDbContextDataModel;
using MVVMExpenses.Common.DataModel;
using MVVMExpenses.DataModels;
using MVVMExpenses.DataBase;
using MVVMExpenses.Common.ViewModel;
using System.Collections.Generic;

namespace MVVMExpenses.Models.ViewModels {
    /// <summary>
    /// Represents the Accounts collection view model.
    /// </summary>
    public partial class AccountCollectionViewModel : CollectionViewModel<Account, long, IMyDbContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of AccountCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static AccountCollectionViewModel Create(IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new AccountCollectionViewModel(unitOfWorkFactory));
        }
        
        /// <summary>
        /// Initializes a new instance of the AccountCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the AccountCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected AccountCollectionViewModel(IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Accounts) {
        }
    }
}