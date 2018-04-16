Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.ComponentModel
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports Common.DataModel
Imports Common.ViewModel
Imports MVVMExpenses.Models.MyDbContextDataModel
Imports MVVMExpenses.DataBase
Imports MVVMExpenses.DataModels
Namespace MVVMExpenses.ViewModels
    ''' <summary>
    ''' Represents the root POCO view model for the MyDbContext data model.
    ''' </summary>
    Partial Public Class MyDbContextViewModel
        Inherits DocumentsViewModel(Of MyDbContextModuleDescription, IMyDbContextUnitOfWork)
        Private Const _TablesGroup As String = "Tables"
        Private Const _ViewsGroup As String = "Views"
        ''' <summary>
        ''' Creates a new instance of MyDbContextViewModel as a POCO view model.
        ''' </summary>
        Public Shared Function Create() As MyDbContextViewModel
            Return ViewModelSource.Create(Function() New MyDbContextViewModel())
        End Function
        ''' <summary>
        ''' Initializes a new instance of the MyDbContextViewModel class.
        ''' This constructor is declared protected to avoid undesired instantiation of the MyDbContextViewModel type without the POCO proxy factory.
        ''' </summary>
        'Protected Sub New()
        '    MyBase.New(UnitOfWorkSource.GetUnitOfWorkFactory())
        'End Sub
        Protected Overrides Function CreateModules() As MyDbContextModuleDescription()
            Return New MyDbContextModuleDescription() {New MyDbContextModuleDescription("Accounts", "AccountCollectionView", _TablesGroup, GetPeekCollectionViewModelFactory(Function(x) x.Accounts)), New MyDbContextModuleDescription("Categories", "CategoryCollectionView", _TablesGroup, GetPeekCollectionViewModelFactory(Function(x) x.Categories)), New MyDbContextModuleDescription("Transactions", "TransactionCollectionView", _TablesGroup, GetPeekCollectionViewModelFactory(Function(x) x.Transactions))}
        End Function
    End Class
    Partial Public Class MyDbContextModuleDescription
        Inherits ModuleDescription(Of MyDbContextModuleDescription)
        Public Sub New(ByVal title As String, ByVal documentType As String, ByVal group As String, Optional ByVal peekCollectionViewModelFactory As Func(Of MyDbContextModuleDescription, Object) = Nothing)
            MyBase.New(title, documentType, group, peekCollectionViewModelFactory)
        End Sub
    End Class
End Namespace
