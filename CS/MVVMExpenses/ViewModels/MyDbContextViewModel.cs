using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using MVVMExpenses.Common.DataModel;
using MVVMExpenses.Common.ViewModel;
using MVVMExpenses.Models.MyDbContextDataModel;
using MVVMExpenses.DataBase;
using MVVMExpenses.DataModels;
using MVVMExpenses.ViewModels;

namespace MVVMExpenses.Models.ViewModels {
    /// <summary>
    /// Represents the root POCO view model for the MyDbContext data model.
    /// </summary>
    public partial class MyDbContextViewModel : DocumentsViewModel<MyDbContextModuleDescription, IMyDbContextUnitOfWork> {
        const string TablesGroup = "Tables";

        const string ViewsGroup = "Views";

        /// <summary>
        /// Creates a new instance of MyDbContextViewModel as a POCO view model.
        /// </summary>
        public static MyDbContextViewModel Create() {
            return ViewModelSource.Create(() => new MyDbContextViewModel());
        }

        /// <summary>
        /// Initializes a new instance of the MyDbContextViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the MyDbContextViewModel type without the POCO proxy factory.
        /// </summary>
        //protected MyDbContextViewModel()
        //    : base(UnitOfWorkSource.GetUnitOfWorkFactory()) {
        //}

        protected override MyDbContextModuleDescription[] CreateModules() {
            return new MyDbContextModuleDescription[] {
                new MyDbContextModuleDescription("Accounts", "AccountCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Accounts)),
                new MyDbContextModuleDescription("Categories", "CategoryCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Categories)),
                new MyDbContextModuleDescription("Transactions", "TransactionCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Transactions)),
			};
        }



    }

    public partial class MyDbContextModuleDescription : ModuleDescription<MyDbContextModuleDescription> {
        public MyDbContextModuleDescription(string title, string documentType, string group, Func<MyDbContextModuleDescription, object> peekCollectionViewModelFactory = null)
            : base(title, documentType, group, peekCollectionViewModelFactory) {
        }
    }
}