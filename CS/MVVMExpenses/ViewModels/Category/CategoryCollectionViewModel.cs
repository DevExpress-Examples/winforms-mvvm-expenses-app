using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using MVVMExpenses.Common.Utils;
using MVVMExpenses.Models.MyDbContextDataModel;
using MVVMExpenses.Common.DataModel;
using MVVMExpenses.DataModels;
using MVVMExpenses.DataBase;
using MVVMExpenses.Common.ViewModel;

namespace MVVMExpenses.Models.ViewModels {
    /// <summary>
    /// Represents the Categories collection view model.
    /// </summary>
    public partial class CategoryCollectionViewModel : CollectionViewModel<Category, long, IMyDbContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of CategoryCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static CategoryCollectionViewModel Create(IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new CategoryCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the CategoryCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the CategoryCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected CategoryCollectionViewModel(IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Categories) {
        }
    }
}