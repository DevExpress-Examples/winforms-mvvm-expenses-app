Imports System
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports Common.Utils
Imports MVVMExpenses.Models.MyDbContextDataModel
Imports Common.DataModel
Imports MVVMExpenses.DataModels
Imports MVVMExpenses.DataBase
Imports Common.ViewModel
Namespace MVVMExpenses.ViewModels
    ''' <summary>
    ''' Represents the single Account object view model.
    ''' </summary>
    Partial Public Class AccountViewModel
        Inherits SingleObjectViewModel(Of Account, Long, IMyDbContextUnitOfWork)
        ''' <summary>
        ''' Creates a new instance of AccountViewModel as a POCO view model.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        Public Shared Function Create(Optional ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of IMyDbContextUnitOfWork) = Nothing) As AccountViewModel
            Return ViewModelSource.Create(Function() New AccountViewModel(unitOfWorkFactory))
        End Function
        ''' <summary>
        ''' Initializes a new instance of the AccountViewModel class.
        ''' This constructor is declared protected to avoid undesired instantiation of the AccountViewModel type without the POCO proxy factory.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        Protected Sub New(Optional ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of IMyDbContextUnitOfWork) = Nothing)
            MyBase.New(If(unitOfWorkFactory, UnitOfWorkSource.GetUnitOfWorkFactory()), Function(x) x.Accounts, Function(x) x.Name)
        End Sub

        Public ReadOnly Property AccountTransactionDetails() As CollectionViewModel(Of Transaction, Long, IMyDbContextUnitOfWork)
            Get
                Return GetDetailsCollectionViewModel(Function(x As AccountViewModel) x.AccountTransactionDetails, Function(x) x.Transactions, Function(x) x.AccountID, Sub(x, key) x.AccountID = key)
            End Get
        End Property
    End Class
End Namespace
