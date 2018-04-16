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
    ''' A MyDbContextUnitOfWork instance that represents the run-time implementation of the IMyDbContextUnitOfWork interface.
    ''' </summary>
    Public Class MyDbContextUnitOfWork
        Inherits DbUnitOfWork(Of MyDbContext)
        Implements IMyDbContextUnitOfWork
        Public Sub New(ByVal contextFactory As Func(Of MyDbContext))
            MyBase.New(contextFactory)
        End Sub
        Private ReadOnly Property Accounts As IRepository(Of Account, Long) Implements IMyDbContextUnitOfWork.Accounts
            Get
                Return GetRepository(Function(x) x.[Set](Of Account)(), Function(x) x.ID)
            End Get
        End Property
        Private ReadOnly Property Categories As IRepository(Of Category, Long) Implements IMyDbContextUnitOfWork.Categories
            Get
                Return GetRepository(Function(x) x.[Set](Of Category)(), Function(x) x.ID)
            End Get
        End Property
        Private ReadOnly Property Transactions As IRepository(Of Transaction, Long) Implements IMyDbContextUnitOfWork.Transactions
            Get
                Return GetRepository(Function(x) x.[Set](Of Transaction)(), Function(x) x.ID)
            End Get
        End Property
    End Class
End Namespace
