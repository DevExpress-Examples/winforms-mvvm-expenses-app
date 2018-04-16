Imports System
Imports System.Linq
Imports DevExpress.Mvvm.POCO
Imports Common.Utils
Imports MVVMExpenses.Models.MyDbContextDataModel
Imports Common.DataModel
Imports MVVMExpenses.DataModels
Imports MVVMExpenses.DataBase
Imports Common.ViewModel
Namespace MVVMExpenses.ViewModels
    ''' <summary>
    ''' Represents the Transactions collection view model.
    ''' </summary>
    Partial Public Class TransactionCollectionViewModel
        Inherits CollectionViewModel(Of Transaction, Long, IMyDbContextUnitOfWork)
        ''' <summary>
        ''' Creates a new instance of TransactionCollectionViewModel as a POCO view model.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        Public Shared Function Create(Optional ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of IMyDbContextUnitOfWork) = Nothing) As TransactionCollectionViewModel
            Return ViewModelSource.Create(Function() New TransactionCollectionViewModel(unitOfWorkFactory))
        End Function
        ''' <summary>
        ''' Initializes a new instance of the TransactionCollectionViewModel class.
        ''' This constructor is declared protected to avoid undesired instantiation of the TransactionCollectionViewModel type without the POCO proxy factory.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        Protected Sub New(Optional ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of IMyDbContextUnitOfWork) = Nothing)
            MyBase.New(If(unitOfWorkFactory, UnitOfWorkSource.GetUnitOfWorkFactory()), Function(x) x.Transactions)
        End Sub
    End Class
End Namespace
