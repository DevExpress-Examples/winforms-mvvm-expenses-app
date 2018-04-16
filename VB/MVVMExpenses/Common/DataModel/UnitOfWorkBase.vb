Imports System
Imports System.Linq
Imports System.Collections.Generic
Imports System.Linq.Expressions
Namespace Common.DataModel
    ''' <summary>
    ''' The base class for unit of works that provides the storage for repositories. 
    ''' </summary>
    Public Class UnitOfWorkBase
        Private ReadOnly _repositories As Dictionary(Of Type, Object) = New Dictionary(Of Type, Object)()
        Protected Function GetRepositoryCore(Of TRepository As IReadOnlyRepository(Of TEntity), TEntity As Class)(ByVal createRepositoryFunc As Func(Of TRepository)) As TRepository
            Dim result As Object = Nothing
            If Not _repositories.TryGetValue(GetType(TEntity), result) Then
                result = createRepositoryFunc()
                _repositories(GetType(TEntity)) = result
            End If
            Return CType(result, TRepository)
        End Function
    End Class
End Namespace
