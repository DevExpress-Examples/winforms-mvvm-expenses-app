Imports System
Imports System.Linq
Imports System.Data
Imports System.Data.Entity
Imports System.Linq.Expressions
Imports System.Collections.Generic
Imports Common.Utils
Imports Common.DataModel
Imports Common.DataModel.EntityFramework
Imports MVVMExpenses.DataBase
Imports MVVMExpenses.DataModels
Namespace MVVMExpenses.Models.MyDbContextDataModel
    ''' <summary>
    ''' IMyDbContextUnitOfWork extends the IUnitOfWork interface with repositories representing specific entities.
    ''' </summary>
    Public Interface IMyDbContextUnitOfWork
        Inherits IUnitOfWork
        ''' <summary>
        ''' The Account entities repository.
        ''' </summary>
        ReadOnly Property Accounts As IRepository(Of Account, Long)
        ''' <summary>
        ''' The Category entities repository.
        ''' </summary>
        ReadOnly Property Categories As IRepository(Of Category, Long)
        ''' <summary>
        ''' The Transaction entities repository.
        ''' </summary>
        ReadOnly Property Transactions As IRepository(Of Transaction, Long)
    End Interface
End Namespace
