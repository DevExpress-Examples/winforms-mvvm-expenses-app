Imports System
Imports System.Collections.Generic
Imports System.Data.Common
Imports System.Data.SQLite
Imports System.Data.SQLite.EF6
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.DocumentServices.ServiceModel.DataContracts.Xpf.Designer
Imports DevExpress.Internal

Namespace MVVMExpenses.Common.DataModel.EntityFramework
    Public Class SQLiteConnectionFactory
        Implements System.Data.Entity.Infrastructure.IDbConnectionFactory

        Private Shared filePath As String
        Public Function CreateConnection(ByVal nameOrConnectionString As String) As DbConnection Implements System.Data.Entity.Infrastructure.IDbConnectionFactory.CreateConnection
            If filePath Is Nothing Then
                filePath = DataDirectoryHelper.GetFile("expenses.sqlite3", DataDirectoryHelper.DataFolderName)
                File.SetAttributes(filePath, File.GetAttributes(filePath) And (Not FileAttributes.ReadOnly))
            End If
            Return New SQLiteConnection(New SQLiteConnectionStringBuilder() With {.DataSource = filePath}.ConnectionString)
        End Function
    End Class

    Public Class MyDbSQLiteConfiguration
        Inherits System.Data.Entity.DbConfiguration

        Public Sub New()
            SetDefaultConnectionFactory(New SQLiteConnectionFactory())
            SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance)
            SetProviderFactory("System.Data.SQLite.EF6", System.Data.SQLite.EF6.SQLiteProviderFactory.Instance)
            Dim t As Type = Type.GetType("System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6", True, True)
            Dim fi As System.Reflection.FieldInfo = t.GetField("Instance", System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Static)
            SetProviderServices("System.Data.SQLite", DirectCast(fi.GetValue(Nothing), System.Data.Entity.Core.Common.DbProviderServices))
        End Sub
    End Class
End Namespace