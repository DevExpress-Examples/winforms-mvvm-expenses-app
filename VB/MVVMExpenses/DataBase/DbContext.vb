Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data.Common
Imports System.Data.Entity
Imports System.Data.SQLite
Imports System.IO
Imports DevExpress.Internal
Imports MVVMExpenses.DataModels
Imports System.Data.Entity.Infrastructure
Imports System.Data.SQLite.EF6
Imports System.Data.Entity.Core.Common
Imports System.Reflection

Namespace MVVMExpenses.DataBase
    <DbConfigurationType(GetType(MVVMExpenses.Common.DataModel.EntityFramework.MyDbSQLiteConfiguration))>
    Public Class MyDbContext
        Inherits System.Data.Entity.DbContext
        Shared Sub New()
            System.Data.Entity.Database.SetInitializer(Of MyDbContext)(Nothing)
        End Sub

        Public Property Accounts() As DbSet(Of Account)
        Public Property Categories() As DbSet(Of Category)
        Public Property Transactions() As DbSet(Of Transaction)
    End Class
End Namespace