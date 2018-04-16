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
    ''' Represents the single Category object view model.
    ''' </summary>
    Partial Public Class CategoryViewModel
        Inherits SingleObjectViewModel(Of Category, Long, IMyDbContextUnitOfWork)
        ''' <summary>
        ''' Creates a new instance of CategoryViewModel as a POCO view model.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        Public Shared Function Create(Optional ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of IMyDbContextUnitOfWork) = Nothing) As CategoryViewModel
            Return ViewModelSource.Create(Function() New CategoryViewModel(unitOfWorkFactory))
        End Function
        ''' <summary>
        ''' Initializes a new instance of the CategoryViewModel class.
        ''' This constructor is declared protected to avoid undesired instantiation of the CategoryViewModel type without the POCO proxy factory.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        Protected Sub New(Optional ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of IMyDbContextUnitOfWork) = Nothing)
            MyBase.New(If(unitOfWorkFactory, UnitOfWorkSource.GetUnitOfWorkFactory()), Function(x) x.Categories, Function(x) x.Name)
        End Sub

        Public ReadOnly Property CategoryTransactionDetails() As CollectionViewModel(Of Transaction, Long, IMyDbContextUnitOfWork)
            Get
                Return GetDetailsCollectionViewModel(Function(x As CategoryViewModel) x.CategoryTransactionDetails, Function(x) x.Transactions, Function(x) x.CategoryID, Sub(x, key) x.CategoryID = key)
            End Get
        End Property
    End Class
End Namespace
