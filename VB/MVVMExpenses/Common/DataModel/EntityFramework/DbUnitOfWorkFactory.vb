Imports System
Imports System.Linq
Imports System.Data
Imports System.Data.Entity
Imports System.Linq.Expressions
Imports System.Collections.Generic
Imports Common.Utils
Imports Common.DataModel
Imports DevExpress.Mvvm
Imports System.Collections
Imports System.ComponentModel
Imports DevExpress.Data.Linq
Imports DevExpress.Data.Linq.Helpers
Imports DevExpress.Data.Async.Helpers
Namespace Common.DataModel.EntityFramework
    Friend Class DbUnitOfWorkFactory(Of TUnitOfWork As IUnitOfWork)
        Implements IUnitOfWorkFactory(Of TUnitOfWork)
        Private _createUnitOfWork As Func(Of TUnitOfWork)
        Public Sub New(ByVal createUnitOfWork As Func(Of TUnitOfWork))
            Me._createUnitOfWork = createUnitOfWork
        End Sub
        Private Function CreateUnitOfWork() As TUnitOfWork Implements IUnitOfWorkFactory(Of TUnitOfWork).CreateUnitOfWork
            Return _createUnitOfWork()
        End Function
        Private Function CreateInstantFeedbackSource(Of TEntity As {Class, New}, TProjection As Class, TPrimaryKey)(ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection))) As IInstantFeedbackSource(Of TProjection) Implements IUnitOfWorkFactory(Of TUnitOfWork).CreateInstantFeedbackSource
            Dim threadSafeProperties = New TypeInfoProxied(TypeDescriptor.GetProperties(GetType(TProjection)), Nothing).UIDescriptors
            If projection Is Nothing Then
                projection = Function(x) TryCast(x, IQueryable(Of TProjection))
            End If
            Dim source = New EntityInstantFeedbackSource(Sub(e As GetQueryableEventArgs) e.QueryableSource = projection(getRepositoryFunc(_createUnitOfWork()))) With {.KeyExpression = getRepositoryFunc(_createUnitOfWork()).GetPrimaryKeyPropertyName()}
            Return New InstantFeedbackSource(Of TProjection)(source, threadSafeProperties)
        End Function
    End Class
End Namespace
